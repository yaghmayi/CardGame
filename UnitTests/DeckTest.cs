using CardGame.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGame.UnitTests
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void Mix()
        {
            Deck deck = new Deck();
            deck.Mix();

            Assert.AreEqual(52, deck.GetCradsCount());
            for (int i = 0; i < deck.GetCradsCount(); i++)
            {
                Assert.IsNotNull(deck.GetCard(i));
            }
        }

        [TestMethod]
        public void Sort()
        {
            Deck deck = new Deck();
            deck.Mix();
            deck.Sort();

            Assert.AreEqual(52, deck.GetCradsCount());

            for (int i = 0; i < deck.GetCradsCount()-1; i++)
            {
                Card card1 = deck.GetCard(i);
                Card card2 = deck.GetCard(i + 1);

                Assert.IsTrue(card1.Color <= card2.Color);
            }

            for (int i = 0; i < deck.GetCradsCount() - 1; i++)
            {
                Card card1 = deck.GetCard(i);
                Card card2 = deck.GetCard(i + 1);

                if (card1.Color == card2.Color)
                {
                    Assert.IsTrue(card1.Value <= card2.Value);
                }
            }
        }

        [TestMethod]
        public void PullCard()
        {
            Deck deck = new Deck();
            deck.Mix();

            int originalSize = deck.GetCradsCount();
            for (int i = 1; i <= originalSize; i++)
            {
                Card card = deck.PullCard();

                Assert.IsNotNull(card);
                Assert.AreEqual(originalSize - i, deck.GetCradsCount());
            }
            Assert.AreEqual(0, deck.GetCradsCount());

            Assert.IsNull(deck.PullCard());
            Assert.AreEqual(0, deck.GetCradsCount());
        }
    }
}
