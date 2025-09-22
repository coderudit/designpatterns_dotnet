## 🔑 Instance Methods

- **When to use:**
  - The behavior is _fundamental_ to the type.
  - It needs access to the type’s private or protected members.
  - It’s part of the object’s natural responsibilities.
- **Example:**
  ```csharp
  public class Circle {
      public double Radius { get; set; }
      public double Area() => Math.PI * Radius * Radius;
  }
  ```
  Here, `Area()` belongs to `Circle` because it’s intrinsic to what a circle _is_.

## 🔑 Static Methods

- **When to use:**
  - The method doesn’t operate on a specific instance.
  - It’s more of a _utility_ or _factory_ function.
  - It doesn’t conceptually belong to a single object.
- **Example:**
  ```csharp
  public static class MathUtils {
      public static double DegreesToRadians(double degrees)
          => degrees * Math.PI / 180.0;
  }
  ```
  This is a general-purpose helper, not tied to any one object.

## 🔑 Extension Methods

- **When to use:**
  - You want to **add functionality** to a type you don’t own (e.g., `string`, `IEnumerable<T>`).
  - You want to keep the _fluent syntax_ of instance methods, but without modifying the original class.
  - You want to organize “optional” or “domain-specific” behaviors outside the core class.
- **Example:**

  ```csharp
  public static class StringExtensions {
      public static bool IsPalindrome(this string str) {
          var cleaned = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();
          return cleaned.SequenceEqual(cleaned.Reverse());
      }
  }

  // Usage:
  bool result = "Racecar".IsPalindrome(); // reads naturally
  ```

  You couldn’t add `IsPalindrome` directly to `string` (since it’s sealed and part of .NET), but extension methods let you “pretend” you did.

---

## ⚖️ Rules of Thumb

- **Instance method:** If you own the class and the behavior is essential.
- **Static method:** If it’s a general helper, not tied to one object.
- **Extension method:** If you don’t own the class, or the behavior is optional/extra and you want fluent syntax.

Think of it like this:

- _Core behavior → instance method_
- _Utility behavior → static method_
- _Add-on behavior → extension method_
