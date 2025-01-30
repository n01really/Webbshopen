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
        public static async void admin() 
        {
            Console.WriteLine("[a]Kategorier [b]Produkter [c]Profiler [d]Rabatter");
            while (true)
            {
                using (var db = new SQL.MyDbContext())
                {
                    string adminMenu = Console.ReadLine();
                    switch (adminMenu)
                    {
                        case "a":
                            Console.Clear();
                            Console.WriteLine("[a] Lägg till Kategori  [b] Ta bort Kategori");
                            string KatAdmin = Console.ReadLine();
                            switch (KatAdmin) 
                            {
                                case "a":
                                    Categorier.Kategotier();
                                    Console.WriteLine("Lägg till kategori");
                                    string kategoriNamn = Console.ReadLine();
                                    db.Kategorier.Add(new SQL.Kategorier { Name = kategoriNamn });
                                    db.SaveChanges();
                                    Console.Clear();
                                    Admin.admin();
                                    break;
                                case "b":
                                    Categorier.Kategotier();
                                    Console.WriteLine("ta bort kategori");
                                    int kategoriId;
                                    int.TryParse(Console.ReadLine(), out kategoriId);
                                    db.Kategorier.Remove(new SQL.Kategorier { Id = kategoriId });
                                    db.SaveChanges();
                                    Console.Clear();
                                    Categorier.Kategotier();
                                    Admin.admin();
                                    break;
                            }
                        break;
                        case "b":
                            Console.Clear();
                            Console.WriteLine("[a]Lägg till Produkt [b]Ta bort Produkt");
                            string prodAdmin = Console.ReadLine();
                            switch (prodAdmin)
                            {
                                case "a":
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
                                    var newProd = new SQL.Products(Name, kategorierId, Pris, antal, Description, levrantör, productId);
                                    db.Add(newProd);
                                    db.SaveChanges();
                                    break;
                                case "b":
                                    Console.Clear();
                                    Inventarie.inventarie();
                                    Console.WriteLine("ta bort produkt: ");
                                    int id = int.Parse(Console.ReadLine());
                                    var remProd = new SQL.Products(id);
                                    db.Remove(remProd);
                                    db.SaveChanges();
                                    break;
                            }
                        break;
                        case "c":
                            Console.Clear();
                            Console.WriteLine("[a]Ta bort Konto [b]Lägg till Admin konto");
                            string profAdmin = Console.ReadLine();
                            switch(profAdmin)
                            {
                                case "a":
                                    Console.Clear();
                                    Konton.konton();
                                    Console.WriteLine("ta bort konto via ID");
                                    int kId;
                                    int.TryParse(Console.ReadLine(), out kId);
                                    db.Profiler.Remove(new SQL.Profiler { Id = kId });
                                    break;
                                case "b":
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
                                case "c":
                                    Console.Clear();
                                    Konton.konton();
                                    Console.WriteLine("Ändra profil: ");
                                    Console.WriteLine("Ange profilens ID:");
                                    int profilId;
                                    if (!int.TryParse(Console.ReadLine(), out profilId))
                                    {
                                        Console.WriteLine("Felaktigt ID");
                                        break;
                                    }

                                    var profil = db.Profiler.Find(profilId);
                                    if (profil == null)
                                    {
                                        Console.WriteLine("Profilen hittades inte.");
                                        break;
                                    }

                                    Console.Clear();
                                    Console.WriteLine($"[Nuvarande värden visas inom parentes]");

                                    Console.WriteLine($"Förnamn ({profil.forNamn}):");
                                    string nyttFörnamn = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(nyttFörnamn)) profil.forNamn = nyttFörnamn;

                                    Console.WriteLine($"Efternamn ({profil.efterNamn}):");
                                    string nyttEfternamn = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(nyttEfternamn)) profil.efterNamn = nyttEfternamn;

                                    Console.WriteLine($"Adress ({profil.adress}):");
                                    string nyAdress = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(nyAdress)) profil.adress = nyAdress;

                                    Console.WriteLine($"Email ({profil.email}):");
                                    string nyEmail = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(nyEmail)) profil.email = nyEmail;

                                    Console.WriteLine($"Lösenord ({profil.losenord}):");
                                    string nyttLosenord = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(nyttLosenord)) profil.losenord = nyttLosenord;

                                    Console.WriteLine($"Admin-status ({profil.Admin}): [true/false]");
                                    string nyAdminStatus = Console.ReadLine();
                                    if (bool.TryParse(nyAdminStatus, out bool adminStatus)) profil.Admin = adminStatus;

                                    db.SaveChanges();
                                    Console.Clear();
                                    Console.WriteLine("Profilen har uppdaterats.");
                                    Admin.admin();
                                    break;

                            }
                        break;
                        case "d":
                            string reaAdmin = Console.ReadLine();

                            switch (reaAdmin)
                            {
                                case "a": 
                                    Console.Clear();
                                    Console.WriteLine("Ange produktens ID som du vill sätta på rea:");
                                    if (!int.TryParse(Console.ReadLine(), out int produktId))
                                    {
                                        Console.WriteLine("Felaktigt ID.");
                                        break;
                                    }

                                    var produkt = db.Products.Find(produktId);
                                    if (produkt == null)
                                    {
                                        Console.WriteLine("Produkten hittades inte.");
                                        break;
                                    }

                                    Console.WriteLine($"Nuvarande pris: {produkt.Pris} kr");
                                    Console.WriteLine("Ange rabattprocent (ex: 20 för 20% rabatt):");

                                    if (!int.TryParse(Console.ReadLine(), out int rabatt) || rabatt < 0 || rabatt > 100)
                                    {
                                        Console.WriteLine("Ogiltig rabattprocent.");
                                        break;
                                    }

                                    produkt.Pris = (int)(produkt.Pris * (1 - rabatt / 100.0)); 
                                    db.SaveChanges();

                                    Console.WriteLine($"Produkten {produkt.Name} har nu ett nytt pris: {produkt.Pris} kr.");
                                    break;

                                case "b": 
                                    Console.Clear();
                                    Console.WriteLine("Ange kategori-ID för att sätta reor på alla produkter i kategorin:");
                                    if (!int.TryParse(Console.ReadLine(), out int kategoriId))
                                    {
                                        Console.WriteLine("Felaktigt ID.");
                                        break;
                                    }

                                    var produkterIKategori = db.Products.Where(p => p.KategorierId == kategoriId).ToList();
                                    if (!produkterIKategori.Any())
                                    {
                                        Console.WriteLine("Det finns inga produkter i denna kategori.");
                                        break;
                                    }

                                    Console.WriteLine("Ange rabattprocent (ex: 20 för 20% rabatt):");
                                    if (!int.TryParse(Console.ReadLine(), out rabatt) || rabatt < 0 || rabatt > 100)
                                    {
                                        Console.WriteLine("Ogiltig rabattprocent.");
                                        break;
                                    }

                                    foreach (var p in produkterIKategori)
                                    {
                                        p.Pris = (int)(p.Pris * (1 - rabatt / 100.0));
                                    }
                                    db.SaveChanges();

                                    Console.WriteLine($"Alla produkter i kategori {kategoriId} har fått {rabatt}% rabatt.");
                                    break;

                                case "c": 
                                    Console.Clear();
                                    Console.WriteLine("Ange rabattprocent för alla produkter i butiken:");
                                    if (!int.TryParse(Console.ReadLine(), out rabatt) || rabatt < 0 || rabatt > 100)
                                    {
                                        Console.WriteLine("Ogiltig rabattprocent.");
                                        break;
                                    }

                                    var allaProdukter = db.Products.ToList();
                                    if (!allaProdukter.Any())
                                    {
                                        Console.WriteLine("Det finns inga produkter i butiken.");
                                        break;
                                    }

                                    foreach (var p in allaProdukter)
                                    {
                                        p.Pris = (int)(p.Pris * (1 - rabatt / 100.0));
                                    }
                                    db.SaveChanges();

                                    Console.WriteLine($"Alla produkter i butiken har fått {rabatt}% rabatt.");
                                    break;

                                default:
                                    Console.WriteLine("Ogiltigt val.");
                                    break;
                            }
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
