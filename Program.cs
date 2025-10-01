using Microsoft.EntityFrameworkCore;
using EfCoreRepositoryDemo.Entities;
using EfCoreRepositoryDemo.Infrastructure;
using EfCoreRepositoryDemo.Repositories;

namespace EfCoreRepositoryDemo;

class Program
{
    static async Task Main(string[] args)
    {
        // Configuración del DbContext
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=localhost;Database=EfDemo;Trusted_Connection=True;TrustServerCertificate=True;")
            .UseLazyLoadingProxies()
            .Options;

        using var context = new AppDbContext(options);
        var unitOfWork = new UnitOfWork(context);

        // Insertar datos de prueba solo si no existen
        if (!context.Users.Any())
        {
            var user = new User { Name = "Jarvis" };
            var product = new Product { Name = "Laptop", Price = 1200m };

            context.Users.Add(user);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            var order = new Order { UserId = user.Id, ProductId = product.Id };
            await unitOfWork.Orders.AddAsync(order);
            await unitOfWork.SaveChangesAsync();

            Console.WriteLine("Datos de prueba insertados ✅");
        }

        // Consultar órdenes del usuario
        var existingUser = context.Users.First();
        var orders = await unitOfWork.Orders.GetOrdersByUserAsync(existingUser.Id);

        Console.WriteLine($"Usuario {existingUser.Name} tiene {orders.Count} órdenes.");

        // Evita que la consola se cierre de inmediato
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
