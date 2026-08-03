# .NET Interview Samples

A hands-on code repository for preparing for .NET interviews. Each project maps to a major interview topic area with runnable, commented examples.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

## Quick Start

```bash
# Build everything
dotnet build

# Run all tests
dotnet test

# Run the Modern .NET console samples
dotnet run --project src/08.ModernDotNet

# Run the ASP.NET Core API
dotnet run --project src/03.AspNetCore
# Then visit https://localhost:7xxx/swagger
```

## Project Structure

| Project | Interview Topics |
|---------|-----------------|
| **01.Fundamentals** | Value vs reference types, generics, LINQ, delegates/events, async/await, SOLID |
| **02.RuntimeAndMemory** | IDisposable, GC generations, boxing, string immutability, memory leaks |
| **03.AspNetCore** | Middleware pipeline, DI lifetimes, controllers, minimal APIs, filters, options pattern |
| **04.EntityFrameworkCore** | DbContext, relationships, Include/eager loading, N+1 problem, AsNoTracking |
| **05.Concurrency** | lock, Lazy singleton, SemaphoreSlim, async pitfalls, ConcurrentDictionary |
| **06.ArchitectureAndPatterns** | Repository, Factory, Strategy, Observer, Clean Architecture layers |
| **07.Testing** | Code under test (paired with test project) |
| **07.Testing.Tests** | xUnit unit tests, Moq mocking, WebApplicationFactory integration tests |
| **08.ModernDotNet** | Records, pattern matching, Span, required members |

## Study Guide by Interview Level

### Junior
Start with `01.Fundamentals` and `02.RuntimeAndMemory`. Be able to explain value vs reference types, LINQ, and basic async/await.

### Mid-Level
Add `03.AspNetCore`, `04.EntityFrameworkCore`, and `05.Concurrency`. Know the DI lifetimes, middleware order, and how to fix N+1 queries.

### Senior
Focus on `06.ArchitectureAndPatterns`, `07.Testing`, and system design discussions. Understand when patterns help vs when they add unnecessary complexity.

## Key Interview Questions Covered

Each source file has XML doc comments linking it to interview topics. Search for `Interview topic:` across the repo:

```bash
grep -r "Interview topic" src/
```

## API Endpoints (AspNetCore project)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/health` | Health check (minimal API) |
| GET | `/api/products` | List products (controller) |
| GET | `/api/products/minimal` | List products (minimal API) |
| GET | `/api/didemo` | Demonstrate DI lifetimes |
| POST | `/api/products` | Create a product |

## License

MIT — use freely for interview preparation.
