namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Audit the game
    /// </summary>
    public interface IAuditGame
    {
        /// <summary>
        /// Create a game subscription.
        /// </summary>
        /// <param name="game"></param>
        void Subscribe(IGame game);
    }
}
