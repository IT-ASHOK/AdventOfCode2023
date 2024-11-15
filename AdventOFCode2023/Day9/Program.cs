using System.Text.RegularExpressions;
using Day9;


//List<string> allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day9\\TestFile.txt").ToList();
List<string> allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day9\\Input.txt").ToList();

List<DataSet> allDataSet = new List<DataSet>();

foreach (var line in allLines)
{
    DataSet dt = new DataSet();
    var matchCollection = Regex.Matches(line, @"-?\d+");
    dt.Numbers = matchCollection.Select(m => long.Parse(m.Value)).ToList();

    allDataSet.Add(dt);
}

/* Part 1 of puzzle */
long sum = NumberFinder.GetSumOfAllNumbers(allDataSet);
Console.WriteLine(sum);

/*- part 2-*/
long sum2 = NumberFinder.GetSumOfAllNumbers2(allDataSet);
Console.WriteLine(sum2);
