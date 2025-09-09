namespace solid_design_principles;

using solid_design_principles.srp;
using solid_design_principles.ocp;
using solid_design_principles.lsp;
using solid_design_principles.isp;
using solid_design_principles.dip;

class Program
{
    static void Main(string[] args)
    {
        // 1. Single Responsibility Principle (SRP) example
        Execute_Srp();

        // 2. Open/Closed Principle (OCP) example
        Execute_Ocp();

        // 3. Liskov Substitution Principle (LSP) example
        Execute_Lsp();

        // 4. Interface Segregation Principle (ISP) example
        Execute_Isp();

        // 5. Dependency Inversion Principle (DIP) example
        Execute_Dip();
    }

    private static void Execute_Srp()
    {
        var journal = new Journal();
        journal.AddEntry("I cried today.");
        journal.AddEntry("I ate a bug.");
        Console.WriteLine(journal);

        var persistence = new Persistence();
        var filename = "journal.txt";
        persistence.SaveToFile(journal, filename);

        var loadedJournal = new Journal();
        persistence.LoadFromFile(loadedJournal, filename);
        Console.WriteLine("Loaded Journal:" + Environment.NewLine + loadedJournal);
    }

    private static void Execute_Ocp()
    {
        var apple = new Product("Apple", Color.Red, Size.Small);
        var tree = new Product("Tree", Color.Green, Size.Large);
        var house = new Product("House", Color.Blue, Size.Medium);

        var products = new List<Product> { apple, tree, house };
        Console.WriteLine("Green products (old):");
        foreach (var p in ProductFilter.FilterByColor(products, Color.Green))
        {
            Console.WriteLine($" - {p.Name} is green");
        }

        var productFilter2 = new ProductFilter2();
        Console.WriteLine("Green products (new):");
        foreach (var p in productFilter2.Filter(products, new ColorSpecification(Color.Green)))
        {
            Console.WriteLine($" - {p.Name} is green");
        }

        Console.WriteLine("Large products:");
        foreach (var p in productFilter2.Filter(products, new SizeSpecification(Size.Large)))
        {
            Console.WriteLine($" - {p.Name} is large");
        }

        Console.WriteLine("Large blue items:");
        var largeBlueSpec = new AndSpecification<Product>(
            new ColorSpecification(Color.Blue),
            new SizeSpecification(Size.Large)
        );
        foreach (var p in productFilter2.Filter(products, largeBlueSpec))
        {
            Console.WriteLine($" - {p.Name} is large and blue");
        }
    }

    private static void Execute_Lsp()
    {
        Bird sparrow = new Sparrow();
        sparrow.Eat();
        ((IFlyingBird)sparrow).Fly();

        Bird ostrich = new Ostrich();
        ostrich.Eat();
        // ostrich.Fly(); // This would be a compile-time error, adhering to LSP
    }

    private static void Execute_Isp()
    {
        var fullTimeEmployee = new FullTimeEmployee(5000);
        Console.WriteLine($"Full-time Employee Monthly Salary: {fullTimeEmployee.CalculateMonthlySalary()}");

        var partTimeEmployee = new ContractEmployee(20, 80);
        Console.WriteLine($"Part-time Employee Hourly Salary: {partTimeEmployee.CalculateHourlySalary()}");
    }

    private static void Execute_Dip()
    {
        var paypalProcessor = new PaymentProcessor(new PayPalGateway());
        paypalProcessor.Pay(100);

        var stripeProcessor = new PaymentProcessor(new StripeGateway());
        stripeProcessor.Pay(200);
    }
}
