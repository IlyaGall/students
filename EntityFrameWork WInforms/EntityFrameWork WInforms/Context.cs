using Entity_SQL_SERVER.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_WInforms
{
    // Контекст базы данных
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=ConsoleAppDb;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;",
                options => options.EnableRetryOnFailure());
        }
    }
}
