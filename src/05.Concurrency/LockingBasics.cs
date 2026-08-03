namespace Concurrency;

/// <summary>
/// Interview topic: lock, thread-safe singleton, double-checked locking vs Lazy&lt;T&gt;.
/// </summary>
public sealed class ThreadSafeCounter
{
    private int _count;
    private readonly object _lock = new();

    public void Increment()
    {
        lock (_lock)
        {
            _count++;
        }
    }

    public int Value => _count;
}

public sealed class Singleton
{
    private static readonly Lazy<Singleton> Instance = new(() => new Singleton());
    public static Singleton GetInstance() => Instance.Value;
    private Singleton() { }
}

public static class LockingBasics
{
    private static readonly SemaphoreSlim Semaphore = new(3); // max 3 concurrent

    public static async Task RunWithSemaphoreAsync(Func<Task> work)
    {
        await Semaphore.WaitAsync();
        try
        {
            await work();
        }
        finally
        {
            Semaphore.Release();
        }
    }
}
