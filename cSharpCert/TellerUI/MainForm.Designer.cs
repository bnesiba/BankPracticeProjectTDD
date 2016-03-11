namespace TellerUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.StartingAmountLabel = new System.Windows.Forms.Label();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.NewAccountButton = new System.Windows.Forms.Button();
            this.StartingBalanceTextBox = new System.Windows.Forms.TextBox();
            this.BranchInfoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrencyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.AccontTypeLabel = new System.Windows.Forms.Label();
            this.SavingsRadioButton = new System.Windows.Forms.RadioButton();
            this.CheckingRadioButton = new System.Windows.Forms.RadioButton();
            this.AccountListBox = new System.Windows.Forms.ListBox();
            this.SortLabel = new System.Windows.Forms.Label();
            this.SortComboBox = new System.Windows.Forms.ComboBox();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DepositFiveButton = new System.Windows.Forms.Button();
            this.WithdrawFiveButton = new System.Windows.Forms.Button();
            this.MonthlyInterestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameLabel.Location = new System.Drawing.Point(5, 15);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(108, 16);
            this.CustomerNameLabel.TabIndex = 0;
            this.CustomerNameLabel.Text = "Customer Name:";
            // 
            // StartingAmountLabel
            // 
            this.StartingAmountLabel.AutoSize = true;
            this.StartingAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingAmountLabel.Location = new System.Drawing.Point(4, 43);
            this.StartingAmountLabel.Name = "StartingAmountLabel";
            this.StartingAmountLabel.Size = new System.Drawing.Size(109, 16);
            this.StartingAmountLabel.TabIndex = 1;
            this.StartingAmountLabel.Text = "Starting Balance:";
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameTextBox.Location = new System.Drawing.Point(119, 12);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(292, 22);
            this.CustomerNameTextBox.TabIndex = 2;
            // 
            // NewAccountButton
            // 
            this.NewAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewAccountButton.Location = new System.Drawing.Point(119, 147);
            this.NewAccountButton.Name = "NewAccountButton";
            this.NewAccountButton.Size = new System.Drawing.Size(113, 23);
            this.NewAccountButton.TabIndex = 4;
            this.NewAccountButton.Text = "Create Account";
            this.NewAccountButton.UseVisualStyleBackColor = true;
            this.NewAccountButton.Click += new System.EventHandler(this.NewAccountButton_Click);
            // 
            // StartingBalanceTextBox
            // 
            this.StartingBalanceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingBalanceTextBox.Location = new System.Drawing.Point(119, 40);
            this.StartingBalanceTextBox.Name = "StartingBalanceTextBox";
            this.StartingBalanceTextBox.Size = new System.Drawing.Size(292, 22);
            this.StartingBalanceTextBox.TabIndex = 5;
            // 
            // BranchInfoLabel
            // 
            this.BranchInfoLabel.AutoSize = true;
            this.BranchInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchInfoLabel.Location = new System.Drawing.Point(11, 260);
            this.BranchInfoLabel.Name = "BranchInfoLabel";
            this.BranchInfoLabel.Size = new System.Drawing.Size(15, 16);
            this.BranchInfoLabel.TabIndex = 6;
            this.BranchInfoLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Currency Type:";
            // 
            // CurrencyTypeComboBox
            // 
            this.CurrencyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrencyTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyTypeComboBox.FormattingEnabled = true;
            this.CurrencyTypeComboBox.Location = new System.Drawing.Point(119, 117);
            this.CurrencyTypeComboBox.Name = "CurrencyTypeComboBox";
            this.CurrencyTypeComboBox.Size = new System.Drawing.Size(156, 24);
            this.CurrencyTypeComboBox.TabIndex = 8;
            // 
            // AccontTypeLabel
            // 
            this.AccontTypeLabel.AutoSize = true;
            this.AccontTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccontTypeLabel.Location = new System.Drawing.Point(14, 69);
            this.AccontTypeLabel.Name = "AccontTypeLabel";
            this.AccontTypeLabel.Size = new System.Drawing.Size(94, 16);
            this.AccontTypeLabel.TabIndex = 9;
            this.AccontTypeLabel.Text = "Account Type:";
            // 
            // SavingsRadioButton
            // 
            this.SavingsRadioButton.AutoSize = true;
            this.SavingsRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavingsRadioButton.Location = new System.Drawing.Point(119, 91);
            this.SavingsRadioButton.Name = "SavingsRadioButton";
            this.SavingsRadioButton.Size = new System.Drawing.Size(75, 20);
            this.SavingsRadioButton.TabIndex = 11;
            this.SavingsRadioButton.Text = "Savings";
            this.SavingsRadioButton.UseVisualStyleBackColor = true;
            // 
            // CheckingRadioButton
            // 
            this.CheckingRadioButton.AutoSize = true;
            this.CheckingRadioButton.Checked = true;
            this.CheckingRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckingRadioButton.Location = new System.Drawing.Point(119, 65);
            this.CheckingRadioButton.Name = "CheckingRadioButton";
            this.CheckingRadioButton.Size = new System.Drawing.Size(82, 20);
            this.CheckingRadioButton.TabIndex = 12;
            this.CheckingRadioButton.TabStop = true;
            this.CheckingRadioButton.Text = "Checking";
            this.CheckingRadioButton.UseVisualStyleBackColor = true;
            // 
            // AccountListBox
            // 
            this.AccountListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountListBox.FormattingEnabled = true;
            this.AccountListBox.ItemHeight = 16;
            this.AccountListBox.Location = new System.Drawing.Point(451, 44);
            this.AccountListBox.Name = "AccountListBox";
            this.AccountListBox.Size = new System.Drawing.Size(491, 196);
            this.AccountListBox.TabIndex = 13;
            // 
            // SortLabel
            // 
            this.SortLabel.AutoSize = true;
            this.SortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortLabel.Location = new System.Drawing.Point(448, 18);
            this.SortLabel.Name = "SortLabel";
            this.SortLabel.Size = new System.Drawing.Size(54, 16);
            this.SortLabel.TabIndex = 14;
            this.SortLabel.Text = "Sort By:";
            // 
            // SortComboBox
            // 
            this.SortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortComboBox.FormattingEnabled = true;
            this.SortComboBox.Items.AddRange(new object[] {
            "Account #",
            "Customer Name",
            "Balance(Desc)"});
            this.SortComboBox.Location = new System.Drawing.Point(508, 14);
            this.SortComboBox.Name = "SortComboBox";
            this.SortComboBox.Size = new System.Drawing.Size(121, 24);
            this.SortComboBox.TabIndex = 15;
            this.SortComboBox.SelectedIndexChanged += new System.EventHandler(this.SortComboBox_SelectedIndexChanged);
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterLabel.Location = new System.Drawing.Point(635, 18);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(40, 16);
            this.FilterLabel.TabIndex = 16;
            this.FilterLabel.Text = "Filter:";
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Items.AddRange(new object[] {
            "All",
            "Savings",
            "Checking"});
            this.FilterComboBox.Location = new System.Drawing.Point(681, 14);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(121, 24);
            this.FilterComboBox.TabIndex = 17;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(867, 246);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 18;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DepositFiveButton
            // 
            this.DepositFiveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepositFiveButton.Location = new System.Drawing.Point(451, 246);
            this.DepositFiveButton.Name = "DepositFiveButton";
            this.DepositFiveButton.Size = new System.Drawing.Size(113, 23);
            this.DepositFiveButton.TabIndex = 19;
            this.DepositFiveButton.Text = "Deposit $5";
            this.DepositFiveButton.UseVisualStyleBackColor = true;
            this.DepositFiveButton.Click += new System.EventHandler(this.DepositFiveButton_Click);
            // 
            // WithdrawFiveButton
            // 
            this.WithdrawFiveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WithdrawFiveButton.Location = new System.Drawing.Point(570, 246);
            this.WithdrawFiveButton.Name = "WithdrawFiveButton";
            this.WithdrawFiveButton.Size = new System.Drawing.Size(105, 23);
            this.WithdrawFiveButton.TabIndex = 20;
            this.WithdrawFiveButton.Text = "Withdraw $5";
            this.WithdrawFiveButton.UseVisualStyleBackColor = true;
            this.WithdrawFiveButton.Click += new System.EventHandler(this.WithdrawFiveButton_Click);
            // 
            // MonthlyInterestButton
            // 
            this.MonthlyInterestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyInterestButton.Location = new System.Drawing.Point(681, 246);
            this.MonthlyInterestButton.Name = "MonthlyInterestButton";
            this.MonthlyInterestButton.Size = new System.Drawing.Size(105, 23);
            this.MonthlyInterestButton.TabIndex = 21;
            this.MonthlyInterestButton.Text = "Monthly Intrst";
            this.MonthlyInterestButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.MonthlyInterestButton.UseVisualStyleBackColor = true;
            this.MonthlyInterestButton.Click += new System.EventHandler(this.MonthlyInterestButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 279);
            this.Controls.Add(this.MonthlyInterestButton);
            this.Controls.Add(this.WithdrawFiveButton);
            this.Controls.Add(this.DepositFiveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.FilterComboBox);
            this.Controls.Add(this.FilterLabel);
            this.Controls.Add(this.SortComboBox);
            this.Controls.Add(this.SortLabel);
            this.Controls.Add(this.AccountListBox);
            this.Controls.Add(this.CheckingRadioButton);
            this.Controls.Add(this.SavingsRadioButton);
            this.Controls.Add(this.AccontTypeLabel);
            this.Controls.Add(this.CurrencyTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BranchInfoLabel);
            this.Controls.Add(this.StartingBalanceTextBox);
            this.Controls.Add(this.NewAccountButton);
            this.Controls.Add(this.CustomerNameTextBox);
            this.Controls.Add(this.StartingAmountLabel);
            this.Controls.Add(this.CustomerNameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Teller UI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CustomerNameLabel;
        private System.Windows.Forms.Label StartingAmountLabel;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Button NewAccountButton;
        private System.Windows.Forms.TextBox StartingBalanceTextBox;
        private System.Windows.Forms.Label BranchInfoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CurrencyTypeComboBox;
        private System.Windows.Forms.Label AccontTypeLabel;
        private System.Windows.Forms.RadioButton SavingsRadioButton;
        private System.Windows.Forms.RadioButton CheckingRadioButton;
        private System.Windows.Forms.ListBox AccountListBox;
        private System.Windows.Forms.Label SortLabel;
        private System.Windows.Forms.ComboBox SortComboBox;
        private System.Windows.Forms.Label FilterLabel;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button DepositFiveButton;
        private System.Windows.Forms.Button WithdrawFiveButton;
        private System.Windows.Forms.Button MonthlyInterestButton;
    }
}