# Open/Closed Principle (OCP)

The Open/Closed Principle is one of the five SOLID principles of object-oriented design. It states:

> Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification.

This means you should be able to add new functionality to a module or class without changing its existing code, reducing the risk of introducing bugs and making the system easier to maintain.

## Real World Example in C#

### Problem: Modifying Existing Code

Suppose you have a `ProductFilter` class that filters products by color:

```csharp
public class ProductFilter
{
    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var p in products)
            if (p.Color == color)
                yield return p;
    }
}
```

If you want to filter by size or by both size and color, you need to add new methods or modify existing ones, which violates the Open/Closed Principle.

### Solution: Applying OCP with Specification Pattern

Introduce an abstraction for filtering criteria:

```csharp
public interface ISpecification<T>
{
    bool IsSatisfied(T item);
}

public class ColorSpecification : ISpecification<Product>
{
    private Color color;
    public ColorSpecification(Color color) => this.color = color;

    public bool IsSatisfied(Product item) => item.Color == color;
}

public class SizeSpecification : ISpecification<Product>
{
    private Size size;
    public SizeSpecification(Size size) => this.size = size;

    public bool IsSatisfied(Product item) => item.Size == size;
}

public class AndSpecification<T> : ISpecification<T>
{
    private ISpecification<T> first, second;
    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    {
        this.first = first;
        this.second = second;
    }

    public bool IsSatisfied(T item) => first.IsSatisfied(item) && second.IsSatisfied(item);
}

public class BetterFilter
{
    public IEnumerable<T> Filter<T>(IEnumerable<T> items, ISpecification<T> spec)
    {
        foreach (var item in items)
            if (spec.IsSatisfied(item))
                yield return item;
    }
}
```

Now, you can add new specifications without modifying existing code.

### Benefits

- **Extensibility:** Add new behavior by creating new classes, not by changing existing ones.
- **Maintainability:** Reduces risk of breaking existing functionality.
- **Testability:** Each specification can be tested independently.

## Summary

The Open/Closed Principle encourages you to design systems that can be extended without modifying existing code. This leads to more robust, maintainable, and flexible software.
