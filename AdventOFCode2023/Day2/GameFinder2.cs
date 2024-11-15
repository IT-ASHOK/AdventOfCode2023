

namespace Day2
{
    internal class GameFinder2
    {
        internal int GetSumOfPowerOfSets(Dictionary<int, List<GameSet>> allGames)
        {
            int sum = 0;
            foreach (var game in allGames)
            {
                var gameSet = game.Value;

                int highestNumberOfRed = 0;
                int highestNumberOfGreen = 0;
                int highestNumberOfBlue = 0;

                foreach (var set in gameSet)
                {
                    highestNumberOfRed = GetHighestNumber(highestNumberOfRed, Color.red, set);
                    highestNumberOfGreen = GetHighestNumber(highestNumberOfGreen, Color.green, set);
                    highestNumberOfBlue = GetHighestNumber(highestNumberOfBlue, Color.blue, set);
                }

                int multiplication = highestNumberOfRed * highestNumberOfGreen * highestNumberOfBlue;
                sum += multiplication;
            }
            return sum;
        }

        int GetHighestNumber(int currentNumber,Color diceColor, GameSet set)
        {
            int? highestNumberTemp = set.Dices.FirstOrDefault(dice => dice.Color == diceColor)?.DiceNumber;
            if (highestNumberTemp.HasValue &&
                highestNumberTemp >= currentNumber)
            {
                currentNumber = highestNumberTemp.Value;
            }

            return currentNumber;
        }
    }
}
