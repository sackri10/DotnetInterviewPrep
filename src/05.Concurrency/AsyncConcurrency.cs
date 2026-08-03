namespace Concurrency;

/// <summary>
/// Interview topic: async pitfalls, deadlocks, CancellationToken, Task.Run vs true async.
/// </summary>
public static class AsyncConcurrency
{
    /// <summary>
    /// BAD: .Result blocks and can deadlock on UI/ASP.NET sync context.
    /// </summary>
    public static string BlockingCallBad(Task<string> task)
        => task.Result; // avoid in production

    /// <summary>
    /// GOOD: await all the way.
    /// </summary>
    public static async Task<string> AwaitProperlyAsync(Task<string> task)
        => await task.ConfigureAwait(false);

    public static async Task<List<int>> ParallelCpuWorkAsync(
        IEnumerable<int> inputs,
        CancellationToken cancellationToken = default)
    {
        // CPU-bound work: use Task.Run; I/O-bound: use async APIs directly
        var tasks = inputs.Select(input =>
            Task.Run(() => ExpensiveCompute(input), cancellationToken));
        return (await Task.WhenAll(tasks)).ToList();
    }

    private static int ExpensiveCompute(int n) => n * n;

    public static async Task DelayWithCancellationAsync(CancellationToken token)
    {
        await Task.Delay(1000, token);
    }
}
