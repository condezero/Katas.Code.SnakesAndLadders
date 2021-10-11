namespace SnakesAndLadders.Core
{
    public class Result
    {
        public int PlayerId { get; set; }
        public int CurrentPosition { get; set; }
        public string PlayerName { get { return PlayerId.PlayerName(); } }
        public int PreviousPlayerId { get; set; }
        public int PreviousPlayer_Position {  get; set; }
        public string PreviousPlayerName {  get {  return PreviousPlayerId.PlayerName(); } }
        
        public bool IsEnded { get; set; }
    }
}
