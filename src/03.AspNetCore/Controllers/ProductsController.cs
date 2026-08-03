using AspNetCoreSamples.Filters;
using AspNetCoreSamples.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSamples.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
        => _productService = productService;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll()
        => Ok(await _productService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [ValidateModel]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductRequest request)
    {
        var created = await _productService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}

[ApiController]
[Route("api/[controller]")]
public class DiDemoController : ControllerBase
{
  private readonly IOperationService _singleton;
  private readonly IOperationService _scoped;
  private readonly IOperationService _transient;

  public DiDemoController(
      [FromKeyedServices("singleton")] IOperationService singleton,
      [FromKeyedServices("scoped")] IOperationService scoped,
      [FromKeyedServices("transient")] IOperationService transient)
  {
      _singleton = singleton;
      _scoped = scoped;
      _transient = transient;
  }

  [HttpGet]
  public IActionResult Get() => Ok(new
  {
      singleton = _singleton.OperationId,
      scoped = _scoped.OperationId,
      transient = _transient.OperationId,
      lifetimes = new[] { _singleton.Lifetime, _scoped.Lifetime, _transient.Lifetime }
  });
}
