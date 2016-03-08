using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EffinghamLibrary;

namespace EffinghamLibraryTests
{
    [Serializable]
    internal class TestBankAccount : BankAccount
    {
        public TestBankAccount(decimal startingAmt, string customerName, CurrencyType currency = CurrencyType.Dollar)
            : base(startingAmt, customerName, currency)
        {
            
        }

        internal TestBankAccount(SerializationInfo info, StreamingContext context) 
            : base(info,context)
        {
            
        }
    }
}
