namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Storage.
    /// </summary>
    public interface IPlayerPositionStorage
    {
        /// <summary>
        /// Adds to storate a new player.
        /// </summary>
        /// <param name="playerId">Player id.</param>
        void AddPlayer(int playerId);

        /// <summary>
        /// Returns a player position.
        /// </summary>
        /// <param name="playerId">PlayerId</param>
        /// <returns>The player current position.</returns>
        /// <exception cref="GameException"></exception>
        int GetPlayerPosition(int playerId);

        /// <summary>
        /// Updates player position.
        /// </summary>
        /// <param name="playerId">Player id.</param>
        /// <param name="newPosition">The new position.</param>
        void UpdatePosition(int playerId, int newPosition);
    }
}