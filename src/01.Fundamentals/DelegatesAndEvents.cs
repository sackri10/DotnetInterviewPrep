namespace Fundamentals;

/// <summary>
/// Interview topic: Delegates, events, Action/Func.
/// </summary>
public class OrderProcessor
{
    public event EventHandler<string>? OrderCompleted;

    public void ProcessOrder(string orderId, Action<string> onProgress)
    {
        onProgress($"Processing {orderId}...");
        OrderCompleted?.Invoke(this, orderId);
    }
}

public static class DelegatesAndEvents
{
    public static int Add(int a, int b) => a + b;

    public static Func<int, int, int> CreateAdder() => (a, b) => a + b;

    public static void MulticastDelegateDemo()
    {
        Action<string> log = msg => Console.WriteLine($"Log: {msg}");
        log += msg => Console.WriteLine($"Audit: {msg}");
        log("Order created"); // both handlers run
    }
}
