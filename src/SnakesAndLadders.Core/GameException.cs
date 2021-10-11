using System;

namespace SnakesAndLadders.Core
{
    public class GameException : Exception
    {
        public GameException(string message) : base(message) { }
   
    }
}
