using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EffinghamLibrary;

namespace TellerUI
{
    public partial class MainForm : Form
    {
        private IVault vault;
        public MainForm()
        {
            InitializeComponent();
            vault = SOAPVault.Instance;
        }

        private void NewAccountButton_Click(object sender, EventArgs e)
        {
            try
            {

                BankAccount ba;
                if (SavingsRadioButton.Checked)
                {
                    ba = new SavingsAccount(Decimal.Parse(StartingBalanceTextBox.Text), CustomerNameTextBox.Text,
                        (CurrencyType)CurrencyTypeComboBox.SelectedItem);

                    //MessageBox.Show(String.Format("Customer Name: {0}\nBalance: {1}\nCurrency: {2}", ba.CustomerName, ba.Balance, CurrencyTypeComboBox.SelectedItem), "Savings Account Created!");
                }
                else
                {
                    ba = new CheckingAccount(Decimal.Parse(StartingBalanceTextBox.Text), CustomerNameTextBox.Text,
                        (CurrencyType)CurrencyTypeComboBox.SelectedItem);

                    //MessageBox.Show(String.Format("Customer Name: {0}\nBalance: {1}\nCurrency: {2}", ba.CustomerName, ba.Balance, CurrencyTypeComboBox.SelectedItem), "Checking Account Created!");
                }
                vault.AddAccount(ba);
                SummarizeAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Account Creation Failed");
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrencyTypeComboBox.DataSource = Enum.GetValues(typeof(CurrencyType));
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

                foreach (BankAccount ba in vault.GetAccounts())
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
                accountList.Sort();
                AccountListBox.DataSource = accountList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("In SummarizeAccounts: "+ex.Message);
            }
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            vault.Dispose();
        }
    }
}
