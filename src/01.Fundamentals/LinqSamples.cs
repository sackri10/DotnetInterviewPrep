namespace Fundamentals;

public record Employee(string Name, string Department, decimal Salary);

/// <summary>
/// Interview topic: LINQ deferred vs immediate execution, IEnumerable vs IQueryable.
/// </summary>
public static class LinqSamples
{
    private static readonly List<Employee> Employees =
    [
        new("Alice", "Engineering", 120_000),
        new("Bob", "Engineering", 95_000),
        new("Carol", "Sales", 80_000),
        new("Dave", "Sales", 75_000),
        new("Eve", "Engineering", 110_000),
    ];

    /// <summary>
    /// Deferred execution: query runs when enumerated, not when defined.
    /// </summary>
    public static IEnumerable<Employee> TopEarnersByDepartment(string department, int count)
    {
        return Employees
            .Where(e => e.Department == department)
            .OrderByDescending(e => e.Salary)
            .Take(count);
    }

    /// <summary>
    /// Immediate execution with ToList(), Count(), etc.
    /// </summary>
    public static Dictionary<string, decimal> AverageSalaryByDepartment()
        => Employees
            .GroupBy(e => e.Department)
            .ToDictionary(g => g.Key, g => g.Average(e => e.Salary));
}
