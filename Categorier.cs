using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    internal class Categorier
    {
        public static void Kategotier()
        {

            using (var db = new SQL.MyDbContext()) 
            {
                foreach (var Kategorier in db.Kategorier)
                {
                    Console.WriteLine(Kategorier.Id + "\t" + Kategorier.Name);
                    Console.WriteLine("------------------------");
                }
            }
        }
    }
}
