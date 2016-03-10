using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EffinghamDAL;
using System.Data.Entity;

namespace DBBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Database...");

            Database.SetInitializer<DALContext>(new DALInitializer());
            using (DALContext db = new DALContext())
            {
                db.Database.Initialize(true);
            }

            Console.WriteLine("Done");
        }
    }
}
