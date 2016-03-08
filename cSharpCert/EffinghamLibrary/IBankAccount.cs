using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    //public interface IBankAccount
    //{
    //    int AccountNumber { get; }
    //    string CustomerName { get; set; }
    //    decimal Balance { get; }
    //    void Deposit(decimal amt);
    //    void Withdraw(decimal amt);
    //}

    public interface IBankAccountMultipleCurrency //: IBankAccount
    {
        void Deposit(decimal amount, CurrencyType currency = CurrencyType.Dollar);
        void Withdraw(decimal aout, CurrencyType currency = CurrencyType.Dollar);
    }
}
