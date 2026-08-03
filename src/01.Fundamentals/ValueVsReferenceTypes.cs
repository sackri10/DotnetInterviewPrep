namespace Fundamentals;

/// <summary>
/// Interview topic: Value types vs reference types, boxing/unboxing.
/// </summary>
public static class ValueVsReferenceTypes
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Person
    {
        public string Name { get; set; } = string.Empty;
    }

    /// <summary>
    /// Structs are copied by value; classes are copied by reference.
    /// </summary>
    public static (Point original, Point copy) DemonstrateStructCopy()
    {
        var original = new Point { X = 1, Y = 2 };
        var copy = original;
        copy.X = 99;
        return (original, copy); // original.X is still 1
    }

    /// <summary>
    /// Boxing wraps a value type in a reference type (heap allocation).
    /// </summary>
    public static object BoxInt(int value) => value;

    public static int UnboxInt(object boxed) => (int)boxed;
}
