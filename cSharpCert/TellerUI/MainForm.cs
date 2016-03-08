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
        public MainForm()
        {
            InitializeComponent();
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

                    MessageBox.Show(String.Format("Customer Name: {0}\nBalance: {1}\nCurrency: {2}", ba.CustomerName, ba.Balance, CurrencyTypeComboBox.SelectedItem), "Savings Account Created!");
                }
                else
                {
                    ba = new CheckingAccount(Decimal.Parse(StartingBalanceTextBox.Text), CustomerNameTextBox.Text,
                        (CurrencyType)CurrencyTypeComboBox.SelectedItem);

                    MessageBox.Show(String.Format("Customer Name: {0}\nBalance: {1}\nCurrency: {2}", ba.CustomerName, ba.Balance, CurrencyTypeComboBox.SelectedItem), "Checking Account Created!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Account Creation Failed", ex.Message);
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrencyTypeComboBox.DataSource = Enum.GetValues(typeof(CurrencyType));
        }
    }
}
