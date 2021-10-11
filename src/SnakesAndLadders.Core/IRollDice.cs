namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Use it for define a roll like a 6-sided, 8-sided, etc. dice.
    /// </summary>
    public interface IRollDice
    {
  /// <summary>
  /// Emulates roll dices.
  /// </summary>
  /// <param name="diceNumber">Number of dices.</param>
  /// <returns></returns>
        int Roll(int diceNumber);
    }
}
