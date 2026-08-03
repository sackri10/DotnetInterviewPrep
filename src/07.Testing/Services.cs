namespace TestingSamples;

public interface ICalculator
{
    int Add(int a, int b);
    int Divide(int a, int b);
}

public class Calculator : ICalculator
{
    public int Add(int a, int b) => a + b;

    public int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException();
        return a / b;
    }
}

public interface IUserService
{
    Task<string> GetDisplayNameAsync(int userId);
}

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository) => _repository = repository;

    public async Task<string> GetDisplayNameAsync(int userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        return user?.Name ?? "Unknown";
    }
}

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
}

public record User(int Id, string Name);
