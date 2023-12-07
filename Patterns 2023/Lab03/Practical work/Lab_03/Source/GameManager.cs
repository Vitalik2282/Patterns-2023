using System;

namespace Lab_02
{
    public sealed class GameManager : Singleton<GameManager> 
    {
        public const ConsoleColor EventTextColor = ConsoleColor.Yellow;

        public PlayerBase<HumanUnit> Player1;
        public PlayerBase<RobotUnit> Player2;

        public int TurnID { get; private set; }

        private bool clearAllAfterTurn = true;
        private ConsoleColor defaultColor;

        public GameManager ()
        {
            defaultColor = Console.ForegroundColor;

            Instance = this;
            Player1 = new RealPlayer();
            Player2 = new BotPlayer();

            BeginGame();
        }

        #region Game
        public void BeginGame()
        {
            clearAllAfterTurn = GetBoolFromInput("Do you want clear console after turn?");

            Turn();
        }

        private void Turn ()
        {
            LogEvent("Turn " + TurnID, EventTextColor);
            Player1.ShowStatus();
            Player2.ShowStatus();

            Player1.PlayTurn();
            Console.ForegroundColor = default;
            Player2.PlayTurn();

            var ended = CheckGameEnded();
            if (ended)
            {
                EndGame();
            }
            else
            {
                TurnEnded();
            }
        }

        private void AcceptNextTurn ()
        {
            Log("\nAny key for next turn...\n");
            Console.ReadKey();
        }

        private void TurnEnded ()
        {
            AcceptNextTurn();
            ClearConsoleIfNeed();

            Player1.RemoveDeadUnits();
            Player2.RemoveDeadUnits();



            TurnID++;
            Turn();
        }
       
        private bool CheckGameEnded ()
        {
            return Player1.IsDefeat || Player2.IsDefeat;
        }

        public void EndGame ()
        {
            if(Player1.IsDefeat)
                LogEvent($"Bot is winner", Player2.TextColor);
            else if(Player2.IsDefeat)
                LogEvent($"Player is winner", Player1.TextColor);
        }
        #endregion

        #region IO
        private void ClearConsoleIfNeed ()
        {
            if(clearAllAfterTurn)
            {
                Console.Clear();
            }
        }

        internal bool GetBoolFromInput(string message)
        {
            Log(message + "[Y/N]\n");
            var raw = Console.ReadKey();
            return raw.Key == ConsoleKey.Y;
        }

        internal void Log(string message) =>
            Log(message, defaultColor);

        internal void Log (string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }

        internal void LogEvent (string message, ConsoleColor color)
        {
            Log($"\n\t\t\t-----{message}-----\n", color);
        }
        #endregion
    }
}
