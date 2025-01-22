using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen.SQL
{
    internal class Products
    {
        public Products(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public Products(string name, int kategorierId, int? pris, int? antal, string? description, string? levrantör, int? productId)
        {
            Name = name;
            KategorierId = kategorierId;
            Pris = pris;
            Antal = antal;
            Description = description;
            Levrantör = levrantör;
            ProductId = productId;
        }
        public string Name { get; set; }
        
        public int KategorierId { get; set; }

        public int? Pris {  get; set; }

        public int? Antal { get; set; }
        public string? Description { get; set; }

        public string? Levrantör { get; set; }

        public virtual Kategorier? Kategorier { get; set; }
    }
}
