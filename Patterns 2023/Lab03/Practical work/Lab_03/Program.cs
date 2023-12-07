using System;

namespace Lab_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GameManager();
            if(game.Player1.IsDefeat ||
                game.Player2.IsDefeat)
            {
                if(game.GetBoolFromInput("\nTry again?"))
                {
                    game = new GameManager();
                }
            }
        }
    }
}
