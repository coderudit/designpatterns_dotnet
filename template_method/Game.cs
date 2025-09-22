namespace template_method
{
    internal abstract class Game
    {
        protected int currentPlayer = 0;

        protected readonly int numberOfPlayers { get; }

        public Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }
            Console.WriteLine($"Player {WinningPlayer} wins.");
        }

        protected abstract void Start();

        protected abstract bool TakeTurn();

        protected abstract bool HaveWinner { get; }

        protected abstract int WinningPlayer { get; }
    }
}