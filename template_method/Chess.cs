namespace template_method
{
    internal class Chess : Game
    {
        private int turn = 1;
        private const int maxTurns = 10;

        public Chess() : base(2)
        {
        }

        protected override void Start()
        {
            WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
        }

        protected override void TakeTurn()
        {
            WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }

        protected override bool HaveWinner => turn == maxTurns;

        protected override int WinningPlayer => currentPlayer;
    }
}