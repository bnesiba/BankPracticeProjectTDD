using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EffinghamDAL;

namespace EffinghamLibrary
{
    internal static class Extensions
    {
        /// <summary>
        /// Converts a DALAccount into a BankAccount Buisiness Object
        /// </summary>
        /// <param name="da">DALAccount to convert</param>
        /// <returns>BankAccount object constructed from DALAccount info</returns>
        internal static BankAccount ToBankAccount(this DALAccount da)
        {
            BankAccount ba;

            if (da.AccountType == "C")
            {
                ba = new CheckingAccount(da.AccountNumber, da.CustomerName, da.Balance);
            }else if (da.AccountType == "S")
            {
                ba = new SavingsAccount(da.AccountNumber, da.CustomerName, da.Balance);
            }
            else
            {
                throw new InvalidAccountTypeException($"Invalid Bank Account Type: {da.AccountType}");
            }
            return ba;
        }

        /// <summary>
        /// Converts BankAccount object into a DALAccount for db integration
        /// </summary>
        /// <param name="ba">BankAccount to convert</param>
        /// <returns>DALAccount object</returns>
        internal static DALAccount ToDALAccount(this BankAccount ba)
        {
            DALAccount dal = new DALAccount()
                             {
                                 AccountNumber = ba.AccountNumber,
                                 CustomerName = ba.CustomerName,
                                 Balance = ba.Balance,
                                 AccountType = (ba is CheckingAccount) ? "C" : "S"
                             };

            return dal;
        }
    }
}
