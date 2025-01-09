using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen.SQL
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Kategorier> Kategorier { get; set; }
        public DbSet<Products> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Webbshoppen;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        
    }


}
