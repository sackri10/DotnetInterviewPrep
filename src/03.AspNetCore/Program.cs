using AspNetCoreSamples.Configuration;
using AspNetCoreSamples.Filters;
using AspNetCoreSamples.Middleware;
using AspNetCoreSamples.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// --- Dependency Injection ---
builder.Services.AddSingleton<IOperationService>(new OperationService("Singleton"));
builder.Services.AddScoped<IOperationService>(sp => new OperationService("Scoped"));
builder.Services.AddTransient<IOperationService>(sp => new OperationService("Transient"));

builder.Services.AddKeyedSingleton<IOperationService>("singleton", new OperationService("Singleton"));
builder.Services.AddKeyedScoped<IOperationService>("scoped", (sp, key) => new OperationService("Scoped"));
builder.Services.AddKeyedTransient<IOperationService>("transient", (sp, key) => new OperationService("Transient"));

builder.Services.AddScoped<IProductService, InMemoryProductService>();

// --- Options Pattern ---
builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection(ApiSettings.SectionName));

// --- MVC + Filters ---
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- Middleware Pipeline (order matters!) ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestTiming(); // custom middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// --- Minimal APIs (modern .NET style) ---
app.MapGet("/api/health", (IOptions<ApiSettings> settings) =>
    Results.Ok(new
    {
        status = "healthy",
        app = settings.Value.ApplicationName
    }))
    .WithName("HealthCheck")
    .WithTags("Health");

app.MapGet("/api/products/minimal", async (IProductService service) =>
    Results.Ok(await service.GetAllAsync()))
    .WithTags("Products");

app.Run();

// Required for WebApplicationFactory integration tests
public partial class Program { }
