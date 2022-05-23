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

        public Card(int cardValue, char suit) //convert face cards to int here. make cardValue parameter a string then convert
        {
            CardValue = cardValue;
            Suit = suit;
        }
    }
}
