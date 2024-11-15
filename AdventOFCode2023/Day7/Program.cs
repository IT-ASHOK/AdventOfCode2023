
using Day7;

//string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day7\\TestFile.txt");
string[] allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day7\\Input.txt");


List<Hand> allHands = GetAllHands(allLines);

CardReader cardReader = new CardReader();
long sum = cardReader.GetSumOfAllBettingAmount(allHands);
Console.WriteLine($"sum = {sum}");

List<Hand> GetAllHands(string[] allLines)
{
    List<Hand> allHands = new List<Hand>();

    foreach (var line in allLines)
    {
        string cardValues = line.Split(" ")[0];
        int bettingAmount = Convert.ToInt32(line.Split(" ")[1]);

        Hand hand = new Hand(bettingAmount);

        foreach (char c in cardValues)
        {
            int value = 0;

            if (char.IsDigit(c))
            {
                value = Convert.ToInt32(c.ToString());
            }
            else
            {
                if (Enum.TryParse<Rank>(c.ToString(), out Rank rank))
                {
                    value = (int)rank;
                }
            }
            
            hand.Cards.Add(new Card(value));
        }

        allHands.Add(hand);
    }

    return allHands;
}