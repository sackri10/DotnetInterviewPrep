using System.Collections.Concurrent;

namespace Concurrency;

/// <summary>
/// Interview topic: ConcurrentDictionary, thread-safe collections.
/// </summary>
public static class ConcurrentCollections
{
    private static readonly ConcurrentDictionary<string, int> Cache = new();

    public static int GetOrAdd(string key, Func<string, int> factory)
        => Cache.GetOrAdd(key, factory);

    public static bool TryUpdate(string key, int newValue, int expected)
        => Cache.TryUpdate(key, newValue, expected);
}
