using Entity_SQL_SERVER.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Entity_SQL_SERVER
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


    internal class Program
    {
        static void Main(string[] args)
        {


            var connectionString = "Server=localhost,1433;Database=master;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Подключение успешно!");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
            }


            Console.WriteLine("SQL Server EF Core Console App");

            using var db = new AppDbContext();
            
            db.Database.EnsureCreated(); // Создает БД, если её нет


            // Добавляем тестовые данные
            if (!db.Products.Any())
            {
                db.Products.Add(new Product { Name = "Laptop", Price = 999.99m });
                db.Products.Add(new Product { Name = "Mouse", Price = 19.99m });
                db.Products.Add(new Product { Name = "Keyboard", Price = 49.99m });
                db.SaveChanges();
                Console.WriteLine("Test data added");
            }

            // Выводим все продукты
            Console.WriteLine("\nAll Products:");
            foreach (var product in db.Products)
            {
                Console.WriteLine($"{product.Id}: {product.Name} - {product.Price:C}");
            }

            // Пример поиска
            Console.WriteLine("\nExpensive Products (> $50):");
            var expensiveProducts = db.Products.Where(p => p.Price > 50).ToList();
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price:C}");
            }
        }
    }
}
