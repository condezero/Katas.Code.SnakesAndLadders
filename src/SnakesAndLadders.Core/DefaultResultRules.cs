namespace SnakesAndLadders.Core
{
    internal static class DefaultResultRules
    {
        public static RuleResult DefaultMovementRule(int player, int position) => new RuleResult
        {
            Reason = $"{player.PlayerName()} move to position {position}",
            CanApplyMoreRules = true,
            NextPosition = position
        };
    }
}
