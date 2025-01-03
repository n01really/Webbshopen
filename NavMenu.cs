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
            int mainMenu = 0;//placeholder
            switch (mainMenu)
            {
                case 0:
                    mainMenu = 0;
                    break;
                case 1:
                    mainMenu = 1;
                    break;
                case 2:
                    mainMenu = 2;
                    break;
                case 3:
                    mainMenu = 3;
                    break;//placeholders
            }

            Console.WriteLine("menu");
            Console.WriteLine();
            Console.WriteLine("0. hem  1. Kategorier 2. logga in 3. om oss");
        }
    }
}
