
using Day4;

//string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day4\\TestFile.txt");
string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day4\\Input.txt");

IReadOnlyCollection<Card> allCards = GetAllCardDetails(allLines);

/* -- Part 1 of puzzle -- */
//CardReader cardReader = new CardReader();
//int sumOfAllCardPoints = cardReader.GetSumOfAllWinningNumbers(allCards);
//Console.WriteLine($"sum of all card values: {sumOfAllCardPoints}");
/*-- sum of all card values: 25231 --*/

/* -- Part 2 of puzzle -- */
CardReader2 cardReader2 = new CardReader2();
int sumOfAllScratchCards = cardReader2.GetSumOfAllScratchCards(allCards);
Console.WriteLine($"sum of all scratch cards: {sumOfAllScratchCards}");


IReadOnlyCollection<Card> GetAllCardDetails(string[] allLines)
{
    IList<Card> allCards = new List<Card>();

    foreach (var line in allLines)
    {
        string[] cardDetails= line.Split(':');

        string cardNumberString = cardDetails[0];
        string []cardNumbers = cardDetails[1].Split('|');

        int cardNumber = Convert.ToInt32(cardNumberString.Replace("Card", String.Empty).Trim());

        string winningNumbers = cardNumbers[0];
        string numbersInHand = cardNumbers[1];

        Card card = new Card
        {
            CardNumber = cardNumber,
            NumbersInHand = GetNumbers(numbersInHand),
            WinningNumbers = GetNumbers(winningNumbers)
        };

        allCards.Add(card);
    }

    return (IReadOnlyCollection<Card>)allCards;
}

IEnumerable<int> GetNumbers(string numbersString)
{
    string[] numbers = numbersString.Split(" ");
    return numbers.Where(num => !string.IsNullOrEmpty(num))
        .Select(num => Convert.ToInt32(num)).ToList();
}