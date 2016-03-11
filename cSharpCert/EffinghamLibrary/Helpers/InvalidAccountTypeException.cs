using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    public class InvalidAccountTypeException:ApplicationException
    {
        public InvalidAccountTypeException() : base()
        {
        }

        public InvalidAccountTypeException(string message) : base(message)
        {
        }

        public InvalidAccountTypeException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
