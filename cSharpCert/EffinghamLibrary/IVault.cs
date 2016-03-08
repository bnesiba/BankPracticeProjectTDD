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
        IEnumerable<IBankAccountMultipleCurrency> GetAccounts();
        IBankAccountMultipleCurrency GetAccount(int accountNumber);

        //Write Data
        void AddAccount(IBankAccountMultipleCurrency acct, bool delayWrite = false);
        void UpdateAccount(IBankAccountMultipleCurrency acct, bool delayWrite = false);
        void Deleteaccount(IBankAccountMultipleCurrency acct, bool delayWrite = false);
        void FlushAccounts();
    }
}
