using Microsoft.EntityFrameworkCore;
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
        public static async Task KontonAsync()
        {
            using (var db = new SQL.MyDbContext())
            {
                var profiler = await db.Profiler.ToListAsync(); 


                foreach (var profil in profiler)
                {
                    Console.WriteLine($"{profil.Id}\t{profil.forNamn}\t{profil.efterNamn}\t{profil.email}\t{profil.adress}\t{profil.Admin}");
                }
            }
        }
    }
}
