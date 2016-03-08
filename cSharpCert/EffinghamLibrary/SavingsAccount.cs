using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    public class SavingsAccount : BankAccount, IInterestBearing
    {
        #region Fields and Properties

        public static decimal InterestRate { get; }
        public static decimal MonthlyRate { get; }

        #endregion Fields and Properties

        #region Constructors

        static SavingsAccount()
        {
            InterestRate = .03m;
            MonthlyRate = InterestRate / 12;
        }
        public SavingsAccount(decimal startingAmount, string customerName, CurrencyType currency = CurrencyType.Dollar) 
            : base(startingAmount, customerName, currency)
        {
            
        }

        internal SavingsAccount(SerializationInfo info, StreamingContext context)
            : base(info,context)
        {

        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Deposits monthly interest into the savings account
        /// </summary>
        public void AddMonthlyInterest()
        {
            lock (accountLock)
            {
                this.Deposit(Balance * SavingsAccount.MonthlyRate);
            }
        }
        #endregion Methods

    }
}
