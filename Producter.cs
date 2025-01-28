using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbshopen.SQL;

namespace Webbshopen
{
    public class ItemService
    {
        private readonly SQL.MyDbContext _context;

        public ItemService(SQL.MyDbContext context)
        {
            _context = context;
        }

        public List<Products> GetItemsByForeignKey(int foreignKeyId)
        {
            return _context.Products
                           .Where(item => item.KategorierId == foreignKeyId)
                           .ToList();
        }
    }
}
