using System;

namespace Lab_02
{
    public sealed class BotPlayer : PlayerBase<RobotUnit>
    {
        public BotPlayer()
        {
            random = new Random();
            factory = new RobotUnitsFactory();

            CreateArmy(3);
        }

        private Random random;

        private PlayerBase<HumanUnit> opponent =>
            GameManager.Instance.Player1;

        public override ConsoleColor TextColor =>
            ConsoleColor.Red;

        public override void PlayTurn()
        {
            GameManager.Instance.LogEvent("Bot turn", ConsoleColor.DarkGreen);

            var unit = Army[random.Next(0, Army.Length)];
            var opponentUnit = opponent.Army[random.Next(0, opponent.Army.Length)];
            unit.Attack(opponentUnit);
            random = new Random(DateTime.Now.Millisecond);
        }
    }
}