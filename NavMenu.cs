using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbshopen.SQL;

namespace Webbshopen
{
    public class NavMenu
    {

        public static void MainMenu()
        {
            Console.WriteLine("meny");
            Console.WriteLine();
            Console.WriteLine("a. hem  b. Kategorier c. logga in d. Kundvagn e.Sök");

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
                    ShowCart();
                    break;
                case "e":
                    Console.Clear();
                    Search.search();
                    break;
                case "f":
                    Console.Clear();
                    Admin.admin();
                    break;


                default:
                    Console.WriteLine("Ogiltigt val");
                    framSida.forstaSida();
                    break;
            }


        }

        public static void LoggaInMeny()
        {
            Console.WriteLine("a. Logga in,   b. Regristrera dig,   c.Hem");
            string loggInMeny = Console.ReadLine();
            switch (loggInMeny)
            {
                case "a":
                    Console.Clear();
                    LoggIn.loggaIn();
                    break;
                case "b":
                    Console.Clear();
                    LoggIn.regristrera();
                    break;
                case "c":
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

        public static void catmeny()
        {
            using (var context = new SQL.MyDbContext())
            {
                var service = new ItemService(context);



                while (true)
                {
                    Console.WriteLine("vilken kategori?: ");
                    string input = Console.ReadLine();


                    if (int.TryParse(input, out int foreignKeyId))
                    {
                        List<Products> items = service.GetItemsByForeignKey(foreignKeyId);

                        if (items.Count > 0)
                        {
                            Console.WriteLine($"Föremål med ForeignKeyId {foreignKeyId}:");
                            foreach (var item in items)
                            {
                                Console.WriteLine($" {item.Id}, {item.Name} {item.Pris}");
                            }
                            productsnav();
                        }
                        else
                        {
                            Console.WriteLine($"Inga föremål hittades för ForeignKeyId {foreignKeyId}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt nummer, försök igen.");
                    }
                }
            }
        }
        public static void productsnav()
        {
            using var context = new SQL.MyDbContext();
            var productRepo = new ProductSida(context);
            while (true)
            {
                Console.Write("Vilken produkt vill du se eller vill du tillbacka?: ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "tillbacka")
                {
                    Console.Clear();
                    framSida.forstaSida();
                }

                if (int.TryParse(input, out int productId))
                {
                    var product = productRepo.GetProductById(productId);

                    if (product != null)
                    {
                        Console.WriteLine($"\nProduct Details:");
                        Console.WriteLine($"ID: {product.Id}");
                        Console.WriteLine($"Namn: {product.Name}");
                        Console.WriteLine($"kategori: {product.Kategorier?.Name}");
                        Console.WriteLine($"Pris: {product.Pris}");
                        Console.WriteLine($"antal: {product.Antal}");
                        Console.WriteLine($"Description: {product.Description}");
                        Console.WriteLine($"levrantör: {product.Levrantör}\n");

                        Console.Write("vill du lägga till i varukorgen  (j/n): ");
                        string choice = Console.ReadLine()?.ToLower();

                        if (choice == "j")
                        {
                            Console.Write("Hur många: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                if (productRepo.AddToCart(productId, quantity))
                                {
                                    Console.WriteLine("Produkt tillagd.\n");
                                }
                                else
                                {
                                    Console.WriteLine("kunde ej lägga till produgt kontakta kund tjänst via GoFukcYourSelf@RichardsSaker.se.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ogiltigt antal.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("återvänder till start sida.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Produkt ej hittad.\n");
                    }
                }
                else
                {
                    Console.WriteLine("ogiltig produkt.\n");
                }
            }

        }

        private static void ShowCart()
        {
            using var context = new SQL.MyDbContext();
            var productRepo = new ProductSida(context);
            var cartService = new Kundvagn(context, productRepo);

            cartService.ShowCart();

            Console.WriteLine("Vill du ta bort något från varukorgen? (ja/nej): ");
            string choice = Console.ReadLine()?.ToLower();

            if (choice == "ja")
            {
                Console.Write("Vilken produkt vill du ta bort: ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    cartService.RemoveFromCart(productId);
                    ShowCart(); 
                }
                else
                {
                    Console.WriteLine("Ogiltig produkt.\n");
                }
            }

            cartService.Checkout();

            
            var cartSummary = productRepo.SaveCartSummary();

            Console.WriteLine($"Sammanfattning av kundvagnen sparad: {cartSummary.TotalQuantity} produkter, totalpris: {cartSummary.TotalPrice} kr.");

            Console.ReadKey();
            Console.Clear();
            framSida.forstaSida();
        }

        //    private static void ShowCart()
        //    {
        //        using var context = new SQL.MyDbContext(); 
        //        var productRepo = new ProductSida(context);
        //        var cartService = new Kundvagn(context, productRepo); 

        //        cartService.ShowCart(); 

        //        Console.WriteLine("vill du ta bort något från varu korgen (ja/nej): ");
        //        string choice = Console.ReadLine()?.ToLower();

        //        if (choice == "ja")
        //        {
        //            Console.Write("vilken produkt vill du ta bort: ");
        //            if (int.TryParse(Console.ReadLine(), out int productId))
        //            {
        //                cartService.RemoveFromCart(productId);
        //                ShowCart();
        //            }
        //            else
        //            {
        //                Console.WriteLine("ogiltig produkt.\n");
        //            }
        //        }

        //        cartService.Checkout();
        //        ProductSida.SaveCartSummary();
        //        Console.ReadKey();
        //        Console.Clear();
        //        framSida.forstaSida(); 
        //    }

        //}
    }
}



