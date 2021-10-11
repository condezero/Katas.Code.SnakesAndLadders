using System.Linq;

namespace SnakesAndLadders.Core
{
    public class DefaultLimitMoventRule : IRule
    {
        private const int _maxPosition = 100;
        
        
        public RuleResult ApplyRule(int player, int currentPosition, int rollResult)
        {
            var finalPosition = currentPosition + rollResult;

            var playerName = player.PlayerName();
            if (finalPosition <= _maxPosition)
            {
                return new RuleResult
                {
                    NextPosition = finalPosition,
                    Reason = $"{playerName} moves to {finalPosition} space.",
                    CanApplyMoreRules = true

                };
            }

            return DefaultResultRules.DefaultMovementRule(player, finalPosition);
        }

        public bool CanApply(int player, int currentPosition, int rollResult) => (currentPosition + rollResult) <= _maxPosition;

    }
}
