using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    internal class framSida
    {
        
        public static void forstaSida() 
        {
            Console.WriteLine("Välkomen till Richards saker");
            NavMenu.MainMenu();  
        }
        public static void adminSida()
        {
            Console.WriteLine("Välkomen till Richards saker");
            Admin.admin();
        }
    }
}
