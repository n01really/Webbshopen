using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    internal class Inventarie
    {
        public static void inventarie()
        {
            using (var db = new SQL.MyDbContext())
            {
                foreach (var Products in db.Products)
                {
                    Console.WriteLine(Products.Id + "\t" + Products.Name + "\t" + Products.KategoriId + "\t" + Products.Antal + "\t" + 
                        Products.pris + "\t" + Products.levrantör);
                }
            }
        }
    }
}
