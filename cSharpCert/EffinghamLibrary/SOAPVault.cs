using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    public class SOAPVault : IVault
    {
        #region IVault Methods
        public IEnumerable<IBankAccountMultipleCurrency> GetAccount()
        {
            throw new NotImplementedException();
        }

        public IBankAccountMultipleCurrency GetAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public void AddAccount(IBankAccountMultipleCurrency acct, bool delayWrite = false)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(IBankAccountMultipleCurrency acct, bool delayWrite = false)
        {
            throw new NotImplementedException();
        }

        public void Deleteaccount(IBankAccountMultipleCurrency acct, bool delayWrite = false)
        {
            throw new NotImplementedException();
        }

        public void FlushAccounts()
        {
            throw new NotImplementedException();
        }
        #endregion IVault Methods

        #region IDisposable Support
        private bool IsDisposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                IsDisposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~SOAPVault()
        {
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
        private static SOAPVault vault = null;

        public static SOAPVault Instance
        {
            get
            {
                if (vault == null || vault.IsDisposed)
                {
                    vault = new SOAPVault();
                }
                return vault;
            }
        }
        private SOAPVault()
        {
            
        }
        #endregion Singleton
    }
}
