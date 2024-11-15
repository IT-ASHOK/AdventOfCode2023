
namespace Day2
{
    internal class GamesFinder
    {
        internal int GetSumOfPossibleGames(Dictionary<int, List<GameSet>> allGames, IList<Dice> dicesInBag)
        {
            int sum = 0;
            foreach (var game in allGames)
            {
                var sets = game.Value;

                var invalidGameSets = from gameSet in sets
                    from diceInBag in dicesInBag
                    where gameSet.Dices.Any(dice => dice.Color == diceInBag.Color && dice.DiceNumber > diceInBag.DiceNumber)
                    select gameSet;

                if (!invalidGameSets.Any())
                {
                    // we have got a valid game 
                    sum += game.Key;
                }
            }
            return sum;
        }
    }
}
