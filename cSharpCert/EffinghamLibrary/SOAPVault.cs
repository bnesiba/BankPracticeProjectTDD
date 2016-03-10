using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Cryptography;
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

        public Task<IEnumerable<BankAccount>> GetAccountsAsync()
        {
            return new Task<IEnumerable<BankAccount>>(() =>GetAccounts());
        }

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
                WriteAccounts();
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
                WriteAccounts();
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
                WriteAccounts();
            }
        }

        /// <summary>
        /// Write all data to disk
        /// </summary>
        public void FlushAccounts()
        {
            WriteAccounts();
        }
        #endregion IVault Methods

        #region ReadWrite Methods
        /// <summary>
        /// Retrieve Accounts from file
        /// </summary>
        private void ReadAccounts()
        {
            ArrayList tempList;

            localLock.EnterWriteLock();
            try
            {
                if (!File.Exists(DATAFILE))
                {
                    accounts = new List<BankAccount>();
                    isFlushed = true;
                    return;
                }
            }
            finally
            {
                if (localLock.IsWriteLockHeld) localLock.ExitWriteLock();
            }

            //Decrypt and read
            string encryptionKey = ConfigurationManager.AppSettings.Get("encryptionKey");
            byte[] encryptionSalt = Encoding.Unicode.GetBytes(ConfigurationManager.AppSettings.Get("encryptionSalt"));

            //Note: Rfc2898DeriveBytes uses SHA1 which is not considered secure against well funded opponents.
            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(encryptionKey, encryptionSalt))
            {
                using (AesManaged aes = new AesManaged())
                {
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = rfc.GetBytes(aes.KeySize / 8);
                    aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                    using (ICryptoTransform decryptor = aes.CreateDecryptor())
                    {
                        lock (fileLock)
                        {
                            using (FileStream fs = new FileStream(DATAFILE, FileMode.OpenOrCreate))
                            {
                                if (fs.Length == 0)
                                {
                                    localLock.EnterWriteLock();
                                    try
                                    {
                                        accounts = new List<BankAccount>();
                                        isFlushed = true;
                                    }
                                    finally
                                    {
                                        if (localLock.IsWriteLockHeld) localLock.ExitWriteLock();
                                    }
                                    return;
                                }

                                using (CryptoStream cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                                {
                                    using (GZipStream zs = new GZipStream(cs, CompressionMode.Decompress))
                                    {
                                        SoapFormatter formatter = new SoapFormatter();
                                        tempList = formatter.Deserialize(zs) as ArrayList;

                                        localLock.EnterWriteLock();
                                        try
                                        {
                                            accounts = tempList.Cast<BankAccount>().ToList();
                                        }
                                        finally
                                        {
                                            if (localLock.IsWriteLockHeld) localLock.ExitWriteLock();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Write BankAccounts to File
        /// </summary>
        private void WriteAccounts()
        {
            ArrayList tempList;
            localLock.EnterReadLock();
            try
            {
                if (isFlushed)
                {
                    return;
                }
                tempList = new ArrayList(accounts);
            }
            finally
            {
                if(localLock.IsReadLockHeld) localLock.ExitReadLock();
            }

            //Encrypted Write
            string encryptionKey = ConfigurationManager.AppSettings.Get("encryptionKey");
            byte[] encryptionSalt = Encoding.Unicode.GetBytes(ConfigurationManager.AppSettings.Get("encryptionSalt"));

            //Note: Rfc2898DeriveBytes uses SHA1 which is not considered secure against well funded opponents.
            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(encryptionKey, encryptionSalt))
            {
                using (AesManaged aes = new AesManaged())
                {
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = rfc.GetBytes(aes.KeySize / 8);
                    aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    {
                        lock (fileLock)
                        {
                            using (FileStream fs = File.OpenWrite(DATAFILE))
                            {
                                using (CryptoStream cs = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                                {
                                    using (GZipStream zs = new GZipStream(cs,CompressionLevel.Fastest,true))
                                    {
                                        SoapFormatter formatter = new SoapFormatter();
                                        formatter.Serialize(zs, tempList);
                                        localLock.EnterWriteLock();
                                        isFlushed = true;
                                        localLock.ExitWriteLock();
                                    }
                                }
                            }
                        }
                    }
                }
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
                WriteAccounts();
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
            ReadAccounts();
        }
        #endregion Singleton
    }
}
