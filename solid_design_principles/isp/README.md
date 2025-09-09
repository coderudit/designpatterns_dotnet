# Interface Segregation Principle (ISP)

The Interface Segregation Principle is one of the five SOLID principles of object-oriented design. It states:

> No client should be forced to depend on methods it does not use.

This principle encourages designing smaller, more specific interfaces rather than large, general-purpose ones. It helps keep code flexible, maintainable, and easier to understand.

## Real World Example in C#

### Problem: Fat Interfaces

Suppose you have a single interface for all types of workers:

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}
```

Now, imagine you have a `Robot` class that implements `IWorker`:

```csharp
public class Robot : IWorker
{
    public void Work()
    {
        // Robot working
    }

    public void Eat()
    {
        // Robots don't eat, but must implement this method
        throw new NotImplementedException();
    }
}
```

Here, `Robot` is forced to implement a method (`Eat`) it does not need.

### Solution: Applying ISP

Split the interface into smaller, more focused ones:

```csharp
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public class Human : IWorkable, IEatable
{
    public void Work()
    {
        // Human working
    }

    public void Eat()
    {
        // Human eating
    }
}

public class Robot : IWorkable
{
    public void Work()
    {
        // Robot working
    }
}
```

Now, each class only implements the interfaces relevant to it.

### Benefits

- **Decoupling:** Classes are not forced to depend on unused methods.
- **Clarity:** Interfaces are easier to understand and implement.
- **Maintainability:** Changes to one interface do not affect unrelated classes.

## Summary

The Interface Segregation Principle encourages you to create small, focused interfaces so that classes only need to implement what they actually use. This leads to cleaner, more maintainable code.
