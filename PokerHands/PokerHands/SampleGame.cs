using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Classes
{
    internal class SampleGame
    {
        static void Main()
        {       
            //Creating four sets of five cards for each player's hand
            Card card1 = new Card("2", 'H');
            Card card2 = new Card("3", 'D');
            Card card3 = new Card("5", 'S');
            Card card4 = new Card("9", 'C');
            Card card5 = new Card("K", 'D');
            List<Card> blackCards = new List<Card> { card1, card2, card3, card4, card5 };

            Card card11 = new Card("2", 'H');
            Card card12 = new Card("4", 'S');
            Card card13 = new Card("4", 'C');
            Card card14 = new Card("2", 'D');
            Card card15 = new Card("4", 'H');
            List<Card> blackCards1 = new List<Card> { card11, card12, card13, card14, card15 };

            Card card21 = new Card("2", 'H');
            Card card22 = new Card("3", 'D');
            Card card23 = new Card("5", 'S');
            Card card24 = new Card("9", 'C');
            Card card25 = new Card("K", 'D');
            List<Card> blackCards2 = new List<Card> { card21, card22, card23, card24, card25 };

            Card card31 = new Card("2", 'H');
            Card card32 = new Card("3", 'D');
            Card card33 = new Card("5", 'S');
            Card card34 = new Card("9", 'C');
            Card card35 = new Card("K", 'D');
            List<Card> blackCards3 = new List<Card> { card31, card32, card33, card34, card35 };

            Card card6 = new Card("2", 'C');
            Card card7 = new Card("3", 'H');
            Card card8 = new Card("4", 'S');
            Card card9 = new Card("8", 'C');
            Card card10 = new Card("A", 'H');
            List<Card> whiteCards = new List<Card> { card6, card7, card8, card9, card10 };

            Card card16 = new Card("2", 'S');
            Card card17 = new Card("8", 'S');
            Card card18 = new Card("A", 'S');
            Card card19 = new Card("Q", 'S');
            Card card20 = new Card("3", 'S');
            List<Card> whiteCards1 = new List<Card> { card16, card17, card18, card19, card20 };

            Card card26 = new Card("2", 'C');
            Card card27 = new Card("3", 'H');
            Card card28 = new Card("4", 'S');
            Card card29 = new Card("8", 'C');
            Card card30 = new Card("K", 'H');
            List<Card> whiteCards2 = new List<Card> { card26, card27, card28, card29, card30 };

            Card card36 = new Card("2", 'D');
            Card card37 = new Card("3", 'H');
            Card card38 = new Card("5", 'C');
            Card card39 = new Card("9", 'S');
            Card card40 = new Card("K", 'H');
            List<Card> whiteCards3 = new List<Card> { card36, card37, card38, card39, card40};

            List<List<Card>> blackHands = new List<List<Card>> {blackCards, blackCards1, blackCards2, blackCards3};
            List<List<Card>> whiteHands = new List<List<Card>> {whiteCards, whiteCards1, whiteCards2, blackCards3};

            //Creating 2 new players and a new game
            PokerHand blackHand = new PokerHand(blackCards, "Black");
            PokerHand whiteHand = new PokerHand(whiteCards, "White");
            PokerGame newGame = new PokerGame();

            //Deciding the winner and displaying the results message
            for (int i = 0; i < blackHands.Count; i++)
            {
                blackHand.RelevantHigh = null;
                blackHand.RelevantLow = null;
                whiteHand.RelevantHigh = null;
                whiteHand.RelevantLow = null;
                blackHand.Cards = blackHands[i].OrderBy(c => c.CardValue).ToList();
                whiteHand.Cards = whiteHands[i].OrderBy(c => c.CardValue).ToList();
                List<PokerHand> winners = newGame.ChooseWinner(blackHand, whiteHand);
                newGame.DisplayResults(winners);
                Console.WriteLine();
                Console.WriteLine();
            }           
        }
    }
}
