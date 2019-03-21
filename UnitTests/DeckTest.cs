using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void Mix()
        {
            Deck deck = new Deck();
            deck.Mix();

            Assert.IsNotNull(deck.Cards);
            Assert.AreEqual(52, deck.Cards.Count);
        }

        [TestMethod]
        public void Sort()
        {
            Deck deck = new Deck();
            deck.Mix();
            deck.Sort();

            Assert.IsNotNull(deck.Cards);
            Assert.AreEqual(52, deck.Cards.Count);

            for (int i = 0; i < deck.Cards.Count-1; i++)
            {
                Card card1 = deck.Cards[i];
                Card card2 = deck.Cards[i + 1];

                Assert.IsTrue(card1.Color <= card2.Color);
            }

            for (int i = 0; i < deck.Cards.Count - 1; i++)
            {
                Card card1 = deck.Cards[i];
                Card card2 = deck.Cards[i + 1];

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

            int cardsCount = deck.Cards.Count;
            for (int i = 1; i <= cardsCount; i++)
            {
                Card card = deck.PullCard();

                Assert.IsNotNull(card);
                Assert.AreEqual(cardsCount - i, deck.Cards.Count);
            }
            Assert.AreEqual(0, deck.Cards.Count);

            Assert.IsNull(deck.PullCard());
            Assert.AreEqual(0, deck.Cards.Count);
        }
    }
}
