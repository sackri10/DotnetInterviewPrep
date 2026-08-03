namespace Fundamentals;

// S — Single Responsibility: each class has one reason to change
public interface IEmailSender
{
    void Send(string to, string body);
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) { /* SMTP logic */ }
}

// O — Open/Closed: extend via new implementations, not modification
public interface IDiscountStrategy
{
    decimal Apply(decimal amount);
}

public class PercentageDiscount : IDiscountStrategy
{
    private readonly decimal _rate;
    public PercentageDiscount(decimal rate) => _rate = rate;
    public decimal Apply(decimal amount) => amount * (1 - _rate);
}

// L — Liskov Substitution: subtypes must be substitutable
public abstract class Shape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double Area() => Width * Height;
}

// I — Interface Segregation: small, focused interfaces
public interface IReadable
{
    string Read();
}

public interface IWritable
{
    void Write(string content);
}

// D — Dependency Inversion: depend on abstractions
public class NotificationService
{
    private readonly IEmailSender _emailSender;
    public NotificationService(IEmailSender emailSender) => _emailSender = emailSender;

    public void NotifyUser(string email, string message) => _emailSender.Send(email, message);
}
