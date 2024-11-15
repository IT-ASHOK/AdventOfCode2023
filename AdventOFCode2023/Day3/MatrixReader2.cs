using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class MatrixReader2
    {
        internal int GearRow { get; set; }
        internal int GearCol { get; set; }
        PartNumber firstPartNumber = new PartNumber();
        PartNumber secondPartNumber = new PartNumber();
        List<PartNumber> foundPartNumbers = new List<PartNumber>();
        internal int GetSumOfAllGearRatios(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            int foundNumber = 0;

            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char character = matrix[row, col];
                    if (char.IsDigit(character))
                    
                    {
                        int startingRowIndex = row;
                        int startingColIndex = col;
                        int endColIndex = startingColIndex;

                        string numberString = character.ToString();
                        int nextCharCounter = 0;
                        while (char.IsDigit(character))
                        {
                            nextCharCounter++;
                            if (col + nextCharCounter < cols)
                            {
                                character = matrix[row, col + nextCharCounter];
                            }
                            else
                            {
                                break;
                            }

                            if (char.IsDigit(character))
                            {
                                endColIndex++;
                                numberString += character;
                            }
                        }

                        // we got a number 
                        foundNumber = Convert.ToInt32(numberString);

                        /* lest check if there is an adjacent symbol */
                        bool adjacentSymbolFound = false;
                        // same row before number 
                        adjacentSymbolFound = IsGear(matrix, row, col - 1, rows, cols);

                        // same row after number
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsGear(matrix, row, endColIndex + 1, rows, cols);
                        }

                        // one row up for each digit of number 
                        for (int i = startingColIndex; i <= endColIndex && !adjacentSymbolFound; i++)
                        {
                            adjacentSymbolFound = IsGear(matrix, row - 1, i, rows, cols);
                        }

                        // one row down for each digit of number 
                        for (int i = startingColIndex; i <= endColIndex && !adjacentSymbolFound; i++)
                        {
                            adjacentSymbolFound = IsGear(matrix, row + 1, i, rows, cols);
                        }

                        // top-left diagonal
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsGear(matrix, startingRowIndex - 1, startingColIndex - 1, rows, cols);
                        }

                        // top-right diagonal
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsGear(matrix, startingRowIndex - 1, endColIndex + 1, rows, cols);
                        }

                        //bottom-left diagonal
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsGear(matrix, startingRowIndex + 1, startingColIndex - 1, rows, cols);
                        }

                        //bottom-right diagonal 
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsGear(matrix, startingRowIndex + 1, endColIndex + 1, rows, cols);
                        }

                        // since we got a number, skip all those digits before next search
                        col += endColIndex - startingColIndex;

                        if (adjacentSymbolFound)
                        {
                            foundPartNumbers.Add(new PartNumber
                            {
                                Number = foundNumber,
                                GearRow = GearRow,
                                GearCol = GearCol
                            });
                        }
                    }
                }
            }

            
            for (int i = 0; i < foundPartNumbers.Count; i++)
            {
                for (int j = i + 1; j < foundPartNumbers.Count; j++)
                {
                    firstPartNumber = foundPartNumbers[i];
                    secondPartNumber = foundPartNumbers[j];

                    if (firstPartNumber.GearRow == secondPartNumber.GearRow &&
                        firstPartNumber.GearCol == secondPartNumber.GearCol)
                    {
                        sum += firstPartNumber.Number * secondPartNumber.Number;
                    }
                }
            }

            return sum;
        }

        bool IsGear(char[,] matrix, int rowIndex, int colIndex, int rows, int cols)
        {
            bool isGear = false;
            if (rowIndex >= 0 && rowIndex < rows && colIndex >= 0 && colIndex < cols)
            {
                char character = matrix[rowIndex, colIndex];
                isGear = character == 42;
            }

            if (isGear)
            {
                StoreGearPosition(rowIndex, colIndex);
            }
            return isGear;
        }

        void StoreGearPosition(int row, int col)
        {
            GearRow = row;
            GearCol = col;
        }
    }

    internal class PartNumber
    {
        internal int Number { get; set; }
        internal int GearRow { get; set; }
        internal int GearCol { get; set; }
    }
}
