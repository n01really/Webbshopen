using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    public class NavMenu
    {
        
       public static void MainMenu()
       {
            Console.WriteLine("meny");
            Console.WriteLine();
            Console.WriteLine("a. hem  b. Kategorier c. logga in d. om oss");

            string mainMenu = Console.ReadLine();
            switch (mainMenu)
            {
                case "a":
                    Console.Clear();
                    framSida.forstaSida();
                    break;
                case "b":
                    Console.Clear();
                    Categorier.Kategotier();
                    
                    break;
                case "c":
                    Console.Clear();
                    LoggIn.Meny();
                    break;
                case "d":
                    Console.Clear();
                    aboutUs.omOss();

                    break;
                case "f":
                    Admin.admin();

                    break;
                default:
                    Console.WriteLine("Ogiltigt val"); 

                    return;
            }


       }

        public static void LoggaInMeny()
        {
            Console.WriteLine("l. Logga in,   r. Regristrera dig,   f.Hem");
            string loggInMeny = Console.ReadLine();
            switch (loggInMeny)
            {
                case "l":
                    Console.Clear();
                    LoggIn.loggaIn();
                    break;
                case "r":
                    Console.Clear();
                    LoggIn.regristrera();
                    break;
                case "f":
                    Console.Clear();
                    framSida.forstaSida();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("fel inmatning");
                    Thread.Sleep(2000);
                    LoggIn.Meny();
                    break;
            }
        }

    }
}
