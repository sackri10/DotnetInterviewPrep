Console.WriteLine("=== Modern .NET Interview Samples ===\n");

RecordsDemo.Run();
PatternMatchingDemo.Run();
SpanDemo.Run();
RequiredMembersDemo.Run();

public static class RecordsDemo
{
    public record Person(string FirstName, string LastName)
    {
        public string FullName => $"{FirstName} {LastName}";
    }

    public static void Run()
    {
        var alice = new Person("Alice", "Smith");
        var bob = alice with { LastName = "Jones" }; // non-destructive mutation
        Console.WriteLine($"Records: {alice.FullName} -> {bob.FullName}");
    }
}

public static class PatternMatchingDemo
{
    public static void Run()
    {
        object value = 42;
        var result = value switch
        {
            int n when n > 0 => $"positive int: {n}",
            string s => $"string: {s}",
            null => "null",
            _ => "other"
        };
        Console.WriteLine($"Pattern matching: {result}");

        if (value is int { } number)
            Console.WriteLine($"  Property pattern: {number}");
    }
}

public static class SpanDemo
{
    public static void Run()
    {
        ReadOnlySpan<char> span = "Hello, World!";
        var slice = span.Slice(0, 5);
        Console.WriteLine($"Span<T>: {slice.ToString()}");
    }
}

public class PersonProfile
{
    public required string Name { get; init; }
    public int Age { get; init; }
}

public static class RequiredMembersDemo
{
    public static void Run()
    {
        var person = new PersonProfile { Name = "Datta", Age = 30 };
        Console.WriteLine($"Required members: {person.Name}, age {person.Age}");
    }
}
