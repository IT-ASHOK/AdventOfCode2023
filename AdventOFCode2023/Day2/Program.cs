
using Day2;


//string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day2\\TestFile.txt");
string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day2\\Input.txt");

Dictionary<int, List<GameSet>> allGames = CreateGameSets(allLines);

// given dices in bag
IList<Dice> dicesInBag = new List<Dice>();
var redDice  = new Dice(12,Color.red);
var greenDice = new Dice(13, Color.green);
var blueDice = new Dice(14, Color.blue);
dicesInBag.Add(redDice); dicesInBag.Add(greenDice); dicesInBag.Add(blueDice);

/*-- Part 1 of puzzle --*/
//GamesFinder gamesFinder = new GamesFinder();
//int sumOfPossibleGames = gamesFinder.GetSumOfPossibleGames(allGames, dicesInBag);
//Console.WriteLine($"Sum of possible games: {sumOfPossibleGames}");

/*-- Sum of possible games: 2348 --*/

/*-- Part 2 of puzzle --*/
GameFinder2 gamesFinder2 = new GameFinder2();
int sumOfPowersOfSets = gamesFinder2.GetSumOfPowerOfSets(allGames);
Console.WriteLine($"Sum of powers of sets: {sumOfPowersOfSets}");
//Sum of powers of sets: 76008

Dictionary<int, List<GameSet>> CreateGameSets(string[] allLines)
{
    Dictionary<int,List<GameSet>> allGames = new Dictionary<int,List<GameSet>>();

    int gameNumber = 1;
    foreach (var game in allLines)
    {
        string[] array = game.Split(':');
        string setsString = array[1];

        string[] allSets = setsString.Split(';');

        List<GameSet> gameSets = new List<GameSet>();
        int gameSetNumber = 1;
        foreach (var set in allSets)
        {
            var gameSet = new GameSet
            {
                GameSetNumber = gameSetNumber++
            };

            string[] diceInfo = set.Split(',');

            foreach (var diceString in diceInfo)
            {
                string[] colorCode = diceString.TrimStart().Split(' ');
                int numberOfDice = Convert.ToInt32(colorCode[0]);
                Enum.TryParse<Color>(colorCode[1], out Color colorOfDice);

                var dice = new Dice(numberOfDice, colorOfDice);
                
                gameSet.Dices.Add(dice);
            }

            gameSets.Add(gameSet);
        }

        allGames.Add(gameNumber++,gameSets);
    }

    return allGames;
}