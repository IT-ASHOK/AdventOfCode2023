
using System.Globalization;

//string allText = File.ReadAllText($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day15\\TestFile.txt");
string allText = File.ReadAllText($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day15\\Input.txt");

Console.WriteLine(CalculateHash1(allText));

long CalculateHash1(string allText)
{
    long sum = 0;

    string[] chars = allText.Split(',');

    foreach (string s in chars)
    {
        int localSum = 0;
        foreach (char c in s)
        {
            localSum += c;
            localSum *= 17;
            localSum %= 256;
        }

        sum += localSum;
    }

    return sum;
}


Console.WriteLine(CalculateHash1(allText));

// shorter version 
//long CalculateHash1(string allText) => allText.Split(',').Select(s => s.Aggregate(0, (sum, c) => (sum + c) * 17 % 256)).Sum();
