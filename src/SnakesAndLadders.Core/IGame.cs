using System;

namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Game engine.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Write game events.
        /// </summary>
        event EventHandler<GameEventArgs> OnTurnProcessed;
        /// <summary>
        /// Write roll events.
        /// </summary>
        event EventHandler<RollEventArgs> OnRollProcessed;
        /// <summary>
        /// Game startup.
        /// Initialize a game for X players.
        /// </summary>
        /// <param name="numPlayers">Number of players</param>
        void InitGame(int numPlayers);
        /// <summary>
        /// Rolls a implemented <see cref="IRollDice"/>.
        /// </summary>
        /// <returns>A <see cref="Result"/>.</returns>
        Result Roll();
    }
}
