namespace solid_design_principles;

class Program
{
    static void Main(string[] args)
    {
        // 1. Single Responsibility Principle (SRP) example
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
