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
                BankAccount ba = new BankAccount(Decimal.Parse(StartingBalanceTextBox.Text), CustomerNameTextBox.Text,(CurrencyType)CurrencyTypeComboBox.SelectedItem);

                MessageBox.Show("Account Creation Successful!",String.Format("{0:c} in Account", ba.Balance));
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
