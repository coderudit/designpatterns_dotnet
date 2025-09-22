namespace template_method.functional_template
{
    internal static class GameTemplate
    {
        public static void Run(
            Action start,
            Action takeTurn,
            Func<bool> haveWinner,
            Func<int> winningPlayer)
        {
            start();
            while (!haveWinner())
            {
                takeTurn();
            }
            Console.WriteLine($"Player {winningPlayer()} wins.");
        }
    }
}