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
        public int HandValue { get; set; } = 0;
        public string HandType { get; set; } = "High Card";
        public int HighCard { get; set; }
        public string PlayerName { get; set; }

        //Dictionary<int, string> handTypes = new Dictionary<int, string>();

        //    handTypes[0] = "High Card";
        //    handTypes[1] = "Pair";
        //    handTypes[2] = "Two Pair";
        //    handTypes[3] = "Three of a Kind";
        //    handTypes[4] = "Straight";
        //    handTypes[5] = "Flush";
        //    handTypes[6] = "Full House";
        //    handTypes[7] = "Four of a Kind";
        //    handTypes[8] = "Straight Flush";

        public PokerHand(List<Card> cards, string playerName)
        {
            Cards = cards.OrderBy(c => c.CardValue).ToList();
            PlayerName = playerName;
        }


    }
}
