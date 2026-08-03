namespace ArchitectureAndPatterns;

// Repository Pattern
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetAllAsync();
    Task AddAsync(Product product);
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];
    private int _nextId = 1;

    public Task<Product?> GetByIdAsync(int id)
        => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public Task<IReadOnlyList<Product>> GetAllAsync()
        => Task.FromResult<IReadOnlyList<Product>>(_products.ToList());

    public Task AddAsync(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return Task.CompletedTask;
    }
}

// Factory Pattern
public interface IPaymentProcessor
{
    void Process(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public void Process(decimal amount) { }
}

public class PayPalProcessor : IPaymentProcessor
{
    public void Process(decimal amount) { }
}

public static class PaymentProcessorFactory
{
    public static IPaymentProcessor Create(string type) => type switch
    {
        "creditcard" => new CreditCardProcessor(),
        "paypal" => new PayPalProcessor(),
        _ => throw new ArgumentException($"Unknown payment type: {type}")
    };
}

// Strategy Pattern
public interface IShippingStrategy
{
    decimal CalculateCost(decimal weightKg);
}

public class StandardShipping : IShippingStrategy
{
    public decimal CalculateCost(decimal weightKg) => 5 + weightKg * 2;
}

public class ExpressShipping : IShippingStrategy
{
    public decimal CalculateCost(decimal weightKg) => 15 + weightKg * 5;
}

public class OrderService
{
    private readonly IShippingStrategy _shipping;

    public OrderService(IShippingStrategy shipping) => _shipping = shipping;

    public decimal GetShippingCost(decimal weightKg) => _shipping.CalculateCost(weightKg);
}

// Observer Pattern (events are the built-in .NET observer)
public class StockTicker
{
    public event Action<string, decimal>? PriceChanged;

    public void UpdatePrice(string symbol, decimal price)
        => PriceChanged?.Invoke(symbol, price);
}
