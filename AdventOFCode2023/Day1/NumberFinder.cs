
namespace Day1
{
    internal class NumberFinder
    {
        internal int GetSumOfAllNumbers(string[] allLines)
        {
            // first part of puzzle  //
            int sum = 0;
            foreach (var line in allLines)
            {
                char firstDigit = GetFirstDigit(line);
                char lastDigit = GetLastDigit(line);

                string num = firstDigit.ToString() + lastDigit.ToString();

                int number = Convert.ToInt32(num);
                sum += number;
            }

            return sum;
        }

        char GetFirstDigit(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return c;
                }
            }
            return '0';
        }

        char GetLastDigit(string input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i]))
                {
                    return input[i];
                }
            }
            return '0';
        }

        //sum = 56465
    }
}
