# Liskov Substitution Principle (LSP)

The Liskov Substitution Principle is one of the five SOLID principles of object-oriented design. It states:

> Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.

This means that subclasses should extend base classes without changing their behavior, so that the derived class can stand in for the base class anywhere it is used.

## Real World Example in C#

### Problem: Violating LSP

Suppose you have a base class `Bird` and a derived class `Penguin`:

```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins can't fly!");
    }
}
```

If you use a `Penguin` where a `Bird` is expected and call `Fly`, you get an exception. This violates LSP because the subclass does not behave like the base class.

### Solution: Applying LSP

Refactor the design so that subclasses do not break the expectations set by the base class:

```csharp
public abstract class Bird
{
    public abstract void Move();
}

public class Sparrow : Bird
{
    public override void Move()
    {
        Console.WriteLine("Sparrow flies");
    }
}

public class Penguin : Bird
{
    public override void Move()
    {
        Console.WriteLine("Penguin swims");
    }
}
```

Now, both `Sparrow` and `Penguin` can be used wherever a `Bird` is expected, and their behavior is appropriate for their type.

### Benefits

- **Correctness:** Subclasses can be used in place of base classes without causing errors.
- **Extensibility:** New subclasses can be added without breaking existing code.
- **Maintainability:** Code is easier to understand and less error-prone.

## Summary

The Liskov Substitution Principle ensures that derived classes extend base classes without altering their expected behavior. This leads to more robust and flexible object-oriented designs.
