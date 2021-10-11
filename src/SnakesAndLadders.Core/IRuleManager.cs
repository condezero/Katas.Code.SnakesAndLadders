namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Simple manager of all rules.
    /// </summary>
    public interface IRuleManager
    {
        /// <summary>
        /// Search the first rule that can apply.
        /// </summary>
        /// <param name="player">Player id</param>
        /// <param name="currentPosition">That player current position.</param>
        /// <param name="rollResult">The result of dice roll.</param>
        /// <returns>A <see cref="IRule"/> reference.</returns>
        /// <exception cref="GameException"></exception>
        IRule GetRule(int player, int currentPosition, int rollResult);
    }
}
