using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen.SQL
{
    internal class Kundvagn
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int KategorierId { get; set; }

        public int? Pris { get; set; }

        public int? Antal { get; set; }
        

        public string? Levrantör { get; set; }
    }
}
