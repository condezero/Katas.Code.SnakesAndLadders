namespace SnakesAndLadders.Core
{
    public class RuleResult
    {
        public int NextPosition { get; set; }
        public string Reason { get; set; }

        public bool CanApplyMoreRules { get; set; }

        public bool IsWinMovement { get; set; }
    }
}
