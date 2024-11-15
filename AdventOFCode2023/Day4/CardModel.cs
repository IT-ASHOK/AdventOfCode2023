using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class CardModel
    {
    }

    internal class Card
    {
        internal int CardNumber { get; set; }
        internal IEnumerable<int> WinningNumbers { get; set; }
        internal IEnumerable<int> NumbersInHand { get; set; }
    }
}
