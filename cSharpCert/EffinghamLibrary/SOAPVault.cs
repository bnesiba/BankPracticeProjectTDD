﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    public class SOAPVault : IVault
    {
        #region Fields and Properties

        private const string DATAFILE = @"Accounts.dat";
        private List<BankAccount> accounts;
        private bool isFlushed = false;
        private object fileLock = new object();

        private ReaderWriterLockSlim localLock = new ReaderWriterLockSlim();

        #endregion Fields and Properties
        #region IVault Methods
        /// <summary>
        /// Get accounts from vault
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetAccounts()
        {
            localLock.EnterReadLock();
            try
            {
                return accounts.AsEnumerable();
            }
            finally
            {
                if(localLock.IsReadLockHeld) localLock.ExitReadLock();
            }
            
        }

        /// <summary>
        /// Get account by account number
        /// </summary>
        /// <param name="accountNumber">Account to retrieve</param>
        /// <returns>BankAccount associated with accountNumber</returns>
        public BankAccount GetAccount(int accountNumber)
        {
            localLock.EnterReadLock();
            try
            {             
                return accounts.SingleOrDefault(x => x.AccountNumber == accountNumber);
            }
            finally
            {
                if (localLock.IsReadLockHeld) localLock.ExitReadLock();
            }
            
        }

        /// <summary>
        /// Add BankAccount to vault
        /// </summary>
        /// <param name="acct">BankAccount to add</param>
        /// <param name="delayWrite">Delay writing for efficiency when writing large number of accounts</param>
        public void AddAccount(BankAccount acct, bool delayWrite = false)
        {
            localLock.EnterWriteLock();
            try
            {
                accounts.Add(acct);
                isFlushed = false;
            }
            finally
            {
                if (localLock.IsWriteLockHeld) localLock.ExitWriteLock();
            }

            if (!delayWrite)
            {
                   //TODO: write accounts to disk
            }
        }

        /// <summary>
        /// Update an account in the Vault
        /// </summary>
        /// <param name="acct">Account to update</param>
        /// <param name="delayWrite">Delay writing for efficiency when writing large number of accounts</param>
        public void UpdateAccount(BankAccount acct, bool delayWrite = false)
        {
            localLock.EnterUpgradeableReadLock();
            try
            {
                int i = accounts.FindIndex(x => x.AccountNumber == acct.AccountNumber);
                if (i >= 0)
                {
                    localLock.EnterWriteLock();
                    accounts[i] = acct;
                    isFlushed = false;
                }
                else
                {
                    throw new ApplicationException(String.Format("Update Failed\nAccount {0} not found", acct.AccountNumber));
                }
            }
            finally
            {
                if (localLock.IsWriteLockHeld) localLock.ExitWriteLock();
                if (localLock.IsUpgradeableReadLockHeld) localLock.ExitUpgradeableReadLock();
            }
            
            if (!delayWrite)
            {
                //TODO: write accounts to list
            }
        }
        /// <summary>
        /// Delete a BankAccount from the vault
        /// </summary>
        /// <param name="acct">BankAccount to delete</param>
        /// <param name="delayWrite">Delay writing for efficiency when writing large number of accounts</param>
        public void Deleteaccount(BankAccount acct, bool delayWrite = false)
        {
            localLock.EnterUpgradeableReadLock();
            try
            {
                int i = accounts.FindIndex(x => x.AccountNumber == acct.AccountNumber);
                if (i >= 0)
                {
                    localLock.EnterWriteLock();
                    accounts.RemoveAt(i);
                    isFlushed = false;
                }
                else
                {
                    throw new ApplicationException(String.Format("Delete Failed\nAccount {0} not found", acct.AccountNumber));
                }
            }
            finally
            {
                if (localLock.IsWriteLockHeld) localLock.ExitWriteLock();
                if (localLock.IsUpgradeableReadLockHeld) localLock.ExitUpgradeableReadLock();
            }

            if (!delayWrite)
            {
                //TODO: write accounts to list
            }
        }

        /// <summary>
        /// Write all data to disk
        /// </summary>
        public void FlushAccounts()
        {
            throw new NotImplementedException();
        }
        #endregion IVault Methods

        #region ReadWrite Methods

        private void ReadAccounts()
        {
            
        }

        private void WriteAccounts()
        {
            ArrayList tempList;
            localLock.EnterReadLock();
            try
            {
                tempList = new ArrayList(accounts);
            }
            finally
            {
                if(localLock.IsReadLockHeld) localLock.ExitReadLock();
            }
            using (FileStream outFile = File.OpenWrite(DATAFILE))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(outFile, tempList);
            }
            
            
        }
        #endregion ReadWrite Methods


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
            accounts = new List<BankAccount>();
        }
        #endregion Singleton
    }
}