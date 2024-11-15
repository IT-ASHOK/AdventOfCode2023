
//List<string> allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day14\\TestFile.txt").ToList();
List<string> allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day14\\Input.txt").ToList();


char[,] rocks = new char[allLines.Count,allLines.First().Length];

for(int i=0;i < allLines.Count;i++)
{
    for (int j = 0; j < allLines[i].Length; j++)
    {
        rocks[i,j] = allLines[i][j];
    }
}

TiltNorth(rocks);

Display(rocks);
Console.WriteLine(CalculateSum1(rocks));

void TiltNorth(char[,] chars)
{
    for (int col = 0; col < chars.GetLength(1); col++)
    {
        for (int counter = 1; counter <= chars.GetLength(0) * chars.GetLength(0); counter++)
        {
            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for (int j = i + 1; j < chars.GetLength(0); j++)
                {
                    if (chars[i, col] == '.' && chars[j, col] == 'O')
                    {
                        chars[i, col] = 'O';
                        chars[j, col] = '.';
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}

int CalculateSum1(char[,] chars)
{
    int sum = 0;
    int multiplier = chars.GetLength(0);
    for (int i = 0; i < chars.GetLength(0); i++)
    {
        for (int j = 0; j < chars.GetLength(1); j++)
        {
            if (chars[i, j] == 'O')
            {
                sum += multiplier;
            }
        }

        multiplier--;
    }

    return sum;
}

void Display(char[,] chars)
{
    Console.WriteLine();
    for (int i = 0; i < chars.GetLength(0); i++)
    {
        for (int j = 0; j < chars.GetLength(1); j++)
        {
            Console.Write(chars[i, j]);
        }

        Console.WriteLine();
    }
}
