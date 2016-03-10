using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EffinghamDAL
{
    public class DALContext : DbContext
    {
        //public DALContext() : base("ConnectionStringName")
        //{
            
        //}
        public DbSet<DALAccount> DalAccounts { get; set; }
    }
}
