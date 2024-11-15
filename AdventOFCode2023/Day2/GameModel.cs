using System;

namespace Day2
{
    internal class GameSet
    {
        internal int GameSetNumber { get; set; }
        internal IList<Dice> Dices { get; set; }

        public GameSet()
        {
            Dices = new List<Dice>();
        }
    }

    internal class Dice
    {
        internal int DiceNumber { get; }
        internal Color Color { get; }
        public Dice(int diceNumber, Color color)
        {
            DiceNumber = diceNumber;
            Color = color;
        }
    }

    internal enum Color
    {
        red=1,
        green=2,
        blue=3
    }
}
