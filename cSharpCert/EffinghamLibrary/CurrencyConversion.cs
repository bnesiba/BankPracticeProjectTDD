using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffinghamLibrary
{
    /// <summary>
    /// Class to manage currency conversions
    /// </summary>
    public static class CurrencyConversion
    {
        private static Dictionary<short, decimal> conversionValues = new Dictionary<short, decimal>()
                                                              {
                                                                  {(short)CurrencyType.Dollar, 1},//dollars
                                                                  {(short)CurrencyType.Peso, 10},//pesos
                                                                  {(short)CurrencyType.Yen, 100}//yen

                                                              };

        public static decimal Convert(decimal amt, CurrencyType currency)
        {
            if (conversionValues.ContainsKey((short)currency))
            {
                return amt / (conversionValues[(short)currency]);
            }
            else
            {
                throw new ApplicationException("Invalid Currency Type");
            }

        }
    }
}
