namespace Fundamentals;

/// <summary>
/// Interview topic: Generics, constraints, covariance/contravariance.
/// </summary>
public interface IRepository<out T>
{
    T GetById(int id);
}

public class InMemoryRepository<T> : IRepository<T> where T : class, new()
{
    private readonly Dictionary<int, T> _store = new();

    public T GetById(int id) => _store.TryGetValue(id, out var item) ? item : new T();
}

public static class GenericsAndConstraints
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) >= 0 ? a : b;

    // Covariance: IEnumerable<out T> — can assign IEnumerable<Dog> to IEnumerable<Animal>
    public static IEnumerable<string> GetNames(IEnumerable<string> source) => source;
}
