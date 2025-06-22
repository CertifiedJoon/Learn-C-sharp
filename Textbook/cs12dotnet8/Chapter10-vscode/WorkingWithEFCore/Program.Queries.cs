using System.Configuration.Assemblies;
using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;
partial class Program
{
  private static void QueryingCategories()
  {
    using NorthwindDb db = new();

    SectionTitle("Categories and how many products they have");

    // A query to get all categoreis and their related products.
    IQueryable<Category>? categories; //.Include(c => c.Products);

    db.ChangeTracker.LazyLoadingEnabled = false;

    Write("enable eager loading? (Y/N): ");
    bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
    bool explicitLoading = false;
    WriteLine();

    if (eagerLoading)
    {
      categories = db.Categories?.Include(c => c.Products);
    }
    else
    {
      categories = db.Categories;
      Write("Enable explicit loading? (Y/N): ");
      explicitLoading = (ReadKey().Key == ConsoleKey.Y);
      WriteLine();
    }

    if (categories is null || !categories.Any())
    {
      Fail("No categories found.");
      return;
    }

    foreach (Category c in categories)
    {
      if (explicitLoading)
      {
        Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
        ConsoleKeyInfo key = ReadKey();
        WriteLine();

        if (key.Key == ConsoleKey.Y)
        {
          CollectionEntry<Category, Product> products = db.Entry(c).Collection(c2 => c2.Products);

          if (!products.IsLoaded) products.Load();
        }
      }
      WriteLine($"{c.CategoryName} has {c.Products.Count} products");
    }
  }

  private static void FilteredIncludes()
  {
    using NorthwindDb db = new();

    SectionTitle("Products with a minimum number of units in stock");

    string? input;
    int stock;

    do
    {
      Write("Enter a minimum for units in stock: ");
      input = ReadLine();
    } while (!int.TryParse(input, out stock));

    IQueryable<Category>? categories = db.Categories?
      .Include(c => c.Products.Where(p => p.Stock >= stock));

    if (categories is null || !categories.Any())
    {
      Fail("No categories found.");
      return;
    }

    foreach (Category c in categories)
    {
      WriteLine(
        "{0} has {1} products with minimum {2} units in stock.",
        arg0: c.CategoryName, arg1: c.Products.Count, arg2: stock
      );
      foreach (Product p in c.Products)
      {
        WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
      }
    }
  }

  private static void QueryingProducts()
  {
    using NorthwindDb db = new();
    SectionTitle("Products that cost at least this price");
    Write("Enter a minimum price for products: ");
    decimal price;
    do { } while (!decimal.TryParse(ReadLine(), out price));

    IQueryable<Product>? products = db.Products?
      .TagWith("Products filtered by price and sorted.")
      .Where(product => product.Cost > price)
      .OrderByDescending(product => product.Cost);

    if (products is null || !products.Any())
    {
      Fail("No products found.");
      return;
    }

    foreach (Product p in products)
    {
      WriteLine(
        "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
        p.ProductId, p.ProductName, p.Cost, p.Stock
      );
    }
  }

  private static void GettingOneProduct()
  {
    using NorthwindDb db = new();

    SectionTitle("Querying a single Product");
    Write("Enter a product Id to query: ");
    int productId;
    do { } while (!int.TryParse(ReadLine(), out productId));

    Product? product = db.Products?.First(p => p.ProductId == productId);

    Info($"First: {product?.ProductName}");

    if (product is null) Fail("No product found using first.");

    product = db.Products?.Single(p => p.ProductId == productId);

    Info($"Single: {product?.ProductName}");

    if (product is null) Fail("No product found using Single.");
  }

  private static void QueryingWithLike()
  {
    using NorthwindDb db = new();

    SectionTitle("Pattern matching with Like");

    Write("Enter part of a product name: ");

    string? input = ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
      Fail("You did not enter part of a product name.");
      return;
    }

    IQueryable<Product>? products = db.Products?
      .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

    if (products is null || !products.Any())
    {
      Fail("No products found.");
      return;
    }

    foreach (Product p in products)
    {
      WriteLine("{0} has {1} units in stock. Discontinuted: {2}",
        p.ProductName, p.Stock, p.Discontinued);
    }
  }
}