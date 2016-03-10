using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EffinghamDAL
{
    public class DALInitializer:DropCreateDatabaseAlways<DALContext>
    {
        protected override void Seed(DALContext context)
        {
            DALAccount da = new DALAccount()
                            {
                                AccountNumber = 1,
                                CustomerName = "test",
                                Balance = 100,
                                AccountType = "C"
                            };
            context.DalAccounts.Add(da);

            da = new DALAccount()
                 {
                AccountNumber = 1,
                CustomerName = "test1",
                Balance = 10000,
                AccountType = "S"
                 };
            context.DalAccounts.Add(da);
            context.SaveChanges();
        }
    }
}
