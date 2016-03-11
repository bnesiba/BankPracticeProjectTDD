using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EffinghamDAL;
using System.Data.Entity;

namespace EffinghamLibrary
{
    public class EFVault : IVault
    {
        #region Fields and Properties

        private DALContext db;
        private object fileLock = new object();
        #endregion Fields and Properties

        #region IVault Methods
        public void AddAccount(BankAccount acct, bool delayWrite = false)
        {
            db.DalAccounts.Add(acct.ToDALAccount());
            if (!delayWrite)
            {
                db.SaveChanges();
            }
        }

        public void Deleteaccount(BankAccount acct, bool delayWrite = false)
        {
            db.DalAccounts.Remove(acct.ToDALAccount());

            if (!delayWrite)
            {
                db.SaveChanges();
            }
        }

        public void FlushAccounts()
        {
            db.SaveChanges();
        }

        public BankAccount GetAccount(int accountNumber)
        {
            DALAccount da;
            da = db.DalAccounts.SingleOrDefault(x => x.AccountNumber == accountNumber);
            
            return da?.ToBankAccount();
        }

        public IEnumerable<BankAccount> GetAccounts()
        {
            List<DALAccount> DALaccounts;
            DALaccounts = db.DalAccounts.ToList();
            return DALaccounts.ConvertAll<BankAccount>(x => x.ToBankAccount());
        }

        public Task<IEnumerable<BankAccount>> GetAccountsAsync()
        {
            return Task.Run(() => GetAccounts());
        }

        public void UpdateAccount(BankAccount acct, bool delayWrite = false)
        {
            DALAccount da;
            da = db.DalAccounts.Single(x => x.AccountNumber == acct.AccountNumber);
            da.Balance = acct.Balance;
            da.CustomerName = acct.CustomerName;
            if (!delayWrite)
            {
                db.SaveChanges();
            }

        }
        #endregion IVaultMethods

        #region IDisposable Support
        private bool IsDisposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    db.Dispose();
                }
                db.SaveChanges();
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                IsDisposed = true;
            }
        }

        ~EFVault()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Singleton

        public static EFVault vault = null;
        public static EFVault instance
        {
            get
            {
                if (vault == null || vault.IsDisposed)
                {
                    vault = new EFVault();
                }
                return vault;
            }
        }

        private EFVault()
        {
            db = new DALContext();
        }
        #endregion Singleton
    }
}
