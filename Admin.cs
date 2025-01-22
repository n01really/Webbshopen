using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbshopen.Migrations;
using Webbshopen.SQL;

namespace Webbshopen
{
    internal class Admin
    {
        public static void admin() 
        {
            Console.WriteLine("admin meny: q. lägg till kat w. ta bort kat e. Lägg till product r. Ta bort product t. Ta bort konto y. skapa admin konto");
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
                            int.TryParse(Console.ReadLine(), out kategoriId);
                            db.Kategorier.Remove(new SQL.Kategorier {Id = kategoriId });
                            db.SaveChanges();
                            Console.Clear();
                            Categorier.Kategotier();
                            Admin.admin();
                            break;
                        case "e":
                            Console.Clear();
                            Categorier.Kategotier();
                            Inventarie.inventarie();
                            Console.WriteLine("ange kategori Id");
                            int kategorierId = int.Parse(Console.ReadLine()); 
                            Console.WriteLine("lägg till Produkt");
                            string Name = Console.ReadLine();
                            Console.WriteLine("pris");
                            int Pris = int.Parse(Console.ReadLine());
                            Console.WriteLine("Skriv Antal: ");
                            int antal = int.Parse(Console.ReadLine());
                            Console.WriteLine("Skriv levrantör: ");
                            string? levrantör = Console.ReadLine();
                            Console.WriteLine("skriv invetnarie Id");
                            int? productId = int.Parse(Console.ReadLine());
                            Console.WriteLine("beskrivning");
                            string? Description = Console.ReadLine();
                            var newProd = new SQL.Products( Name, kategorierId, Pris, antal, Description, levrantör, productId);
                            db.Add(newProd);
                            db.SaveChanges();
                            break;
                        case "r":
                            Console.Clear();
                            Inventarie.inventarie();
                            Console.WriteLine("ta bort produkt: ");
                            int id = int.Parse( Console.ReadLine());
                            var remProd = new SQL.Products(id);
                            db.Remove(remProd);
                            db.SaveChanges();
                            break;
                        case "t":
                            Console.Clear();
                            Konton.konton();
                            Console.WriteLine("ta bort konto via ID");
                            int kId;
                            int.TryParse(Console.ReadLine(), out kId);
                            db.Profiler.Remove(new SQL.Profiler { Id = kId });
                            break;
                        case "y":
                            Console.Clear();
                            Konton.konton();
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
                            db.Profiler.Add(new SQL.Profiler { Admin = true, forNamn = fN, efterNamn = eN, adress = aD, email = eM, losenord = lO });
                            db.SaveChanges();
                            Console.Clear();
                            framSida.adminSida();
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
