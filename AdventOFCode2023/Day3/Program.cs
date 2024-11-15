
using Day3;
using System.Globalization;

//string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day3\\TestFile.txt");
string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day3\\Input.txt");


char[,] matrix = CreateMatrixFromInput(allLines);

/*-- Part 1 of puzzle --*/
//MatrixReader matrixReader = new MatrixReader();
//int sumOfAllEngineParts = matrixReader.GetSumOfAllNumbers(matrix);
//Console.WriteLine($"sum of all engine parts: {sumOfAllEngineParts}");
/*-- sum of all engine parts: 553825 --*/

/*-- Part 2 of puzzle --*/
MatrixReader2 matrixReader2 = new MatrixReader2();
int sumOfAllGearRatios = matrixReader2.GetSumOfAllGearRatios(matrix);
Console.WriteLine($"sum of all gear ratios : {sumOfAllGearRatios}");

char[,] CreateMatrixFromInput(string[] allLines)
{
    int rows = allLines.Length;
    int columns = allLines.Max(line => line.Length);

    // Create a 2D array (matrix)
    char[,] matrix = new char[rows, columns];

    // Populate the matrix with characters from the text
    for (int i = 0; i < rows; i++)
    {
        string line = allLines[i];

        for (int j = 0; j < line.Length; j++)
        {
            matrix[i, j] = line[j];
        }
    }

    return matrix;
}
