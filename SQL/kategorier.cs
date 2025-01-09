using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen.SQL
{
    internal class Kategorier
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int KategoriId { get; set; }

        public virtual ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
