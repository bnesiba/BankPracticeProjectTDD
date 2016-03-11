using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EffinghamLibrary;

namespace TellerUI
{
    public partial class MainForm : Form
    {
        private IVault vault;
        public MainForm(IVault aVault)
        {
            InitializeComponent();
            vault = aVault;
        }

        private void NewAccountButton_Click(object sender, EventArgs e)
        {
            try
            {

                BankAccount ba;
                decimal startingAmt;
                bool sucessfulParse = Decimal.TryParse(StartingBalanceTextBox.Text, out startingAmt);
                if (!sucessfulParse)
                {
                    MessageBox.Show("Starting Balance must be a number greater than 0","Invalid Starting Amount");
                    return;
                }

                if (SavingsRadioButton.Checked)
                {
                    ba = new SavingsAccount(startingAmt, CustomerNameTextBox.Text,
                        (CurrencyType)CurrencyTypeComboBox.SelectedItem);

                }
                else
                {
                    ba = new CheckingAccount(startingAmt, CustomerNameTextBox.Text,
                        (CurrencyType)CurrencyTypeComboBox.SelectedItem);

                }
                vault.AddAccount(ba);
                SummarizeAccounts();
            }
            catch (ApplicationException ax)
            {
                MessageBox.Show(ax.Message, "Account Creation Failed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Critical Failure");
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrencyTypeComboBox.DataSource = Enum.GetValues(typeof(CurrencyType));
            SortComboBox.SelectedIndex = 0;
            FilterComboBox.SelectedIndex = 0;
            SummarizeAccounts();
        }
        private void SummarizeAccounts()
        {
            try
            {
                decimal totalAmt = 0m;
                int numChecking = 0;
                int numSavings = 0;
                List<BankAccount> accountList = new List<BankAccount>();
                IEnumerable<BankAccount> enumerable;
                
                Task<IEnumerable<BankAccount>> ta = vault.GetAccountsAsync();
                ta.Wait();

                enumerable = ta.Result;

                foreach (BankAccount ba in enumerable)
                {
                    totalAmt += ba.Balance;
                    if (ba is CheckingAccount)
                    {
                        numChecking++;
                        accountList.Add(ba);
                    }
                    else if (ba is SavingsAccount)
                    {
                        numSavings++;
                        accountList.Add(ba);
                    }
                    else
                    {
                        throw new ApplicationException("Invalid Account Type Loaded");
                    }
                }
                BranchInfoLabel.Text = String.Format("${0} Total. Checking Accounts:{1}  Savings Accounts:{2}", totalAmt, numChecking,
                    numSavings);

                accountList = FilterAccounts(accountList);
                ArrangeAccounts(accountList);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("In SummarizeAccounts: "+ex.Message);
            }
            
        }

        /// <summary>
        /// Organize accounts in accounts box on main form
        /// </summary>
        /// <param name="list">List of accounts. Retrieved from vault if not passed in</param>
        private void ArrangeAccounts(List<BankAccount> list = null)
        {
            try
            {
                List<BankAccount> accountList;
                if (list != null)
                {
                    accountList = list;
                }
                else
                {
                    accountList = vault.GetAccounts().ToList<BankAccount>();
                    accountList = FilterAccounts(accountList);
                }

                switch (SortComboBox.SelectedIndex)
                {
                    case 0:
                        accountList.Sort((x, y) => x.AccountNumber.CompareTo(y.AccountNumber));
                        break;
                    case 1:
                        //accountList.Sort((x, y) => x.CustomerName.CompareTo(y.CustomerName
                        accountList.Sort(CustomerNameComparer);
                        break;
                    case 2:
                        accountList.Sort((x, y) => y.Balance.CompareTo(x.Balance));
                        break;
                    default:
                        throw new ApplicationException("Invalid Sort Method");

                }
                AccountListBox.DataSource = accountList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Retreiving Data:"+ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw ex;
            }
            
        }
        /// <summary>
        /// Applies filter to accounts box on main form
        /// </summary>
        /// <param name="list">List of accounts</param>
        /// <returns>Filtered List of accounts</returns>
        private List<BankAccount> FilterAccounts(List<BankAccount> list)
        {

            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    list = (from x in list
                           where x is SavingsAccount
                           select x).ToList<BankAccount>();
                    break;
                case 2:
                    list = list.Where<BankAccount>(x => x is CheckingAccount).ToList<BankAccount>();
                    break;
                default:
                    break;
            }
            return list;
        }

        private int CustomerNameComparer(BankAccount a, BankAccount b)
        {
            int result = a.CustomerName.CompareTo(b.CustomerName);
            if (result == 0)
            {
                result = b.Balance.CompareTo(a.Balance);
            }
            return result;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            vault.Dispose();
        }

        private void SortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrangeAccounts();
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrangeAccounts();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            vault.Deleteaccount(AccountListBox.SelectedItem as BankAccount);
            SummarizeAccounts();
        }

        private void DepositFiveButton_Click(object sender, EventArgs e)
        {
            foreach (BankAccount ba in vault.GetAccounts())
            {
                ba.Deposit(5);
                try
                {
                    vault.UpdateAccount(ba, true);
                }
                catch (Exception ex)
                {
                    DialogResult res = MessageBox.Show(ba.ToString(), $"Error occurred during deposit: {ex.Message}\nContinue?", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                    {
                        break;
                    }
                }
                
            }
            vault.FlushAccounts();
            SummarizeAccounts();
        }

        private void WithdrawFiveButton_Click(object sender, EventArgs e)
        {
            foreach (BankAccount ba in vault.GetAccounts())
            {
                ba.Withdraw(5);
                try
                {
                    vault.UpdateAccount(ba, true);
                }
                catch (Exception ex)
                {
                    DialogResult res = MessageBox.Show(ba.ToString(), $"Error occurred during withdrawl: {ex.Message}\nContinue?", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                    {
                        break;
                    }
                }
                
               
            }
            vault.FlushAccounts();
            SummarizeAccounts();
        }

        private void MonthlyInterestButton_Click(object sender, EventArgs e)
        {
            foreach (BankAccount ba in vault.GetAccounts())
            {
                if (ba is SavingsAccount)
                {
                    ((SavingsAccount)ba).AddMonthlyInterest();
                }
                vault.UpdateAccount(ba, true);
            }
            vault.FlushAccounts();
            SummarizeAccounts();
        }
    }
    }
    
