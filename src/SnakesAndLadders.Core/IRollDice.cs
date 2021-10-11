namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Use it for define a roll like a 6-sided, 8-sided, etc. dice.
    /// </summary>
    public interface IRollDice
    {
        /// <summary>
        /// Emulates a random dice.
        /// </summary>
        /// <returns></returns>
        int Roll();
    }
}
