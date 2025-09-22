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

        public void Clear()
        {
            entries.Clear();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
}