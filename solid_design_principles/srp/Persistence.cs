namespace solid_design_principles.srp
{
    internal class Persistence
    {
        private readonly Journal journal;
        public Persistence(Journal journal)
        {
            this.journal = journal;
        }

        public void SaveToFile(Journal journal, string filename)
        {
            File.WriteAllText(filename, journal.ToString());
        }

        public void LoadFromFile(Journal journal, string filename)
        {
            this.journal.Clear();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                journal.AddEntry(line);
            }
        }
    }
}