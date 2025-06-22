using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
  public DbSet<Category>? Categories { get; set; }
  public DbSet<Product>? Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    string databaseFile = "Northwind.db";
    string path = Path.Combine(Environment.CurrentDirectory, databaseFile);

    string connectionString = $"Data Source={path}";
    WriteLine($"Connection: {connectionString}");
    optionsBuilder.UseSqlite(connectionString);
    optionsBuilder.LogTo(WriteLine, new[] { RelationalEventId.CommandExecuting })
#if DEBUG
      .EnableSensitiveDataLogging()
      .EnableDetailedErrors()
#endif
    ;
    optionsBuilder.UseLazyLoadingProxies();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Example of using Fluent API instead of attributes.
    modelBuilder.Entity<Category>()
      .Property(category => category.CategoryName)
      .IsRequired()
      .HasMaxLength(15);

    // Some SQLite speicific configuration.
    if (Database.ProviderName?.Contains("Sqlite") ?? false)
    {
      modelBuilder.Entity<Product>()
        .Property(product => product.Cost)
        .HasConversion<double>();
      
      modelBuilder.Entity<Product>()
        .HasQueryFilter(p => !p.Discontinued);
    }
  }   
}