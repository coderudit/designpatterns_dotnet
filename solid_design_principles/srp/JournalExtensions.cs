namespace solid_design_principles.srp
{
    internal static class JournalExtensions
    {
        public static void Clear(this Journal journal)
        {
            var entriesField = typeof(Journal).GetField("entries", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (entriesField != null)
            {
                var entries = entriesField.GetValue(journal) as List<string>;
                entries?.Clear();
            }
        }
    }
}