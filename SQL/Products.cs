using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen.SQL
{
    internal class Products
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string? Name { get; set; }

        public int pris {  get; set; }

        public int Antal { get; set; }
        public string? Description { get; set; }

        public string? levrantör { get; set; }

        public virtual Kategorier? Kategorier { get; set; }
    }
}
