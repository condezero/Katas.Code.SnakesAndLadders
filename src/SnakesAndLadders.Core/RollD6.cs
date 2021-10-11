using System;

namespace SnakesAndLadders.Core
{
    /// <summary>
    /// D6 dice IRollDice implementation.
    /// </summary>
    public class RollD6 : IRollDice
    {
        private readonly Random random = new Random();
        /// <summary>
        /// A D6 dice.
        /// </summary>
        /// <returns>A result between 1 and 6.</returns>
        public int Roll() => random.Next(1, 6);
    }
}
