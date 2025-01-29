using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbshopen.SQL;

namespace Webbshopen
{
    internal class LoggIn
    {
        public static void Meny() { NavMenu.LoggaInMeny(); }

        public static void loggaIn()
        {
            using (var db = new SQL.MyDbContext())
            {
                Console.WriteLine("Email addres: ");
                string emailAddress = Console.ReadLine();
                bool foundProfile = false;

                foreach (var Profiler in db.Profiler)
                {
                    if (emailAddress == Profiler.email)
                    {
                        foundProfile = true;

                        Console.WriteLine("Lössenord: ");
                        string lossenOrd = Console.ReadLine();

                        if (lossenOrd != Profiler.losenord)
                        {
                            Console.WriteLine("Fel lösenord eller email");
                            Console.ReadKey();
                            LoggIn.loggaIn();
                        }
                        else
                        {
                            
                            if (Profiler.Admin == true)
                            {
                                framSida.adminSida();
                            }
                            else 
                            {
                                framSida.forstaSida();
                            }
                            return; 
                        }
                    }
                }

                if (!foundProfile)
                {
                    Console.WriteLine("Email adressen finns ej registrerat");
                    Thread.Sleep(2000);
                    Console.Clear();
                    NavMenu.LoggaInMeny();
                }
            }
        }

        public static void regristrera() 
        {
            
            using (var db = new SQL.MyDbContext())
            {
                Console.WriteLine("Skriv in ditt Förnamn: ");
                string fN = Console.ReadLine();
                Console.WriteLine("Förnamn: " + fN);
                Console.WriteLine("skriv in ditt Efternamn: ");
                string eN = Console.ReadLine();
                Console.WriteLine("Efternamn: " + eN);
                Console.WriteLine("skriv in din Adress: ");
                string aD = Console.ReadLine();
                Console.WriteLine("Adress: " + aD);
                Console.WriteLine("skriv in din Email");
                string eM = Console.ReadLine();
                Console.WriteLine("Email: " + eM);
                Console.WriteLine("Skriv in ett Lössenord: ");
                string lO = Console.ReadLine();
                db.Profiler.Add(new SQL.Profiler { Admin = false, forNamn = fN, efterNamn = eN, adress = aD, email = eM, losenord = lO});
                db.SaveChanges();
            }
        }
    }
}
