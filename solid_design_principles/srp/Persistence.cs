namespace solid_design_principles.srp
{
    internal class Persistence
    {
        public void SaveToFile(Journal journal, string filename)
        {
            File.WriteAllText(filename, journal.ToString());
        }

        public void LoadFromFile(Journal journal, string filename)
        {
            journal.Clear();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                journal.AddEntry(line);
            }
        }
    }
}