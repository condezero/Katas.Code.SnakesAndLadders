using System.Collections.Generic;

[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("SnakesAndLadders.App.Core.Test")]
namespace SnakesAndLadders.Core
{
    public class PlayerPositionStorage : IPlayerPositionStorage
    {
        private static IDictionary<int, int> _playerposition;
        private const int _initialPosition = 1;
        public PlayerPositionStorage()
        {
            _playerposition = new Dictionary<int, int>();

        }
        /// <summary>
        /// Adds to storate a new player.
        /// </summary>
        /// <param name="playerId">Player id.</param>
        public void AddPlayer(int playerId)
        {
            _playerposition.Add(playerId, _initialPosition);
        }
        /// <summary>
        /// Updates player position.
        /// </summary>
        /// <param name="playerId">Player id.</param>
        /// <param name="newPosition">The new position.</param>
        public void UpdatePosition(int playerId, int newPosition)
        {
            if (_playerposition.ContainsKey(playerId))
            {
                _playerposition[playerId] = newPosition;
            }
        }
        /// <summary>
        /// Returns a player position.
        /// </summary>
        /// <param name="playerId">PlayerId</param>
        /// <returns>The player current position.</returns>
        /// <exception cref="GameException"></exception>
        public int GetPlayerPosition(int playerId)
        {
            if (!_playerposition.ContainsKey(playerId)) 
                throw new GameException("This player not exist.");

            return _playerposition[playerId];
        }
    }
}
