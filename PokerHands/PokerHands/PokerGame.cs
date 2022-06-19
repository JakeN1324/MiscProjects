using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Classes
{
    public class PokerGame
    {
        public static readonly Dictionary<int, string> faceCards = new Dictionary<int, string>()
        {
            {11, "J"},
            {12, "Q"},
            {13, "K"},
            {14, "A"}
        };

        //Returns an integer value based on the hand type found
        public int ValueHand(PokerHand playerHand)
        {
            playerHand.RelevantCards.Clear();
            int handValue = 0;
            List<Card> cards = playerHand.Cards;

            //First Pass - Starting at index 0 of the cards list, considering all 5 cards for pair combinations. Relevant cards are added as hand types are found
            if (cards[0].CardValue == cards[1].CardValue) //Check for pair
            {
                //Hands are assigned a value based on the type found, and cards relevant to that type are assigned to the properties
                handValue = 1;
                playerHand.RelevantCards.Add(cards[0]);
                playerHand.RelevantHigh = cards[0];
                playerHand.RelevantCards.Add(cards[1]);

                if (cards[0].CardValue == cards[2].CardValue) //Check for set
                {
                    handValue = 3;
                    playerHand.RelevantCards.Add(cards[2]);

                    if (cards[0].CardValue == cards[3].CardValue) //Check for quads
                    {
                        handValue = 7;
                        playerHand.RelevantCards.Add(cards[3]);
                    }
                    else if (cards[3].CardValue == cards[4].CardValue) //Check for full house
                    {
                        handValue = 6;
                        playerHand.RelevantCards.Add(cards[3]);
                        playerHand.RelevantCards.Add(cards[4]);
                        playerHand.RelevantLow = cards[3];
                    }
                }
                else if (cards[2].CardValue == cards[3].CardValue) //Check for two pair
                {
                    handValue = 2;
                    playerHand.RelevantCards.Add(cards[2]);
                    playerHand.RelevantCards.Add(cards[3]);
                    if (cards[0].CardValue > cards[2].CardValue)  //Check for higher value between the two pairs
                    {
                        playerHand.RelevantHigh = cards[0];
                        playerHand.RelevantLow = cards[2];
                    }
                    else
                    {
                        playerHand.RelevantHigh = cards[2];
                        playerHand.RelevantLow = cards[0];
                    }

                    if (cards[2].CardValue == cards[4].CardValue) //Check for full house from remaining cards 
                    {
                        handValue = 6;
                        playerHand.RelevantCards.Add(cards[4]);
                        playerHand.RelevantHigh = cards[2];
                        playerHand.RelevantLow = cards[0];
                    }
                }
                else if (cards[3].CardValue == cards[4].CardValue) //Check for two pair from remaining cards
                {
                    handValue = 2;
                    playerHand.RelevantCards.Add(cards[3]);
                    playerHand.RelevantCards.Add(cards[4]);
                    if (cards[0].CardValue > cards[3].CardValue)  //Check for higher value between the two pairs
                    {
                        playerHand.RelevantHigh = cards[0];
                        playerHand.RelevantLow = cards[3];
                    }
                    else
                    {
                        playerHand.RelevantHigh = cards[3];
                        playerHand.RelevantLow = cards[0];
                    }
                }
            }//Second Pass - Starting at index 1, considering last 4 cards for pair/sets
            else if (cards[1].CardValue == cards[2].CardValue) //Check for pair
            {
                handValue = 1;
                playerHand.RelevantCards.Add(cards[1]);
                playerHand.RelevantCards.Add(cards[2]);
                playerHand.RelevantHigh = cards[1];

                if (cards[1].CardValue == cards[3].CardValue) //Check for set
                {
                    handValue = 3;
                    playerHand.RelevantCards.Add(cards[3]);

                    if (cards[1].CardValue == cards[4].CardValue) //Check for quads
                    {
                        handValue = 7;
                        playerHand.RelevantCards.Add(cards[4]);
                    }
                }
                else if (cards[3].CardValue == cards[4].CardValue) //Check for two pair
                {
                    handValue = 2;
                    playerHand.RelevantCards.Add(cards[3]);
                    playerHand.RelevantCards.Add(cards[4]);
                    if (cards[0].CardValue > cards[3].CardValue)  //Check for higher value between the two pairs
                    {
                        playerHand.RelevantHigh = cards[0];
                        playerHand.RelevantLow = cards[3];
                    }
                    else
                    {
                        playerHand.RelevantHigh = cards[3];
                        playerHand.RelevantLow = cards[0];
                    }
                }
            }//Third Pass - Starting at index 2, considering last 3 cards for pair combinations
            else if (cards[2].CardValue == cards[3].CardValue) //Check for pair
            {
                handValue = 1;
                playerHand.RelevantCards.Add(cards[2]);
                playerHand.RelevantCards.Add(cards[3]);
                playerHand.RelevantHigh = cards[2];

                if (cards[2].CardValue == cards[4].CardValue) //Check for set
                {
                    handValue = 3;
                    playerHand.RelevantCards.Add(cards[4]);
                }
            }//Fourth Pass - Starting at index 3, checking last 2 cards for a pair
            else if (cards[3].CardValue == cards[4].CardValue) //Check for pair
            {
                handValue = 1;
                playerHand.RelevantCards.Add(cards[3]);
                playerHand.RelevantCards.Add(cards[4]);
                playerHand.RelevantHigh = cards[3];
            }

            bool isFlush = cards.All(c => c.Suit == cards[0].Suit); //Check for flush

            bool isStraight = true; //Check for straight
            for (int i = 1; i < 5; i++)
            {
                if (cards[i].CardValue != (cards[i - 1].CardValue + 1))
                {
                    isStraight = false;
                    break;
                }
            }

            if (isFlush)
            {
                handValue = 5;
                for (int i = 0; i < 5; i++)
                {
                    playerHand.RelevantCards.Add(cards[i]);
                }

                if (isStraight) //Check for straight flush
                {
                    handValue = 8;
                }
            }
            else if (isStraight)
            {
                handValue = 4;
                for (int i = 0; i < 5; i++)
                {
                    playerHand.RelevantCards.Add(cards[i]);
                }
            }
           
            return handValue;
        }

        //Decides winner based on hand type value and breaks ties
        public List<PokerHand> ChooseWinner(PokerHand hand1, PokerHand hand2) 
        {
            //Assigns the value of each hand
            hand1.HandValue = ValueHand(hand1);
            hand2.HandValue = ValueHand(hand2);

            //Displayes the two players and their hands                  
            Console.Write($"{hand1.PlayerName}: ");
            foreach (Card card in hand1.Cards)
            {
                if (card.CardValue >= 11 && card.CardValue <= 14)
                {
                    Console.Write($"{faceCards[card.CardValue]}{card.Suit} ");
                }
                else
                {
                    Console.Write($"{card.CardValue}{card.Suit} ");
                }
            }
            Console.Write("| ");


            Console.Write($"{hand2.PlayerName}: ");
            foreach (Card card in hand2.Cards)
            {
                if (card.CardValue >= 11 && card.CardValue <= 14)
                {
                    Console.Write($"{faceCards[card.CardValue]}{card.Suit} ");
                }
                else
                {
                    Console.Write($"{card.CardValue}{card.Suit} ");
                }
            }


            //Players are added to the list based on who has a higher hand value
            List<PokerHand> winnersCricle = new List<PokerHand>();

            if (hand1.HandValue > hand2.HandValue)
            {
                winnersCricle.Add(hand1);
            }
            else if (hand1.HandValue < hand2.HandValue)
            {
                winnersCricle.Add(hand2);
            }
            else       //Tiebreaker based on RelevantHigh card
            {
                if (hand1.RelevantHigh?.CardValue != hand2.RelevantHigh?.CardValue)
                {
                    PokerHand winner = hand1.RelevantHigh?.CardValue > hand2.RelevantHigh?.CardValue ? hand1 : hand2;
                    winnersCricle.Add(winner);
                } //Compares RelevantLow card if RelevantHigh is the same
                else if (hand1.RelevantLow?.CardValue != hand2.RelevantLow?.CardValue)
                {
                    PokerHand winner = hand1.RelevantLow?.CardValue > hand2.RelevantLow?.CardValue ? hand1 : hand2;
                    winnersCricle.Add(winner);
                } //Runs high card TieBreaker if Relevant high and low are the same
                else
                {
                    winnersCricle = TieBreaker(hand1, hand2);
                }
            }

            return winnersCricle;
        }

        //Returns a list of hands populated by the hand with the higher card
        public List<PokerHand> TieBreaker(PokerHand hand1, PokerHand hand2)
        {
            bool tieBroken = false;
            List<PokerHand> winnersCricle = new List<PokerHand>();
            for (int i = 4; i > -1; i--)
            {
                if (hand1.Cards[i].CardValue > hand2.Cards[i].CardValue)
                {
                    hand1.RelevantCards.Clear();
                    hand1.RelevantCards.Add(hand1.Cards[i]);
                    hand1.RelevantHigh = hand1.Cards[i];
                    winnersCricle.Add(hand1);
                    tieBroken = true;
                    break;
                }

                if (hand1.Cards[i].CardValue < hand2.Cards[i].CardValue)
                {
                    hand2.RelevantCards.Clear();
                    hand2.RelevantCards.Add(hand2.Cards[i]);
                    hand2.RelevantHigh = hand2.Cards[i];
                    winnersCricle.Add(hand2);
                    tieBroken = true;
                    break;
                }

            }

            //If all cards are the same both hands are added
            if (!tieBroken)
            {
                winnersCricle.Add(hand1);
                winnersCricle.Add(hand2);
            }
            return winnersCricle;
        }

        //Displays the results of the two hands being compared and the winning hand's info
        public void DisplayResults(List<PokerHand> winners)
        {
            if (winners.Count == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Tie");
            }
            else
            {
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

                Console.WriteLine();
                Console.Write($"{winner.PlayerName} wins. - with {winner.HandType}: ");
                foreach (Card card in winner.RelevantCards)
                {
                    if (card.CardValue >= 11 && card.CardValue <= 14)
                    {
                        Console.Write($"{faceCards[card.CardValue]}{card.Suit} ");
                    }
                    else
                    {
                        Console.Write($"{card.CardValue}{card.Suit} ");
                    }
                }
            }
        }
    }
}
