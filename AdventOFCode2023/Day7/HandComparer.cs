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
    internal class HandComparer : IComparer<Hand>
    {
        public int Compare(Hand hand1, Hand hand2)
        {
            if (GetHandRank(hand1) > GetHandRank(hand2))
            {
                return 1;
            }
            if (GetHandRank(hand1) < GetHandRank(hand2))
            {
                return -1;
            }

            RevertBackJokerCard(hand1);
            RevertBackJokerCard(hand2);

            for (int i = 0; i < hand1.Cards.Count; i++)
            {
                if (hand1.Cards[i].Value > hand2.Cards[i].Value)
                {
                    return 1;
                }

                if (hand1.Cards[i].Value < hand2.Cards[i].Value)
                {
                    return -1;
                }
            }

            return 0;
        }

        int GetHandRank(Hand hand)
        {
            ReplaceJokerCard(hand);

            if (IsFiveOfKind(hand))
                return 8;
            if (IsFourOfKind(hand))
                return 7;
            if (IsFullHouse(hand))
                return 6;
            if (IsThreePair(hand))
                return 5;
            if (IsTwoPair(hand))
                return 4;
            if (IsOnePair(hand))
                return 3;
            if (IsHighCard(hand))
                return 2;

            return 1;
        }

        

        bool IsFiveOfKind(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            return groupedByRank.Any(group => group.Count() == 5);
        }

        bool IsFourOfKind(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            return groupedByRank.Count() == 2 && groupedByRank.Any(group => group.Count() == 4);
        }

        bool IsFullHouse(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            return groupedByRank.Count() == 2 && groupedByRank.Any(group => group.Count() == 3);
        }

        bool IsThreePair(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            return groupedByRank.Count() == 3 && groupedByRank.Any(group => group.Count() == 3);
        }

        bool IsTwoPair(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            return groupedByRank.Count() == 3 && groupedByRank.Any(group => group.Count() == 2);
        }

        bool IsOnePair(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            return groupedByRank.Count() == 4 && groupedByRank.Any(group => group.Count() == 2);
        }

        bool IsHighCard(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            return groupedByRank.Count() == 5;
        }

        private void ReplaceJokerCard(Hand hand)
        {
            var groupedByRank = hand.Cards.GroupBy(card => card.Value);
            if (groupedByRank.Any(group => group.Count() == 5))
            {
                return;
            }

            groupedByRank = hand.Cards.Where(card => card.Value != 1)
                .GroupBy(card => card.Value)
                .OrderByDescending(g => g.Count());


            var maxOccurredCard = groupedByRank.First().Key;

            foreach (var card in hand.Cards)
            {
                if (card.Value == 1)
                {
                    card.Value = maxOccurredCard;
                    card.ReplacedCard = true;
                }
            }
        }

        void RevertBackJokerCard(Hand hand)
        {
            foreach (var card in hand.Cards)
            {
                if (card.ReplacedCard)
                {
                    card.Value = 1;
                }
            }
        }
    }
}
