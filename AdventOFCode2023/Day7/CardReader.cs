/* -------------------------------------------------------------------------------------------------
   Restricted. Copyright (C) Siemens Healthcare GmbH, 2023. All rights reserved.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class CardReader
    {
        internal long GetSumOfAllBettingAmount(List<Hand> allHands)
        {
            long sum = 0;

            allHands.Sort(new HandComparer());

            int count = 1;

            foreach (var hand in allHands)
            {
                sum += hand.BettingAmount * count;
                count++;
            }

            return sum;
        }
    }
}
