using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerHands.Classes
{
    [TestClass]
    public class UnitTests
    {   //First three unit tests check the ValueHand() method
        [TestMethod]
        public void ValueHandTest()
        {
            PokerGame game1 = new PokerGame();

            Card card1 = new Card("2", 'H');
            Card card2 = new Card("3", 'D');
            Card card3 = new Card("5", 'S');
            Card card4 = new Card("9", 'C');
            Card card5 = new Card("K", 'D');
            List<Card> cards1 = new List<Card> { card1, card2, card3, card4, card5 };

            PokerHand hand1 = new PokerHand(cards1, "Player1");

            int result = game1.ValueHand(hand1);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ValueHandTest2()
        {
            PokerGame game1 = new PokerGame();

            Card card1 = new Card("2", 'H');
            Card card2 = new Card("4", 'S');
            Card card3 = new Card("4", 'C');
            Card card4 = new Card("2", 'D');
            Card card5 = new Card("4", 'H');
            List<Card> cards1 = new List<Card> { card1, card2, card3, card4, card5 };

            PokerHand hand1 = new PokerHand(cards1, "Player1");

            int result = game1.ValueHand(hand1);

            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void ValueHandTest3()
        {
            PokerGame game1 = new PokerGame();

            Card card1 = new Card("2", 'H');
            Card card2 = new Card("3", 'D');
            Card card3 = new Card("5", 'S');
            Card card4 = new Card("3", 'C');
            Card card5 = new Card("2", 'D');
            List<Card> cards1 = new List<Card> { card1, card2, card3, card4, card5 };

            PokerHand hand1 = new PokerHand(cards1, "Player1");

            int result = game1.ValueHand(hand1);

            Assert.AreEqual(2, result);
        }
        //Last three methods check the ChooseWinner() method
        [TestMethod]
        public void ChooseWinnerTest()
        {
            PokerGame game1 = new PokerGame();

            Card card1 = new Card("2", 'H');
            Card card2 = new Card("3", 'D');
            Card card3 = new Card("5", 'S');
            Card card4 = new Card("9", 'C');
            Card card5 = new Card("K", 'D');
            List<Card> cards1 = new List<Card> { card1, card2, card3, card4, card5 };

            PokerHand hand1 = new PokerHand(cards1, "Player1");
            hand1.HandValue = game1.ValueHand(hand1);

            Card card6 = new Card("2", 'C');
            Card card7 = new Card("3", 'H');
            Card card8 = new Card("4", 'S');
            Card card9 = new Card("8", 'C');
            Card card10 = new Card("A", 'H');
            List<Card> cards2 = new List<Card> { card6, card7, card8, card9, card10 };

            PokerHand hand2 = new PokerHand(cards2, "Player2");
            hand2.HandValue = game1.ValueHand(hand2);

            List<PokerHand> winners = game1.ChooseWinner(hand1, hand2);
            string result = winners[0].PlayerName;

            Assert.AreEqual("Player2", result);
        }
        [TestMethod]
        public void ChooseWinnerTest2()
        {
            PokerGame game1 = new PokerGame();

            Card card1 = new Card("2", 'H');
            Card card2 = new Card("4", 'S');
            Card card3 = new Card("4", 'C');
            Card card4 = new Card("2", 'D');
            Card card5 = new Card("4", 'H');
            List<Card> cards1 = new List<Card> { card1, card2, card3, card4, card5 };

            PokerHand hand1 = new PokerHand(cards1, "Player1");
            hand1.HandValue = game1.ValueHand(hand1);

            Card card6 = new Card("2", 'S');
            Card card7 = new Card("8", 'S');
            Card card8 = new Card("A", 'S');
            Card card9 = new Card("Q", 'S');
            Card card10 = new Card("3", 'S');
            List<Card> cards2 = new List<Card> { card6, card7, card8, card9, card10 };

            PokerHand hand2 = new PokerHand(cards2, "Player2");
            hand2.HandValue = game1.ValueHand(hand2);

            List<PokerHand> winners = game1.ChooseWinner(hand1, hand2);
            string result = winners[0].PlayerName;

            Assert.AreEqual("Player1", result);
        }
        [TestMethod]
        public void ChooseWinnerTest3()
        {
            PokerGame game1 = new PokerGame();

            Card card1 = new Card("2", 'H');
            Card card2 = new Card("3", 'D');
            Card card3 = new Card("5", 'S');
            Card card4 = new Card("9", 'C');
            Card card5 = new Card("K", 'D');
            List<Card> cards1 = new List<Card> { card1, card2, card3, card4, card5 };

            PokerHand hand1 = new PokerHand(cards1, "Player1");
            hand1.HandValue = game1.ValueHand(hand1);

            Card card6 = new Card("2", 'C');
            Card card7 = new Card("3", 'H');
            Card card8 = new Card("4", 'S');
            Card card9 = new Card("8", 'C');
            Card card10 = new Card("K", 'H');
            List<Card> cards2 = new List<Card> { card6, card7, card8, card9, card10 };

            PokerHand hand2 = new PokerHand(cards2, "Player2");
            hand2.HandValue = game1.ValueHand(hand2);

            List<PokerHand> winners = game1.ChooseWinner(hand1, hand2);
            string result = winners[0].PlayerName;

            Assert.AreEqual("Player1", result);
        }
    }
}