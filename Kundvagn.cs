using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    public class Kundvagn
    {
        
        
        private readonly SQL.MyDbContext _context;
        private readonly ProductSida _productRepo;

        public Kundvagn(SQL.MyDbContext context, ProductSida productRepo)
        {
            _context = context;
            _productRepo = productRepo;
        }
        public void RemoveFromCart(int productId)
        {
            var cartItem = _context.kundvagns.FirstOrDefault(c => c.ProductId == productId);

            if (cartItem != null)
            {
                
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    product.Antal += cartItem.Quantity;
                }

                
                _context.kundvagns.Remove(cartItem);
                _context.SaveChanges();

                Console.WriteLine($"Product '{cartItem.ProductName}' bort tagaet fån korg\n");
            }
            else
            {
                Console.WriteLine("Produkt inte hittad.\n");
            }
        }


        
        public void ShowCart()
        {
            var cartItems = _context.kundvagns.ToList();

            if (!cartItems.Any())
            {
                Console.WriteLine("\nKundvagn tom.\n");
                return;
            }

            Console.WriteLine("\nFöremål i Kundvagn:");

            int totalPrice = 0;
            int totalQuantity = 0;

            foreach (var item in cartItems)
            {
                Console.WriteLine($"Produkt: {item.ProductName}, Antal: {item.Quantity}, Pris (total): {item.Price}");
                totalPrice += item.Price;
                totalQuantity += item.Quantity;
            }

            Console.WriteLine($"\nTotal produkter: {totalQuantity}");
            Console.WriteLine($"Total pris: {totalPrice}\n");
        }

        
        public void Checkout()
        {
            
            ShowCart();

           
            var cartItems = _context.kundvagns.ToList();
            if (!cartItems.Any())
            {
                Console.WriteLine("kan ej fortsätta utan varor.\n");
                return;
            }

            Console.Write("vilken frakt Postnord, DHL, (Instabox gratis frakt över 50kr): ");
            string shipping = Console.ReadLine();

            Console.Write("kortnr: ");
            string payment = Console.ReadLine();

            
            _productRepo.CompleteOrder(shipping, payment);
            Console.WriteLine("\nOrder kompllet.");
        }
        
    }
    
}    