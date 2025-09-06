namespace solid_design_principles.srp
{
    internal class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern
        }

        public void RemoveEntry(string text)
        {
            entries.Remove(text);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        public void Save(string filename)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {
            entries.Clear();
            var lines = File.ReadAllLines(filename);
            entries.AddRange(lines);
            if (lines.Length > 0)
            {
                var lastEntry = lines[^1];
                var colonIndex = lastEntry.IndexOf(':');
                if (colonIndex != -1 && int.TryParse(lastEntry.Substring(0, colonIndex), out int lastCount))
                {
                    count = lastCount;
                }
            }
        }
    }
}