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
    internal class CardModel
    {
    }

    internal class Hand
    {
        public Hand(int bettingAmount)
        {
            BettingAmount = bettingAmount;
            Cards = new List<Card>();
        }

        internal int BettingAmount { get; }
        internal List<Card> Cards { get; }
    }

    internal class Card
    {
        public Card(int value)
        {
            Value = value;
        }

        internal int Value { get; set; }
        internal bool ReplacedCard { get; set; }
    }

    internal enum Rank
    {
        T=10,
        J=1, // 11 for first part of puzzle
        Q=12,
        K=13,
        A=14
    }
}
