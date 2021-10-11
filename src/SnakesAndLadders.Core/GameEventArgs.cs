namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Game event
    /// </summary>
    public class GameEventArgs
    {
        public int NextPlayer { get; set; }
        public int NextPlayerPosition { get; set; }
        public int CurrentPlayerPosition { get; set; }
        public int CurrentPlayer { get; set; }
        public string Message { get; set; }
        public bool IsGameEnded { get; set; }
        public GameEventArgs(int nextPlayer, int nextPlayerPosition, int currentPlayer, int currentPlayerPosition, string message, bool isGameEnded)
        {
            NextPlayer = nextPlayer;
            NextPlayerPosition = nextPlayerPosition;
            CurrentPlayer = currentPlayer;  
            CurrentPlayerPosition = currentPlayerPosition;
            Message = message;
            IsGameEnded = isGameEnded;
        }

    }
    /// <summary>
    /// Roll dice event.
    /// </summary>
    public class RollEventArgs
    {
        public int Player { get; set; }
        public int RollResult { get; set; }
        public RollEventArgs(int player, int rollResult)
        {
            RollResult = rollResult;
            Player = player;
        }
    }
}
