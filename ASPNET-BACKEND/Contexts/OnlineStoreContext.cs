using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

namespace ASPNET_BACKEND.Models;

public class OnlineStoreContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder)
    //{
        //base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseMySQL("Server=localhost;port=3306;User=root;Password=1002;Database=onlinestoreschema").LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors();
        //base.OnConfiguring(optionsBuilder);
    //}

    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options) { }
}
