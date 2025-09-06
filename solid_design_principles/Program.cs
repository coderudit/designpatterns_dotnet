namespace solid_design_principles;

class Program
{
    static void Main(string[] args)
    {
        // 1. Single Responsibility Principle (SRP) example
        Execute_Srp();

        // 2. Open/Closed Principle (OCP) example
        Execute_Ocp();

    }

    private static void Execute_Ocp()
    {
        var apple = new ocp.Product("Apple", ocp.Color.Red, ocp.Size.Small);
        var tree = new ocp.Product("Tree", ocp.Color.Green, ocp.Size.Large);
        var house = new ocp.Product("House", ocp.Color.Blue, ocp.Size.Medium);

        var products = new List<ocp.Product> { apple, tree, house };
        Console.WriteLine("Green products (old):");
        foreach (var p in ocp.ProductFilter.FilterByColor(products, ocp.Color.Green))
        {
            Console.WriteLine($" - {p.Name} is green");
        }

        var productFilter2 = new ocp.ProductFilter2();
        Console.WriteLine("Green products (new):");
        foreach (var p in productFilter2.Filter(products, new ocp.ColorSpecification(ocp.Color.Green)))
        {
            Console.WriteLine($" - {p.Name} is green");
        }

        Console.WriteLine("Large products:");
        foreach (var p in productFilter2.Filter(products, new ocp.SizeSpecification(ocp.Size.Large)))
        {
            Console.WriteLine($" - {p.Name} is large");
        }

        Console.WriteLine("Large blue items:");
        var largeBlueSpec = new ocp.AndSpecification<ocp.Product>(
            new ocp.ColorSpecification(ocp.Color.Blue),
            new ocp.SizeSpecification(ocp.Size.Large)
        );
        foreach (var p in productFilter2.Filter(products, largeBlueSpec))
        {
            Console.WriteLine($" - {p.Name} is large and blue");
        }
    }

    private static void Execute_Srp()
    {
        var journal = new srp.Journal();
        journal.AddEntry("I cried today.");
        journal.AddEntry("I ate a bug.");
        Console.WriteLine(journal);

        var persistence = new srp.Persistence(journal);
        var filename = "journal.txt";
        persistence.SaveToFile(journal, filename);

        var loadedJournal = new srp.Journal();
        persistence.LoadFromFile(loadedJournal, filename);
        Console.WriteLine("Loaded Journal:" + Environment.NewLine + loadedJournal);
    }
}
