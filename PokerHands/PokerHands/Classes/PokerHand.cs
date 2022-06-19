using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Classes
{
    public class PokerHand
    {
        public List<Card> Cards { get; set; }
        public int HandValue { get; set; } = 0; //Integer value for hand types
        public string HandType { get; set; } = "High Card";
        public List<Card> RelevantCards { get; set; } = new List<Card>(); //Cards that make up the hand type (mainly for console display purposes)
        public Card? RelevantHigh { get; set; } //Higher card value relevant to the type (pair of 2's + pair of 8's, RelevantHigh would be 8 RelevantLow would be 2)
        public Card? RelevantLow { get; set; } 
        public string PlayerName { get; set; }

        public PokerHand(List<Card> cards, string playerName)
        {
            Cards = cards.OrderBy(c => c.CardValue).ToList();
            PlayerName = playerName;
        }


    }
}
