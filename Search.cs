using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    internal class Search
    {
        public static void search()
        {
            using (var db = new SQL.MyDbContext())
            {
                Console.WriteLine("Ange söktermer (separera med komma, t.ex. 'name:phone,price:500'):");
                string input = Console.ReadLine();

                var query = db.Products.AsQueryable();

                if (!string.IsNullOrEmpty(input))
                {
                    var filters = input.Split(',');

                    foreach (var filter in filters)
                    {
                        var parts = filter.Split(':');
                        if (parts.Length == 2)
                        {
                            var field = parts[0].Trim().ToLower();
                            var value = parts[1].Trim();

                            switch (field)
                            {
                                case "name":
                                    query = query.Where(p => p.Name.Contains(value));
                                    break;
                                case "description":
                                    query = query.Where(p => p.Description.Contains(value));
                                    break;
                                case "price":
                                    if (decimal.TryParse(value, out var price))
                                    {
                                        query = query.Where(p => p.Pris == price);
                                    }
                                    break;
                                default:
                                    Console.WriteLine($"Ogiltigt fält: {field}");
                                    break;
                            }
                        }
                    }
                }

                var results = query.ToList();

                Console.WriteLine("\nSökresultat:");
                foreach (var product in results)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Pris:C}, Description: {product.Description}");
                }
            }
        }
    }
}
