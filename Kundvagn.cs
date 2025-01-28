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
                // Återställ produktens antal i Products-tabellen
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    product.Antal += cartItem.Quantity;
                }

                // Ta bort produkten från Cart-tabellen
                _context.kundvagns.Remove(cartItem);
                _context.SaveChanges();

                Console.WriteLine($"Product '{cartItem.ProductName}' removed from the cart.\n");
            }
            else
            {
                Console.WriteLine("Product not found in the cart.\n");
            }
        }


        // Visar innehållet i varukorgen och summerar det totala priset
        public void ShowCart()
        {
            var cartItems = _context.kundvagns.ToList();

            if (!cartItems.Any())
            {
                Console.WriteLine("\nYour cart is empty.\n");
                return;
            }

            Console.WriteLine("\nItems in your cart:");

            int totalPrice = 0;
            int totalQuantity = 0;

            foreach (var item in cartItems)
            {
                Console.WriteLine($"Product: {item.ProductName}, Quantity: {item.Quantity}, Price (total): {item.Price}");
                totalPrice += item.Price;
                totalQuantity += item.Quantity;
            }

            Console.WriteLine($"\nTotal products: {totalQuantity}");
            Console.WriteLine($"Total price: {totalPrice}\n");
        }

        // Metod för att gå vidare till betalning
        public void Checkout()
        {
            // Visa varukorg först
            ShowCart();

            // Kolla om varukorgen är tom
            var cartItems = _context.kundvagns.ToList();
            if (!cartItems.Any())
            {
                Console.WriteLine("Cannot proceed to checkout with an empty cart.\n");
                return;
            }

            Console.Write("Enter shipping method: ");
            string shipping = Console.ReadLine();

            Console.Write("Enter payment method: ");
            string payment = Console.ReadLine();

            // Slutför beställningen
            _productRepo.CompleteOrder(shipping, payment);
            Console.WriteLine("\nOrder completed and cart cleared.");
        }
        
    }
    
}    