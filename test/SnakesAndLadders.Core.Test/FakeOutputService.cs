namespace SnakesAndLadders.Core.Test
{
    internal class FakeOutputService : IAuditGame
        {
            public string Message = string.Empty;
            public int RollResult = 0;
            public void Subscribe(IGame game)
            {
                game.OnTurnProcessed += Write;
                game.OnRollProcessed += Write2;
            }

            private void Write(object sender, GameEventArgs e) {
                Message = e.Message;
            }
            private void Write2(object sender, RollEventArgs e) {
                RollResult = e.RollResult;
            }
        }
}
