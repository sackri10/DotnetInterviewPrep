namespace AspNetCoreSamples.Services;

/// <summary>
/// Interview topic: DI lifetimes — Singleton, Scoped, Transient.
/// </summary>
public interface IOperationService
{
    Guid OperationId { get; }
    string Lifetime { get; }
}

public class OperationService : IOperationService
{
    public Guid OperationId { get; } = Guid.NewGuid();
    public string Lifetime { get; }

    public OperationService(string lifetime) => Lifetime = lifetime;
}

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(CreateProductRequest request);
}

public record ProductDto(int Id, string Name, decimal Price);
public record CreateProductRequest(string Name, decimal Price);

public class InMemoryProductService : IProductService
{
    private readonly List<ProductDto> _products =
    [
        new(1, "Laptop", 999.99m),
        new(2, "Mouse", 29.99m),
    ];
    private int _nextId = 3;

    public Task<IReadOnlyList<ProductDto>> GetAllAsync()
        => Task.FromResult<IReadOnlyList<ProductDto>>(_products.ToList());

    public Task<ProductDto?> GetByIdAsync(int id)
        => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public Task<ProductDto> CreateAsync(CreateProductRequest request)
    {
        var product = new ProductDto(_nextId++, request.Name, request.Price);
        _products.Add(product);
        return Task.FromResult(product);
    }
}
