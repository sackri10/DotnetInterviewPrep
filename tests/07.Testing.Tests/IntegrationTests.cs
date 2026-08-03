using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestingSamples.Tests;

/// <summary>
/// Interview topic: Integration testing with WebApplicationFactory.
/// </summary>
public class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Health_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/health");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetProducts_ReturnsProductList()
    {
        var response = await _client.GetAsync("/api/products");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Laptop", content);
    }
}
