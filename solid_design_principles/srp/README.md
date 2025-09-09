# Single Responsibility Principle (SRP)

The Single Responsibility Principle is one of the five SOLID principles of object-oriented design. It states:

> A class should have only one reason to change.

This means that each class should focus on a single responsibility or functionality. If a class has more than one responsibility, those responsibilities become coupled, and changes to one may affect the other.

## Real World Example in C#

### Problem: Multiple Responsibilities

Suppose you have a `Report` class that handles both report data and saving the report to a file:

```csharp
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }

    public void SaveToFile(string filename)
    {
        // Save report to file
        File.WriteAllText(filename, Content);
    }
}
```

Here, the `Report` class is responsible for both holding report data and saving it to disk. If the way reports are saved changes (e.g., to a database), you must modify the `Report` class.

### Solution: Applying SRP

Separate the responsibilities into different classes:

```csharp
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }
}

public class ReportSaver
{
    public void SaveToFile(Report report, string filename)
    {
        File.WriteAllText(filename, report.Content);
    }
}
```

Now, `Report` only holds data, and `ReportSaver` handles persistence. Each class has a single responsibility.

### Benefits

- **Maintainability:** Changes to one responsibility do not affect others.
- **Testability:** Each class can be tested independently.
- **Clarity:** Classes are easier to understand and reason about.

## Summary

The Single Responsibility Principle encourages you to design classes that focus on one thing only. This leads to cleaner, more maintainable, and flexible code.
