# Dependency Inversion Principle (DIP)

The Dependency Inversion Principle is one of the five SOLID principles of object-oriented design. It states:

> High-level modules should not depend on low-level modules. Both should depend on abstractions.  
> Abstractions should not depend on details. Details should depend on abstractions.

This principle helps to decouple software modules, making systems easier to maintain, extend, and test.

## Real World Example in C#

### Problem: Tight Coupling

Suppose you have a `ReportGenerator` class that directly depends on a `FileLogger` class:

```csharp
public class FileLogger
{
    public void Log(string message)
    {
        // Write log to file
    }
}

public class ReportGenerator
{
    private FileLogger logger = new FileLogger();

    public void GenerateReport()
    {
        // ... generate report ...
        logger.Log("Report generated.");
    }
}
```

Here, `ReportGenerator` is tightly coupled to `FileLogger`. If you want to log to a database or console, you must modify `ReportGenerator`.

### Solution: Applying DIP

Introduce an abstraction (`ILogger`) and depend on it instead:

```csharp
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        // Write log to file
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class ReportGenerator
{
    private readonly ILogger logger;

    public ReportGenerator(ILogger logger)
    {
        this.logger = logger;
    }

    public void GenerateReport()
    {
        // ... generate report ...
        logger.Log("Report generated.");
    }
}
```

Now, `ReportGenerator` depends on the abstraction (`ILogger`), not the concrete implementation. You can inject any logger you want, making the code flexible and testable.

### Benefits

- **Decoupling:** High-level modules are not affected by changes in low-level modules.
- **Testability:** You can easily substitute real implementations with mocks or stubs for testing.
- **Extensibility:** Adding new logging mechanisms does not require changes to existing high-level modules.

## Summary

The Dependency Inversion Principle encourages you to depend on abstractions rather than concrete implementations. This leads to more
