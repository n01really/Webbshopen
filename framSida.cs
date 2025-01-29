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
            Console.WriteLine("---------------------------");
            using (var context = new SQL.MyDbContext())
            {
                var productService = new ProductSida(context);
                var topProducts = productService.GetTopThreeProductsByQuantity();
                Console.WriteLine("Rekomenderade Produkter");
                Console.WriteLine("---------------------------");
                foreach (var product in topProducts)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine($"{product.Name}, Pris: {product.Pris}KR");
                    Console.WriteLine("---------------------------");
                }
            }
            NavMenu.MainMenu();
            Console.WriteLine("---------------------------");


        }
        public static void adminSida()
        {
            Console.WriteLine("Välkomen till Richards saker");
            Console.WriteLine("---------------------------");
            using (var context = new SQL.MyDbContext())
            {
                var productService = new ProductSida(context);
                var topProducts = productService.GetTopThreeProductsByQuantity();
                Console.WriteLine("Rekomenderade Produkter");
                Console.WriteLine("---------------------------");
                foreach (var product in topProducts)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine($"{product.Name}, Pris: {product.Pris}KR");
                    Console.WriteLine("---------------------------");
                }

                Admin.admin();
            Console.WriteLine("---------------------------");

           
            }
        }
    }
}
