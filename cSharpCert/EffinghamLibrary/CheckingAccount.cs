using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    [Serializable]
    public class CheckingAccount : BankAccount
    {
        #region Fields and Properties
        public readonly decimal overDraft;
        public override decimal Balance
        {
            get
            {
                lock (accountLock)
                {
                    return base.Balance;
                }
            }
            protected set
            {
                lock (accountLock)
                {
                    if (value >= overDraft*-1)
                    {
                        base.balance = value;
                    }
                    else
                    {
                        throw new ApplicationException("Balance cannot be less than overdraft amount");
                    }
                }
            }
        }
        #endregion Fields and Properties

        #region Constructors

        public CheckingAccount(decimal startingAmount, string customerName, CurrencyType currency = CurrencyType.Dollar, decimal overDraftAmt = 50m)
            : base(startingAmount, customerName, currency)
        {
            overDraft = overDraftAmt;
        }

        internal CheckingAccount(SerializationInfo info, StreamingContext context)
            : base(info,context)
        {
            
        }
        #endregion Constructors

        #region Methods

        public override void Withdraw(decimal amt, CurrencyType currency = CurrencyType.Dollar)
        {

            lock (accountLock)
            {
                amt = CurrencyConversion.Convert(amt, currency);
                if (amt != 0 && Balance - amt > overDraft*-1)
                {
                    Balance -= amt;
                }
                else
                {
                    throw new ApplicationException("Cannot withdraw past overdraft");
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + " Type: Checking";
        }
        #endregion Methods
    }
}
