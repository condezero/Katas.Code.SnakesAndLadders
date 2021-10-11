namespace SnakesAndLadders.Core
{
    public class GameOptions
    {
        /// <summary>
        /// Number of dice you want to roll.
        /// Default: 1.
        /// </summary>
        public int DiceNumber { get; set; }
        public GameOptions()
        {
            DiceNumber = 1;
        }
    }
}