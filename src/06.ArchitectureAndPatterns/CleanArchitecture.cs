namespace ArchitectureAndPatterns;

/// <summary>
/// Interview topic: Clean Architecture layers — Domain, Application, Infrastructure.
/// </summary>

// Domain layer — no dependencies on infrastructure
public class Order
{
    public int Id { get; internal set; }
    public List<OrderLine> Lines { get; } = [];

    public void AddLine(string productName, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive");
        Lines.Add(new OrderLine(productName, quantity, unitPrice));
    }

    public decimal Total => Lines.Sum(l => l.LineTotal);
}

public record OrderLine(string ProductName, int Quantity, decimal UnitPrice)
{
    public decimal LineTotal => Quantity * UnitPrice;
}

// Application layer — use cases, depends on abstractions
public interface IOrderRepository
{
    Task SaveAsync(Order order);
    Task<Order?> GetByIdAsync(int id);
}

public class PlaceOrderHandler
{
    private readonly IOrderRepository _repository;

    public PlaceOrderHandler(IOrderRepository repository) => _repository = repository;

    public async Task<int> HandleAsync(string productName, int quantity, decimal unitPrice)
    {
        var order = new Order();
        order.AddLine(productName, quantity, unitPrice);
        await _repository.SaveAsync(order);
        return order.Id;
    }
}

// Infrastructure layer — concrete implementations (DB, external APIs)
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<int, Order> _orders = new();
    private int _nextId = 1;

    public Task SaveAsync(Order order)
    {
        order.Id = _nextId++;
        _orders[order.Id] = order;
        return Task.CompletedTask;
    }

    public Task<Order?> GetByIdAsync(int id)
        => Task.FromResult(_orders.GetValueOrDefault(id));
}
