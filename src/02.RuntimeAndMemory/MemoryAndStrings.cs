namespace RuntimeAndMemory;

/// <summary>
/// Interview topic: Boxing, string immutability, StringBuilder.
/// </summary>
public static class MemoryAndStrings
{
    public static int CountBoxingAllocations()
    {
        var list = new List<object>();
        for (int i = 0; i < 100; i++)
            list.Add(i); // each int is boxed into object
        return list.Count;
    }

    /// <summary>
    /// Strings are immutable — concatenation in a loop creates many allocations.
    /// </summary>
    public static string BadConcatenation(IEnumerable<string> parts)
        => string.Join("", parts.Select(p => p + " ")); // prefer StringBuilder for loops

    public static string EfficientConcatenation(IEnumerable<string> parts)
    {
        var sb = new System.Text.StringBuilder();
        foreach (var part in parts)
            sb.Append(part).Append(' ');
        return sb.ToString().TrimEnd();
    }

    public static void DemonstrateStringInterning()
    {
        var a = "hello";
        var b = "hello";
        Console.WriteLine(ReferenceEquals(a, b)); // true — string intern pool
    }
}
