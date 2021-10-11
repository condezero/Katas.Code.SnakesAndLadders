namespace SnakesAndLadders.Core
{
    public static class PlayerExtensions
    {
        /// <summary>
        /// Create a string name using the playerId like Player_1
        /// </summary>
        /// <param name="playerId">The player Id.</param>
        /// <returns></returns>
        public static string PlayerName(this int playerId) => $"Player_{playerId}";
    }
}
