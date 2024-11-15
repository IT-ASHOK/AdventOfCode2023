
namespace Day3
{
    internal class MatrixReader
    {
        internal int GetSumOfAllNumbers(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

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
                        int foundNumber = Convert.ToInt32(numberString);

                        /* lest check if there is an adjacent symbol */
                        bool adjacentSymbolFound = false;
                        // same row before number 
                        adjacentSymbolFound = IsSymbol(matrix, row, col - 1, rows, cols);

                        // same row after number
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsSymbol(matrix,row, endColIndex + 1,rows,cols);
                        }

                        // one row up for each digit of number 
                        for (int i = startingColIndex; i <= endColIndex && !adjacentSymbolFound; i++)
                        {
                            adjacentSymbolFound = IsSymbol(matrix, row - 1, i, rows, cols);
                        }

                        // one row down for each digit of number 
                        for (int i = startingColIndex; i <= endColIndex && !adjacentSymbolFound; i++)
                        {
                            adjacentSymbolFound = IsSymbol(matrix, row + 1, i, rows, cols);
                        }

                        // top-left diagonal
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsSymbol(matrix,startingRowIndex-1, startingColIndex-1, rows, cols);
                        }

                        // top-right diagonal
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsSymbol(matrix, startingRowIndex-1, endColIndex + 1, rows, cols);
                        }

                        //bottom-left diagonal
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsSymbol(matrix, startingRowIndex + 1, startingColIndex - 1, rows, cols);
                        }

                        //bottom-right diagonal 
                        if (!adjacentSymbolFound)
                        {
                            adjacentSymbolFound = IsSymbol(matrix, startingRowIndex + 1, endColIndex + 1, rows, cols);
                        }

                        // since we got a number, skip all those digits before next search
                        col += endColIndex - startingColIndex;

                        if (adjacentSymbolFound)
                        {
                            sum += foundNumber;
                        }
                    }

                }
            }
            return sum;
        }

        bool IsSymbol(char[,]matrix, int rowIndex, int colIndex, int rows, int cols)
        {
            bool isSymbol = false;
            if (rowIndex >= 0 && rowIndex < rows && colIndex >= 0 && colIndex < cols)
            {
                char character = matrix[rowIndex, colIndex];
                isSymbol = (character != 46 && 
                            (character >= 33 && character <= 47) ||
                            (character >= 58 && character <= 64) ||
                            (character >= 91 && character <= 96) ||
                            (character >= 123 && character <= 126));
            }
            
            return isSymbol;
        }
    }
}
