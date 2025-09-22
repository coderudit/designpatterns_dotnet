# Template Method Pattern in C#

The **Template Method Pattern** is a behavioral design pattern that defines the skeleton of an algorithm in a base class, allowing subclasses to override specific steps of the algorithm without changing its overall structure. This promotes code reuse and enforces a consistent process while enabling flexibility for individual steps.

## When to Use

- When you have multiple classes that follow the same general workflow but differ in some steps.
- When you want to avoid code duplication by putting common logic in a base class.
- When you want to enforce a specific sequence of operations.

## Structure

- **Abstract Base Class:** Defines the template method (the algorithm's skeleton) and declares abstract or virtual methods for steps that can be customized.
- **Concrete Subclasses:** Implement or override the customizable steps.

## Example in C#

Suppose you are building a data exporter that can export data in different formats (CSV, JSON):

```csharp
public abstract class DataExporter
{
    // The template method
    public void Export(string data, string filename)
    {
        OpenFile(filename);
        WriteData(data);
        CloseFile();
    }

    protected abstract void OpenFile(string filename);
    protected abstract void WriteData(string data);
    protected abstract void CloseFile();
}

public class CsvExporter : DataExporter
{
    protected override void OpenFile(string filename)
    {
        Console.WriteLine($"Opening CSV file: {filename}");
    }

    protected override void WriteData(string data)
    {
        Console.WriteLine($"Writing CSV data: {data}");
    }

    protected override void CloseFile()
    {
        Console.WriteLine("Closing CSV file.");
    }
}

public class JsonExporter : DataExporter
{
    protected override void OpenFile(string filename)
    {
        Console.WriteLine($"Opening JSON file: {filename}");
    }

    protected override void WriteData(string data)
    {
        Console.WriteLine($"Writing JSON data: {data}");
    }

    protected override void CloseFile()
    {
        Console.WriteLine("Closing JSON file.");
    }
}
```

**Usage:**

```csharp
DataExporter exporter = new CsvExporter();
exporter.Export("some,data,here", "file.csv");

exporter = new JsonExporter();
exporter.Export("{ \"some\": \"data\" }", "file.json");
```

## Benefits

- **Code Reuse:** Common workflow logic is implemented once in the base class.
- **Consistency:** Enforces a consistent algorithm structure across subclasses.
- **Flexibility:** Subclasses can customize specific steps as needed.

## Summary

The Template Method Pattern is useful when you want to define the outline of an algorithm once and let subclasses fill in the details. It helps keep code DRY, organized, and maintainable.
