using Day1;

//string [] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day1\\TestFile.txt");
string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day1\\Input.txt");

/*-- first part of puzzle --*/
//NumberFinder numberFinder = new NumberFinder();
//int sum = numberFinder.GetSumOfAllNumbers(allLines);
//Console.WriteLine($"first part sum = {sum}");

/*-- second part of puzzle --*/
NumberFinder2 numberFinder2 = new NumberFinder2();
int sum2 = numberFinder2.GetSumOfAllNumbers(allLines);
Console.WriteLine($"second part sum = {sum2}");

//second part sum = 55902

