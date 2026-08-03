namespace RuntimeAndMemory;

/// <summary>
/// Interview topic: Garbage collection generations, LOH, when GC runs.
/// </summary>
public static class GarbageCollectionBasics
{
  public static void TriggerCollectionDemo()
  {
    // Gen 0: short-lived objects (local variables, temp allocations)
    // Gen 1: buffer between short and long-lived
    // Gen 2: long-lived objects (static fields, caches)
    // LOH: objects >= 85,000 bytes

    var before = GC.CollectionCount(0);
    var shortLived = new byte[1000];
    shortLived = null!;
    GC.Collect(0, GCCollectionMode.Forced);
    var after = GC.CollectionCount(0);
    Console.WriteLine($"Gen 0 collections: {after - before}");
  }

  /// <summary>
  /// Common "memory leak" in .NET: event handler holds reference to subscriber.
  /// </summary>
  public class Publisher
  {
    public event EventHandler? SomethingHappened;
    public void Raise() => SomethingHappened?.Invoke(this, EventArgs.Empty);
  }

  public class Subscriber
  {
    public Subscriber(Publisher pub) => pub.SomethingHappened += OnEvent;
    private void OnEvent(object? sender, EventArgs e) { }
    // Must unsubscribe in Dispose to avoid leak
  }
}
