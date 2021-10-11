namespace SnakesAndLadders.Core
{
    public class DefaultWinRule : IRule
    {
        private const int _winPosition = 100;

        public RuleResult ApplyRule(int player, int currentPosition, int rollResult)
        {
            var finalPosition = currentPosition + rollResult;
            if (finalPosition.Equals(_winPosition))
            {
                return new RuleResult
                {
                    IsWinMovement = true,
                    CanApplyMoreRules = false,
                    NextPosition = finalPosition,
                    Reason = $"{player.PlayerName()} wins!!!"
                };
            }
            return DefaultResultRules.DefaultMovementRule(player, finalPosition);
        }

        public bool CanApply(int player, int currentPosition, int rollResult) => (currentPosition + rollResult).Equals(_winPosition);

    }
}
