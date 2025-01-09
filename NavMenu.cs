using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    internal class NavMenu
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
                    framSida.forstaSida();

                    break;
                case "b":
                    Categorier.Kategotier();

                    break;
                case "c":
                    LoggIn.loggaIn();

                    break;
                case "d":
                    aboutUs.omOss();

                    break;
                case "f":
                    Admin.admin();

                    break;
                default:
                    Console.WriteLine("Ogiltigt val"); 
                    break;
            }


        }
    }
}
