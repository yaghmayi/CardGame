using System;
using CardGame.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGame.UnitTests
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void MixTest()
        {
            Deck deck = new Deck();
            deck.Mix();

            Assert.AreEqual(52, deck.GetCardsCount());
            for (int i = 0; i < deck.GetCardsCount(); i++)
            {
                Assert.IsNotNull(deck.GetCard(i));
            }

            Console.WriteLine("Cards List (After Mix):");
            for (int i = 0; i < deck.GetCardsCount() - 1; i++)
            {
                Card card = deck.GetCard(i);
                Console.WriteLine(card);
            }
        }

        [TestMethod]
        public void SortTest()
        {
            Deck deck = new Deck();
            deck.Mix();
            deck.Sort();

            Assert.AreEqual(52, deck.GetCardsCount());

            for (int i = 0; i < deck.GetCardsCount()-1; i++)
            {
                Card card1 = deck.GetCard(i);
                Card card2 = deck.GetCard(i + 1);

                Assert.IsTrue(card1.Color <= card2.Color);
            }

            for (int i = 0; i < deck.GetCardsCount() - 1; i++)
            {
                Card card1 = deck.GetCard(i);
                Card card2 = deck.GetCard(i + 1);

                if (card1.Color == card2.Color)
                {
                    Assert.IsTrue(card1.Value <= card2.Value);
                }
            }

            Console.WriteLine("Cards List (After Sort):");
            for (int i = 0; i < deck.GetCardsCount() - 1; i++)
            {
                Card card = deck.GetCard(i);
                Console.WriteLine(card);
            }
        }

        [TestMethod]
        public void PullCardTest()
        {
            Deck deck = new Deck();
            deck.Mix();

            int originalSize = deck.GetCardsCount();
            for (int i = 1; i <= originalSize; i++)
            {
                Card card = deck.PullCard();

                Assert.IsNotNull(card);
                Assert.AreEqual(originalSize - i, deck.GetCardsCount());
            }
            Assert.AreEqual(0, deck.GetCardsCount());

            Assert.IsNull(deck.PullCard());
            Assert.AreEqual(0, deck.GetCardsCount());
        }
    }
}
