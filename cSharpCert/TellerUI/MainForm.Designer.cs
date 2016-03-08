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
            this.SuspendLayout();
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameLabel.Location = new System.Drawing.Point(12, 43);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(108, 16);
            this.CustomerNameLabel.TabIndex = 0;
            this.CustomerNameLabel.Text = "Customer Name:";
            // 
            // StartingAmountLabel
            // 
            this.StartingAmountLabel.AutoSize = true;
            this.StartingAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingAmountLabel.Location = new System.Drawing.Point(11, 71);
            this.StartingAmountLabel.Name = "StartingAmountLabel";
            this.StartingAmountLabel.Size = new System.Drawing.Size(109, 16);
            this.StartingAmountLabel.TabIndex = 1;
            this.StartingAmountLabel.Text = "Starting Balance:";
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameTextBox.Location = new System.Drawing.Point(126, 40);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(156, 22);
            this.CustomerNameTextBox.TabIndex = 2;
            // 
            // NewAccountButton
            // 
            this.NewAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewAccountButton.Location = new System.Drawing.Point(169, 207);
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
            this.StartingBalanceTextBox.Location = new System.Drawing.Point(126, 68);
            this.StartingBalanceTextBox.Name = "StartingBalanceTextBox";
            this.StartingBalanceTextBox.Size = new System.Drawing.Size(156, 22);
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
            this.label1.Location = new System.Drawing.Point(21, 148);
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
            this.CurrencyTypeComboBox.Location = new System.Drawing.Point(126, 145);
            this.CurrencyTypeComboBox.Name = "CurrencyTypeComboBox";
            this.CurrencyTypeComboBox.Size = new System.Drawing.Size(156, 24);
            this.CurrencyTypeComboBox.TabIndex = 8;
            // 
            // AccontTypeLabel
            // 
            this.AccontTypeLabel.AutoSize = true;
            this.AccontTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccontTypeLabel.Location = new System.Drawing.Point(21, 97);
            this.AccontTypeLabel.Name = "AccontTypeLabel";
            this.AccontTypeLabel.Size = new System.Drawing.Size(94, 16);
            this.AccontTypeLabel.TabIndex = 9;
            this.AccontTypeLabel.Text = "Account Type:";
            // 
            // SavingsRadioButton
            // 
            this.SavingsRadioButton.AutoSize = true;
            this.SavingsRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavingsRadioButton.Location = new System.Drawing.Point(126, 119);
            this.SavingsRadioButton.Name = "SavingsRadioButton";
            this.SavingsRadioButton.Size = new System.Drawing.Size(75, 20);
            this.SavingsRadioButton.TabIndex = 11;
            this.SavingsRadioButton.TabStop = true;
            this.SavingsRadioButton.Text = "Savings";
            this.SavingsRadioButton.UseVisualStyleBackColor = true;
            // 
            // CheckingRadioButton
            // 
            this.CheckingRadioButton.AutoSize = true;
            this.CheckingRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckingRadioButton.Location = new System.Drawing.Point(126, 93);
            this.CheckingRadioButton.Name = "CheckingRadioButton";
            this.CheckingRadioButton.Size = new System.Drawing.Size(82, 20);
            this.CheckingRadioButton.TabIndex = 12;
            this.CheckingRadioButton.TabStop = true;
            this.CheckingRadioButton.Text = "Checking";
            this.CheckingRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 284);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Teller UI";
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
    }
}