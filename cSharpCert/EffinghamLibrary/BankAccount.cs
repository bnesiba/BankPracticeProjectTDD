using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
   [Serializable]
    public abstract class BankAccount : /*IBankAccount,*/ IBankAccountMultipleCurrency, ISerializable
    {
        #region Fields and Properties
        //static
        private static int nextAccountNumber;
        protected static readonly object staticBankAccountLock = new object();

        //constants
       private const string acctNumStr = "AccountNumber";
       private const string custNameStr = "CustomerName";
       private const string balNameStr = "Balance";
        //fields
        private readonly int accountNumber;
        protected readonly object accountLock = new object();
        private string customerName;
        protected decimal balance;

        //Properties
        public virtual decimal Balance
        {
            get
            {
                lock (accountLock)
                {
                     return balance;
                }
            }
            protected set
            {
                lock (accountLock)
                {
                    if (value >= 0)
                    {
                        balance = value;
                    }
                    else
                    {
                        throw new ApplicationException("Balance must be greater than or equal to 0");
                    }
                }  
            }
        }
        public string CustomerName
        {
            get
            {
                lock (accountLock)
                {
                    return customerName;
                }
            }

            set
            {
                lock (accountLock)
                {
                    if (value.Trim().Length >= 2)
                    {
                        customerName = value.Trim();
                    }
                    else
                    {
                        throw new ApplicationException("Customer name must be 2 or more characters");
                    }
                }
            }
        }
        public int AccountNumber
        {
            get
            {
                lock (accountLock)
                {
                    return accountNumber;
                }
            }
        }

        #endregion Fields and Properties

        #region Constructors
        /// <summary>
        /// Static constructor to set nextAccountNumber value.
        /// Would get newest # from DB or wherever
        /// </summary>
        static BankAccount()
        {
            nextAccountNumber = 1; // would get recent value from storage
        }

        /// <summary>
        /// Constructor for creating a new BankAccount
        /// </summary>
        /// <param name="amt">Starting Balance for the Account. Should be >= 0</param>
        /// <param name="customer">Customer name on Account. Must be >2 characters</param>
        /// <param name="currency">Type of currency used for this account</param>
        public BankAccount(decimal amt, string customer, CurrencyType currency = CurrencyType.Dollar)
        {
            lock (staticBankAccountLock)
            {
                lock (accountLock)
                {
                    accountNumber = BankAccount.nextAccountNumber++;
                }
                
            }
            
            lock (accountLock)
            {
                this.Balance = 0m;
            }
            this.CustomerName = customer;
            this.Deposit(amt,currency);
        }

        /// <summary>
        /// Internal Constructor used for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
       protected internal BankAccount(SerializationInfo info, StreamingContext context)
       {
            lock (staticBankAccountLock)
            {
                lock (accountLock)
                {
                    accountNumber = info.GetInt32("AccountNumber");
                    CustomerName = info.GetString("CustomerName");
                    Balance = info.GetDecimal("Balance");
                }
                if (BankAccount.nextAccountNumber <= accountNumber)
                {
                    BankAccount.nextAccountNumber = accountNumber + 1;
                }
            }
            
       }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Deposit amount into account
        /// </summary>
        /// <param name="amt">Amount to deposit. Must be > 0</param>
        /// <param name="currency">Type of currency to deposit</param>
        public void Deposit(decimal amt, CurrencyType currency = CurrencyType.Dollar)
        {
            lock (accountLock)
            {
                if (amt > 0)
                {
                    Balance += CurrencyConversion.Convert(amt, currency);

                }
                else
                {
                    throw new ApplicationException("Deposit amount must be greater than 0");
                }
            }

        }


        /// <summary>
        /// Withdraw amount from account.
        /// </summary>
        /// <param name="amt">Amount to withdraw. Must be > 0. Account Must have sufficient Balance</param>
        public virtual void Withdraw(decimal amt, CurrencyType currency = CurrencyType.Dollar)
        {
            lock (accountLock)
            {
                amt = CurrencyConversion.Convert(amt, currency);
                if (Balance >= amt && amt > 0)
                {
                    Balance -= amt;
                }
                else if (Balance < amt)
                {
                    throw new ApplicationException("Insuficcient funds for withdrawl");
                }
                else
                {
                    throw new ApplicationException("Withdrawl amount must be greater than 0");
                }
            }

        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(acctNumStr, this.AccountNumber);
            info.AddValue(custNameStr, this.CustomerName);
            info.AddValue(balNameStr, this.Balance);
        }
        #endregion Methods
    }
}
