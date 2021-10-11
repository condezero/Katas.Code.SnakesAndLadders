using System.Collections.Generic;

namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Simple manager of all rules.
    /// </summary>
    public class RuleManager : IRuleManager
    {
        private readonly IEnumerable<IRule> _rules;

        public RuleManager(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }
        /// <summary>
        /// Search the first rule that can apply.
        /// </summary>
        /// <param name="player">Player id</param>
        /// <param name="currentPosition">That player current position.</param>
        /// <param name="rollResult">The result of dice roll.</param>
        /// <returns>A <see cref="IRule"/> reference.</returns>
        /// <exception cref="GameException"></exception>
        public IRule GetRule(int player, int currentPosition, int rollResult)
        {
            foreach (var rule in _rules)
            {
                if (rule.CanApply(player, currentPosition, rollResult))
                {
                    return rule;
                }
            }
            throw new GameException("There is not rule implemented");
        }

    }
}
