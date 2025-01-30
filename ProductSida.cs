using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbshopen.SQL;

namespace Webbshopen
{
    public class ProductSida
    {
        private readonly SQL.MyDbContext _context;

        public ProductSida(SQL.MyDbContext context)
        {
            _context = context;
        }

        public Products GetProductById(int productId)
        {
            return _context.Products
                .Include(p => p.Kategorier) 
                .FirstOrDefault(p => p.Id == productId);
        }

        public bool AddToCart(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null || product.Antal < quantity)
            {
                return false; 
            }

           
            product.Antal -= quantity;
            _context.kundvagns.Add(new SQL.Kundvagn
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                Price = product.Pris.GetValueOrDefault() * quantity
            });

            _context.SaveChanges();
            return true;
        }
        public  CartSummary SaveCartSummary()
        {
            var items = _context.kundvagns.ToList();
            var totalQuantity = items.Sum(i => i.Quantity);
            var totalPrice = items.Sum(i => i.Price);

            var summary = new CartSummary
            {
                TotalQuantity = totalQuantity,
                TotalPrice = totalPrice
            };

            _context.CartSummary.Add(summary);
            _context.SaveChanges();

            return summary;
        }

        public void CompleteOrder(string shippingMethod, string paymentMethod)
        {
            
            Console.WriteLine($"order skickas med {shippingMethod} och betald med kortet {paymentMethod}.");

            
            _context.kundvagns.RemoveRange(_context.kundvagns);
            _context.SaveChanges();
        }
        public List<Products> GetTopThreeProductsByQuantity()
        {
            return _context.Products
                .OrderByDescending(p => p.Antal ?? 0)
                .Take(3)
                .ToList(); 
        }
    }


}





