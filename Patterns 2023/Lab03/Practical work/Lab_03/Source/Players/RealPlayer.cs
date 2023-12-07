using System;

namespace Lab_02
{
    public sealed class RealPlayer : PlayerBase<HumanUnit>
    {
        private PlayerBase<RobotUnit> opponent =>
            GameManager.Instance.Player2;

        public RealPlayer ()
        {
            factory = new HumanUnitsFactory();

            CreateArmy(3);
        }

        public override void PlayTurn()
        {
            GameManager.Instance.LogEvent("Player turn", ConsoleColor.Green);

            Console.ForegroundColor = TextColor;
            Console.WriteLine($"Select your unit ID into range: [0, {Army.Length - 1}]");
            var myUnit = SelectMyUnit();
            Console.ForegroundColor = opponent.TextColor;
            Console.WriteLine($"Select enemy unit ID into range: [0, {opponent.Army.Length - 1}]");
            var opponentUnit = SelectOpponentUnit();

            myUnit.Attack(opponentUnit);
        }

        public override ConsoleColor TextColor =>
            ConsoleColor.Blue;

        private HumanUnit SelectMyUnit ()
        {
            var id = SelectIntIntoRange (0, Army.Length);
            return Army[id];
        }

        private RobotUnit SelectOpponentUnit ()
        {
            var id = SelectIntIntoRange(0, opponent.Army.Length);
            return opponent.Army[id];
        }

        private int SelectIntIntoRange (int min, int max)
        {
            var idText = Console.ReadLine();
            if (int.TryParse(idText, out var id) &&
                IntoRange(id, min, max - 1))
            {
                return id;
            }
            else
            {
                return SelectIntIntoRange(min, max);
            }
        }

        private bool IntoRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}