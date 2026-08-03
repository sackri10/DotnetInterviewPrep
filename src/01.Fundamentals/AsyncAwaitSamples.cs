namespace Fundamentals;

/// <summary>
/// Interview topic: async/await, Task vs ValueTask, ConfigureAwait.
/// </summary>
public static class AsyncAwaitSamples
{
    public static async Task<string> FetchDataAsync(HttpClient client, string url)
    {
        // await releases the thread back to the pool while I/O is in progress
        var response = await client.GetAsync(url).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }

    public static async Task<List<string>> FetchAllParallelAsync(
        HttpClient client, IEnumerable<string> urls)
    {
        var tasks = urls.Select(url => FetchDataAsync(client, url));
        return (await Task.WhenAll(tasks)).ToList();
    }

    /// <summary>
    /// ValueTask avoids Task allocation when result may be synchronous.
    /// </summary>
    public static ValueTask<int> GetCachedOrComputeAsync(int key, Func<int, int> compute)
    {
        if (key < 10) return new ValueTask<int>(key * 2);
        return new ValueTask<int>(compute(key));
    }
}
