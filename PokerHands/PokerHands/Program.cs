using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Classes
{
    public class PokerGame
    {
        
        public int ValueHand(PokerHand playerHand)
        {
            

            int handValue = 0;
            List<Card> cards = playerHand.Cards;


            //First Pass
            if (cards[0].CardValue == cards[1].CardValue) //Check for pair
            {
                handValue = 1;
                if (cards[0].CardValue == cards[2].CardValue) //Check for set
                {
                    handValue = 3;
                    if (cards[0].CardValue == cards[3].CardValue) //Check for quads
                    {
                        handValue = 7;
                    }
                    else if (cards[3].CardValue == cards[4].CardValue) //Check for full house
                    {
                        handValue = 6;
                    }
                }
                else if (cards[2].CardValue == cards[3].CardValue) //Check for two pair
                {
                    handValue = 2;
                    if (cards[2].CardValue == cards[4].CardValue) //Check for full house from remaining cards 
                    {
                        handValue = 6;
                    }
                }
                else if (cards[3].CardValue == cards[4].CardValue) //Check for two pair from remaining cards
                {
                    handValue = 2;
                }
            }//Second Pass
            else if (cards[1].CardValue == cards[2].CardValue) //Check for pair
            {
                handValue = 1;
                if (cards[1].CardValue == cards[3].CardValue) //Check for set
                {
                    handValue = 3;
                    if (cards[1].CardValue == cards[4].CardValue) //Check for quads
                    {
                        handValue = 7;
                    }
                }
                else if (cards[3].CardValue == cards[4].CardValue) //Check for two pair
                {
                    handValue = 2;
                }
            }//Third Pass
            else if (cards[2].CardValue == cards[3].CardValue) //Check for pair
            {
                handValue = 1;
                if (cards[2].CardValue == cards[4].CardValue) //Check for set
                {
                    handValue = 3;
                }
            }//Fourth Pass
            else if (cards[3].CardValue == cards[4].CardValue) //Check for pair
            {
                handValue = 1;
            }

            bool isFlush = cards.All(c => c.Suit == cards[0].Suit); //Check for flush

            bool isStraight = true; //Check for straight
            for (int i = 1; i < 5; i++) 
            {
                if (cards[i].CardValue != (cards[i -1].CardValue + 1))
                {
                    isStraight = false;
                    break;
                }
            }

            if (isFlush)
            {
                handValue = 5;
                if (isStraight) //Check for straight flush
                {
                    handValue = 8;
                }
            }
            else if (isStraight)
            {
                handValue = 4;
            }

            return handValue;

        }
        
        

        public List<PokerHand> ChooseWinner(PokerHand hand1, PokerHand hand2) //Decides winner based on hand type value
        {
            List<PokerHand> players = new List<PokerHand> {hand1, hand2};
            //int highCard = players[1].Cards[4].CardValue;
            bool tieBroken = true;
            List<PokerHand> winnersCricle = new List<PokerHand>();
            
            if (hand1.HandValue > hand2.HandValue)
            {
                winnersCricle.Add(hand1);
            }
            else if (hand1.HandValue < hand2.HandValue)
            {
                winnersCricle.Add(hand2);
            }
            else                                            //Tiebraker with high card
            {
                hand1.HandValue = 0;
                hand2.HandValue = 0;
                tieBroken = false;
                for (int i = 4; i > -1; i--)
                {
                    if (hand1.Cards[i].CardValue > hand2.Cards[i].CardValue)
                    {       
                        winnersCricle.Add(hand1);
                        tieBroken = true;
                        break;
                    }
                    
                    if (hand1.Cards[i].CardValue < hand2.Cards[i].CardValue)
                    {
                        winnersCricle.Add(hand2);
                        tieBroken = true;
                        break;
                    }

                }
                
                if (!tieBroken)
                {
                    winnersCricle.Add(hand1);
                    winnersCricle.Add(hand2);
                }
                
            }

            return winnersCricle;      
        }

    }
}
