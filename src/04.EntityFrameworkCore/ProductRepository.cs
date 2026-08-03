using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreSamples;

/// <summary>
/// Interview topics: tracking vs no-tracking, eager loading, N+1 problem.
/// </summary>
public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) => _context = context;

    /// <summary>
    /// Eager loading with Include — avoids N+1 queries.
    /// </summary>
    public async Task<List<Product>> GetProductsWithCategoryAsync()
        => await _context.Products
            .Include(p => p.Category)
            .AsNoTracking() // read-only: faster, no change tracking
            .ToListAsync();

    /// <summary>
    /// N+1 problem: BAD — one query per product for category.
    /// </summary>
    public async Task<List<string>> GetCategoryNamesNPlusOneAsync()
    {
        var products = await _context.Products.ToListAsync();
        var names = new List<string>();
        foreach (var p in products)
            names.Add(p.Category.Name); // lazy load triggers extra query each time
        return names;
    }

    /// <summary>
    /// Fix N+1: single query with Include or projection.
    /// </summary>
    public async Task<List<string>> GetCategoryNamesOptimizedAsync()
        => await _context.Products
            .Select(p => p.Category.Name)
            .ToListAsync();

    public async Task AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}

public static class DbContextFactory
{
    public static AppDbContext CreateInMemory(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        return new AppDbContext(options);
    }
}
