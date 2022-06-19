using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Classes
{
    public class Card
    {
        public int CardValue { get; set; }
        public char Suit { get; set; }

        public Card(string cardValue, char suit)
        {
            CardValue = faceValues[cardValue];
            Suit = suit;
        }

        private static readonly Dictionary<string, int> faceValues = new Dictionary<string, int>()
        {
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"10", 10},
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
        };
    }
}
