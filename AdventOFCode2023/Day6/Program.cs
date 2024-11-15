using Day6;

//string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day6\\TestFile.txt");

string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day6\\Input.txt");


List<RaceModel> allRaces = GetAllRaces();


foreach (var race in allRaces)
{
    for (int i = 1; i <= race.Time; i++)
    {
        int holdTime = i;
        long remainingTime = race.Time - holdTime;
        long coveredDistance = remainingTime * holdTime;

        if (coveredDistance > race.Distance)
        {
            race.PossibleWaysToWin.Add(coveredDistance);
        }
    }
}

int total = 1;
foreach (var race in allRaces)
{
    total *= race.PossibleWaysToWin.Count();
}

Console.WriteLine($"Total : {total}");

List<RaceModel> GetAllRaces()
{

    /* input for Part 1 of the puzzle */
    //List<RaceModel> allRaces = new List<RaceModel>
    //{
    //    new RaceModel(60, 475),
    //    new RaceModel(94, 2138),
    //    new RaceModel(78, 1015),
    //    new RaceModel(82, 1650)
    //};

    /* input for Part 2 of the puzzle */
    List<RaceModel> allRaces = new List<RaceModel>
    {
        //new RaceModel(71530, 940200)
        new RaceModel(60947882l, 475213810151650l)
    };

    return allRaces;
}
