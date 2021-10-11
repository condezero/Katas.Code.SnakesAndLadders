using System;

namespace SnakesAndLadders.Core
{
    /// <summary>
    /// Listener for write on console output.
    /// </summary>
    public class OutputService: IAuditGame
    {

        public void Subscribe(IGame game)
        {
            game.OnTurnProcessed += Write;
            game.OnRollProcessed += WriteRoll;
        }
        /// <summary>
        /// Write output messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Write(object sender, GameEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        /// <summary>
        /// Write the input messages (rolls).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteRoll(object sender, RollEventArgs e)
        {
            Console.WriteLine($"{e.Player.PlayerName()} rolls: {e.RollResult}");
        }

    }

}
