using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    internal class Admin
    {
        public static void admin() 
        {
            Console.WriteLine("admin meny: q. lägg till kat w. ta bort kat");
            while (true)
            {
                using (var db = new SQL.MyDbContext())
                {
                    string adminMenu = Console.ReadLine();
                    switch (adminMenu)
                    {
                        case "q":
                            Categorier.Kategotier();
                            Console.WriteLine("Lägg till kategori");
                            string kategoriNamn = Console.ReadLine();
                            db.Kategorier.Add(new SQL.Kategorier { Name = kategoriNamn });
                            db.SaveChanges();
                            Console.Clear();
                            Admin.admin();
                            break;
                        case "w":
                            Categorier.Kategotier();
                            Console.WriteLine("ta bort kategori");
                            int kategoriId;
                            if (int.TryParse(Console.ReadLine(), out kategoriId))
                            db.Kategorier.Remove(new SQL.Kategorier {Id = kategoriId });
                            db.SaveChanges();
                            Console.Clear();
                            Categorier.Kategotier();
                            Admin.admin();
                            break;
                        case "e":
                            Console.WriteLine("välj Kategori");
                            Console.WriteLine("lägg till Produkt");
                            break;
                        case "r":
                            Console.WriteLine("välj kategori");
                            Console.WriteLine("ta bort produkt");
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val");
                            break;
                    }
                }
            }
        }
    }
}
