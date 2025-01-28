using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen.SQL
{
    public class MyDbContext : DbContext
    {
        public DbSet<Kategorier> Kategorier { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Profiler> Profiler { get; set; }
        public DbSet<Kundvagn> kundvagns { get; set; }
        public DbSet<CartSummary> CartSummary { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Webbshoppen;Trusted_Connection=True; TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("Server=tcp:minserver1.database.windows.net,1433;Initial Catalog=Webbshopen;Persist Security Info=False;User ID=Rich;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        
    }


}
