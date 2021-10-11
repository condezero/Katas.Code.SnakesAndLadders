using System;

namespace SnakesAndLadders.Core
{
    public class Game : IGame
    {
        public event EventHandler<GameEventArgs> OnTurnProcessed;
        public event EventHandler<RollEventArgs> OnRollProcessed;

        private readonly IRuleManager _rules;
        private readonly IRollDice _rollDice;

        public IPlayerPositionStorage _playerPositionStorage { get; }

        private int _currentPlayer = 1;
        private int _old_currentPlayer = 1;
        private static int _numPlayers;

        public Game(IRuleManager ruleManager, IRollDice rollDice, IPlayerPositionStorage playerPositionStorage, IAuditGame output)
        {
            _rules = ruleManager;
            _rollDice = rollDice;
            _playerPositionStorage = playerPositionStorage;
            output.Subscribe(this);
        }
        public void InitGame(int numPlayers)
        {
            _numPlayers = numPlayers;
            for (var i = 1; i <= _numPlayers; i++)
            {
                _playerPositionStorage.AddPlayer(i);

            }

        }

        /// <summary>
        /// Rolls a dice and move the player.
        /// The game ends when this method return true on IsEnded.
        /// </summary>
        /// <returns>A<see cref="Result"/>.</returns>
        public Result Roll()
        {
            var result = _rollDice.Roll();

            OnRollProcessed(this, new RollEventArgs(_currentPlayer, result));

            var currentPosition = _playerPositionStorage.GetPlayerPosition(_currentPlayer);
            var message = string.Empty;
            var isWin = false;
            try
            {
                var rule = _rules.GetRule(_currentPlayer, currentPosition, result);
                if (rule != null)
                {
                    var ruleResult = rule.ApplyRule(_currentPlayer, currentPosition, result);
                    _playerPositionStorage.UpdatePosition(_currentPlayer, ruleResult.NextPosition);
                    OnTurnProcessed(this, new GameEventArgs(_currentPlayer,
                        _playerPositionStorage.GetPlayerPosition(_currentPlayer),
                        _old_currentPlayer,
                        _playerPositionStorage.GetPlayerPosition(_old_currentPlayer),
                        ruleResult.Reason, isWin));
                    if (ruleResult.IsWinMovement)
                    {
                        return new Result { IsEnded = true };
                    }
                }
                
            }
            finally
            {
                NextPlayer();
            }

            return new Result
            {
                PlayerId = _currentPlayer,
                CurrentPosition = _playerPositionStorage.GetPlayerPosition(_currentPlayer),
                PreviousPlayerId = _old_currentPlayer,
                PreviousPlayer_Position = _playerPositionStorage.GetPlayerPosition(_old_currentPlayer)
            };

        }


        private int NextPlayer()
        {
            _old_currentPlayer = _currentPlayer;
            if (_currentPlayer < _numPlayers)
            {
                _currentPlayer++;
            }
            else 
            {
                _currentPlayer = 1;
            }
            return _currentPlayer;
        }
    }
}
