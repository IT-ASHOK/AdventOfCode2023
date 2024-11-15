/* -------------------------------------------------------------------------------------------------
   Restricted. Copyright (C) Siemens Healthcare GmbH, 2023. All rights reserved.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal static class NumberFinder
    {
        internal static long GetSumOfAllNumbers(List<DataSet> allDataSets)
        {
            long sum = 0;
            foreach (var dataSet in allDataSets)
            {
                sum += MakeNextSequence(dataSet.Numbers);
            }
            return sum;
        }

        static long MakeNextSequence(List<long> numbers)
        {
            if (numbers.All(n => n == 0))
            {
                return 0;
            }

            List<long> sequence = new List<long>();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                long firstNum = numbers[i];
                long secondNum = numbers[i + 1];

                sequence.Add(secondNum - firstNum);
            }

            return numbers.Last() + MakeNextSequence(sequence);
        }

        internal static long GetSumOfAllNumbers2(List<DataSet> allDataSets)
        {
            long sum = 0;
            foreach (var dataSet in allDataSets)
            {
                sum += MakeNextSequence2(dataSet.Numbers);
            }
            return sum;
        }

        static long MakeNextSequence2(List<long> numbers)
        {
            if (numbers.All(n => n == 0))
            {
                return 0;
            }

            List<long> sequence = new List<long>();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                long firstNum = numbers[i];
                long secondNum = numbers[i + 1];

                sequence.Add(secondNum - firstNum);
            }

            return numbers.First() - MakeNextSequence2(sequence);
        }
    }
}
