using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Classes
{
    internal class Testing
    {
        static void Main(string[] args)
        {
            PokerGame temp = new PokerGame();
            
            List<Card> cards1 = new List<Card>();
            Card card1 = new Card(2, 'C');
            Card card2 = new Card(3, 'H');
            Card card3 = new Card(3, 'C');
            Card card4 = new Card(6, 'H');
            Card card5 = new Card(3, 'S');

            cards1.Add(card1);
            cards1.Add(card2);
            cards1.Add(card3);
            cards1.Add(card4);
            cards1.Add(card5);
            List<Card> cards2 = new List<Card>();
            Card card6 = new Card(3, 'H');
            Card card7 = new Card(2, 'C');
            Card card8 = new Card(6, 'S');
            Card card9 = new Card(6, 'D');
            Card card10 = new Card(4, 'D');

            cards2.Add(card6);
            cards2.Add(card7);
            cards2.Add(card8);
            cards2.Add(card9);
            cards2.Add(card10);

            PokerHand hand1 = new PokerHand(cards1, "Player1");
            PokerHand hand2 = new PokerHand(cards2, "Player2");

            hand1.HandValue = temp.ValueHand(hand1);
            hand2.HandValue = temp.ValueHand(hand2);

            

            List<PokerHand> winners = temp.ChooseWinner(hand1, hand2);
            PokerHand winner = winners[0];
            switch (winner.HandValue)
            {
                case 0:
                    winner.HandType = "High Card";
                    break;
                case 1:
                    winner.HandType = "Pair";
                    break;
                case 2:
                    winner.HandType = "Two Pair";
                    break;
                case 3:
                    winner.HandType = "Three of a Kind";
                    break;
                case 4:
                    winner.HandType = "Straight";
                    break;
                case 5:
                    winner.HandType = "Flush";
                    break;
                case 6:
                    winner.HandType = "Full House";
                    break;
                case 7:
                    winner.HandType = "Four of a Kind";
                    break;
                case 8:
                    winner.HandType = "Straight Flush";
                    break;               
            }

            if (winners.Count == 2)
            {
                Console.WriteLine("Tie");
            }
            else
            {
                Console.WriteLine($"{hand1.PlayerName}: {hand1.Cards}");
                Console.WriteLine($"{hand2.PlayerName}: {hand2.Cards}");
                Console.WriteLine($"{winner.PlayerName} wins with {winner.HandType}");
            }
            
        }
    }
}
