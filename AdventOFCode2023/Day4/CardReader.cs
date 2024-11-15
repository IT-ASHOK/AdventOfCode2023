

namespace Day4
{
    internal class CardReader
    {
        internal int GetSumOfAllWinningNumbers(IReadOnlyCollection<Card> cards)
        {
            int sum = 0;
            foreach (var card in cards)
            {
                IEnumerable<int> matchingNumbers = card.NumbersInHand.Intersect(card.WinningNumbers);

                //since first match gives only one point which can be represented as '2^0', can be taken out
                sum += Convert.ToInt32(Math.Pow(2, matchingNumbers.Count()-1));
            }
            return sum;
        }
    }
}
