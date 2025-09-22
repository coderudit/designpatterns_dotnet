# Strategy Pattern in C#

The **Strategy Pattern** is a behavioral design pattern that enables selecting an algorithm's behavior at runtime. It defines a family of algorithms, encapsulates each one, and makes them interchangeable. This pattern lets the algorithm vary independently from clients that use it.

## When to Use

- When you have multiple related algorithms for a specific task and want to switch between them dynamically.
- When you want to avoid using conditional statements (like `if` or `switch`) to select different behaviors.
- When you want to isolate the implementation details of an algorithm from the code that uses it.

## Structure

- **Strategy Interface:** Declares a method that all concrete strategies must implement.
- **Concrete Strategies:** Implement the strategy interface with different algorithms.
- **Context:** Maintains a reference to a strategy object and delegates it to perform the algorithm.

## Example in C#

Suppose you have a text editor that can save files in different formats (plain text, markdown, HTML):

```csharp
// The strategy interface
public interface ISaveStrategy
{
    void Save(string content, string filename);
}

// Concrete strategy for plain text
public class PlainTextSaveStrategy : ISaveStrategy
{
    public void Save(string content, string filename)
    {
        File.WriteAllText(filename, content);
    }
}

// Concrete strategy for markdown
public class MarkdownSaveStrategy : ISaveStrategy
{
    public void Save(string content, string filename)
    {
        // Add markdown formatting logic here
        File.WriteAllText(filename, $"# Markdown\n{content}");
    }
}

// Context class
public class TextEditor
{
    private ISaveStrategy saveStrategy;

    public TextEditor(ISaveStrategy saveStrategy)
    {
        this.saveStrategy = saveStrategy;
    }

    public void SetSaveStrategy(ISaveStrategy strategy)
    {
        this.saveStrategy = strategy;
    }

    public void SaveFile(string content, string filename)
    {
        saveStrategy.Save(content, filename);
    }
}
```

**Usage:**

```csharp
var editor = new TextEditor(new PlainTextSaveStrategy());
editor.SaveFile("Hello, world!", "file.txt");

editor.SetSaveStrategy(new MarkdownSaveStrategy());
editor.SaveFile("Hello, world!", "file.md");
```

## Benefits

- **Flexibility:** Easily switch between different algorithms at runtime.
- **Maintainability:** Add new strategies without modifying existing code.
- **Separation of Concerns:** Keeps algorithm implementations separate from the context.

## Summary

The Strategy Pattern is a powerful way to encapsulate algorithms and make them interchangeable. It promotes code reusability, flexibility, and cleaner design in scenarios where multiple behaviors are possible.
