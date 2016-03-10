using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    /// <summary>
    /// IVault interface should implement singleton pattern
    /// </summary>
    public interface IVault : IDisposable
    {

        //Read Data
        Task<IEnumerable<BankAccount>> GetAccountsAsync();
        IEnumerable<BankAccount> GetAccounts();
        BankAccount GetAccount(int accountNumber);

        //Write Data
        void AddAccount(BankAccount acct, bool delayWrite = false);
        void UpdateAccount(BankAccount acct, bool delayWrite = false);
        void Deleteaccount(BankAccount acct, bool delayWrite = false);
        void FlushAccounts();
    }
}
