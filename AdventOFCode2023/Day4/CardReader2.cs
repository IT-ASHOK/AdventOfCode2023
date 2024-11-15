

namespace Day4
{
    internal class CardReader2
    {
        internal int GetSumOfAllScratchCards(IReadOnlyCollection<Card> cards)
        {
            int sum = 0;
            foreach (var card in cards)
            {
                List<Card> copiedScratchCards = new List<Card>{card};
                copiedScratchCards.AddRange(GetAllCopiesOfCards(card, cards));

                sum+= copiedScratchCards.Count;
            }
            return sum;
        }

        internal List<Card> GetAllCopiesOfCards(Card currentCard, IReadOnlyCollection<Card> allCards)
        {
            List<Card> copiedScratchCards = new List<Card>();

            IEnumerable<int> matchingNumbers = currentCard.NumbersInHand.Intersect(currentCard.WinningNumbers);
            if (!matchingNumbers.Any())
            {
                return Enumerable.Empty<Card>().ToList();
            }

            int numberOfFollowingCards = matchingNumbers.Count();

            List<Card> followedCards = allCards.Where(c =>
                c.CardNumber > currentCard.CardNumber && c.CardNumber <= currentCard.CardNumber + numberOfFollowingCards).ToList();

            copiedScratchCards.AddRange(followedCards);

            foreach (var card in followedCards)
            {
                copiedScratchCards.AddRange(GetAllCopiesOfCards(card, allCards));
            }

            return copiedScratchCards;
        }
    }
}
