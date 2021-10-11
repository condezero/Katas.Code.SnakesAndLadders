namespace SnakesAndLadders.Core
{

    public interface IRule
    {
        /// <summary>
        /// Apply the rule.
        /// </summary>
        /// <param name="player">Player id.</param>
        /// <param name="currentPosition">The current player position.</param>
        /// <param name="rollResult">The result of dice</param>
        /// <returns>A <see cref="RuleResult"/>.</returns>
        RuleResult ApplyRule(int player, int currentPosition, int rollResult);
        /// <summary>
        /// Checks if can use this conditions to apply the rule.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="currentPosition"></param>
        /// <param name="rollResult"></param>
        /// <returns></returns>
        bool CanApply(int player, int currentPosition, int rollResult);
    }
}
