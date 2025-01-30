using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
                 var profiler =  db.Profiler.ToList(); 


                foreach (var profil in profiler)
                {
                    Console.WriteLine($"{profil.Id}\t{profil.forNamn}\t{profil.efterNamn}\t{profil.email}\t{profil.adress}\t{profil.Admin}");
                }
            }
        }
    }
}
