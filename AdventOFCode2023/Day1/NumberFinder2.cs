
namespace Day1
{
    internal class NumberFinder2
    {
        internal int GetSumOfAllNumbers(string[] allLines)
        {
            int sum = 0;
            foreach (var line in allLines)
            {
                char firstDigit = GetFirstDigit(line);
                char lastDigit = GetLastDigit(line);

                string firstNumberWord = GetNumberWord(line);
                string lastNumberWord = null;

                if (firstNumberWord != null)
                {
                    lastNumberWord = GetLastNumberWord(line, firstNumberWord);
                }

                // store all found digits/words in one dictionary 
                Dictionary<int, string> allFindingsWithIndex = new Dictionary<int, string>();
                if (firstDigit != '\0' && !allFindingsWithIndex.ContainsKey(line.IndexOf(firstDigit)))
                {
                    allFindingsWithIndex.Add(line.IndexOf(firstDigit), firstDigit.ToString());
                }
                if (lastDigit != '\0' && !allFindingsWithIndex.ContainsKey(line.LastIndexOf(lastDigit)))
                {
                    allFindingsWithIndex.Add(line.LastIndexOf(lastDigit), lastDigit.ToString());
                }
                if (firstNumberWord != null && !allFindingsWithIndex.ContainsKey(line.IndexOf(firstNumberWord)))
                {
                    allFindingsWithIndex.Add(line.IndexOf(firstNumberWord), firstNumberWord.ToString());
                }
                if (lastNumberWord != null && !allFindingsWithIndex.ContainsKey(line.LastIndexOf(lastNumberWord)))
                {
                    allFindingsWithIndex.Add(line.LastIndexOf(lastNumberWord), lastNumberWord.ToString());
                }

                // sort by occurrence  
                var sortedDictionary = SortDictionary(allFindingsWithIndex);

                // now we have got our first and last number (but mixed mode, digits and words)
                var finalFirstNumber = sortedDictionary.First().Value;
                var finalLastNumber = sortedDictionary.Last().Value;

                // if numbers are not in numeric then we need to convert to numeric from words 
                finalFirstNumber = TryConvertingToNumeric(finalFirstNumber);
                finalLastNumber = TryConvertingToNumeric(finalLastNumber);
                
                // there can be one number with more than one digit, such as 'sixteen' which would be converted to 16
                // but we need to take only 6 out of it as last digit and take 1 as first digit

                string finalMergedNumber = finalFirstNumber + finalLastNumber;
                // we do the same logic, we we did in first part of this puzzle, get first and last digit and sum it 

                firstDigit = GetFirstDigit(finalMergedNumber);
                lastDigit = GetLastDigit(finalMergedNumber);

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
            return '\0';
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
            return '\0';
        }

        string GetNumberWord(string input)
        {
            if (input.Length <= 1)
            {
                return null;
            }

            string comparer= String.Empty;
            bool wordFound = false;
            foreach (char c in input)
            {
                comparer += c;
                if (DoesItMatchToAnyWord(comparer))
                {
                    wordFound = true;
                    return comparer;
                }
            }

            if (!wordFound)
            {
                input = input.Substring(1);
                return GetNumberWord(input);
            }
            
            return null;
        }

        string GetLastNumberWord(string line, string firstNumberWord)
        {
            string lastNumberWord = null;
            string lastNumberTemp = null;

            //remove 'firstNumberWord' from input, in order to search next word,
            //but keep the last character as it might be first for next word
            string firstWordRemovedString = line.Substring(line.IndexOf(firstNumberWord) + firstNumberWord.Length - 1);
            do
            {
                lastNumberTemp = GetNumberWord(firstWordRemovedString);
                if (lastNumberTemp != null)
                {
                    lastNumberWord = lastNumberTemp;
                    firstWordRemovedString = firstWordRemovedString.Substring(firstWordRemovedString.IndexOf(lastNumberWord) + lastNumberWord.Length - 1);
                }
            } while (lastNumberTemp != null);

            // if there is no second word left, then treat first word as last word also
            lastNumberWord ??= firstNumberWord;

            return lastNumberWord;
        }

        bool DoesItMatchToAnyWord(string word)
        {
            return words.Contains(word.ToLower());
        }

        IDictionary<T1, T2> SortDictionary<T1,T2>(IDictionary<T1,T2> dictionary)
        {
            IDictionary<T1, T2> sortedDictionary = new Dictionary<T1, T2>();
            List<T1> sortedKeys = dictionary.Keys.ToList();
            sortedKeys.Sort();

            foreach (T1 key in sortedKeys)
            {
                sortedDictionary.Add(key,dictionary[key]);
            }

            return sortedDictionary;
        }

        string TryConvertingToNumeric(string strNumber)
        {
            int convertedNumber;
            try
            {
                convertedNumber = Convert.ToInt32(strNumber);
            }
            catch (FormatException e)
            {
                convertedNumber = wordToNumberMap[strNumber];
            }

            return convertedNumber.ToString();
        }

        IEnumerable<string> words = new List<string>()
        {
            {"zero"},
            {"one"},
            {"two"},
            {"three"},
            {"four"},
            {"five"},
            {"six"},
            {"seven"},
            {"eight"},
            {"nine"},
            {"ten"},
            {"eleven"},
            {"twelve"},
            {"thirteen"},
            {"fourteen"},
            {"fifteen"},
            {"sixteen"},
            {"seventeen"},
            {"eighteen"},
            {"nineteen"},
            {"twenty"},
            {"thirty"},
            {"forty"},
            {"fifty"},
            {"sixty"},
            {"seventy"},
            {"eighty"},
            {"ninety"},
            {"hundred"}
        };

        Dictionary<string, int> wordToNumberMap = new Dictionary<string, int>
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"eleven", 11},
            {"twelve", 12},
            {"thirteen", 13},
            {"fourteen", 14},
            {"fifteen", 15},
            {"sixteen", 16},
            {"seventeen", 17},
            {"eighteen", 18},
            {"nineteen", 19},
            {"twenty", 20},
            {"thirty", 30},
            {"forty", 40},
            {"fifty", 50},
            {"sixty", 60},
            {"seventy", 70},
            {"eighty", 80},
            {"ninety", 90},
            {"hundred", 100}
        };
    }
}
