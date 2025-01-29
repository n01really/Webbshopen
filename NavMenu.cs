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
            Console.WriteLine("a. hem  b. Kategorier c. logga in d. Kundvagn f.Sök");

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
                case "f":
                    Console.Clear();
                    Search.search();
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
                        Console.WriteLine($"Name: {product.Name}");
                        Console.WriteLine($"Category: {product.Kategorier?.Name}");
                        Console.WriteLine($"Price: {product.Pris}");
                        Console.WriteLine($"Quantity Available: {product.Antal}");
                        Console.WriteLine($"Description: {product.Description}");
                        Console.WriteLine($"Supplier: {product.Levrantör}\n");

                        Console.Write("Do you want to add this product to the cart? (yes/no): ");
                        string choice = Console.ReadLine()?.ToLower();

                        if (choice == "yes")
                        {
                            Console.Write("Enter the quantity to add: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                if (productRepo.AddToCart(productId, quantity))
                                {
                                    Console.WriteLine("Product added to cart successfully.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to add product to cart. Check availability.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Returning to main menu.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Product not found.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Product ID.\n");
                }
            }

        }
        private static void ShowCart()
        {
            using var context = new SQL.MyDbContext(); // Skapar en instans av databaskontexten
            var productRepo = new ProductSida(context); // Repository för produkter
            var cartService = new Kundvagn(context, productRepo); // Skapar en instans av CartService

            cartService.ShowCart(); // Använder CartService för att visa innehållet i kundvagnen

            Console.WriteLine("Would you like to remove a product from the cart? (yes/no): ");
            string choice = Console.ReadLine()?.ToLower();

            if (choice == "yes")
            {
                Console.Write("Enter the Product ID to remove: ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    cartService.RemoveFromCart(productId);
                    ShowCart();
                }
                else
                {
                    Console.WriteLine("Invalid Product ID.\n");
                }
            }

            cartService.Checkout(); // Går vidare till Checkout via CartService
            Console.ReadKey();
            Console.Clear();
            framSida.forstaSida(); // Gå tillbaka till huvudmenyn
        }

    }
}



