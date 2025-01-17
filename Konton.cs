using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbshopen.Migrations;

namespace Webbshopen
{
    internal class Konton
    {
        public static void konton()
        { 
            using (var db = new SQL.MyDbContext()) 
            {
                foreach(var Profiler in db.Profiler)
                {
                    Console.WriteLine(Profiler.Id + "\t" + Profiler.forNamn + "\t" + Profiler.efterNamn + "\t" + Profiler.email + "\t" + 
                        Profiler.adress + "\t" + Profiler.Admin);
                }
            }
        }
    }
}
