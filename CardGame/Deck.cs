using System;
using System.Collections.Generic;

namespace CardGame.Core
{
    public class Deck : IDeck
    {
        private List<Card> cards { get; set; }

        public Deck()
        {
            this.cards = new List<Card>();

            foreach (CardColor cardColor in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                {
                    Card card = new Card(cardColor, cardValue);

                    this.cards.Add(card);
                }
            }
        }

        public void Mix()
        {
            List<int> randomIndexes = new List<int>();

            for (int round = 1; round <= 20; round++)
            {
                do
                {
                    Random r = new Random();
                    int index = r.Next(this.cards.Count);

                    if (!randomIndexes.Contains(index))
                        randomIndexes.Add(index);
                }
                while (randomIndexes.Count == this.cards.Count);

                foreach (int index in randomIndexes)
                {
                    Card card = this.cards[index];

                    this.cards.Remove(card);
                    this.cards.Insert(0, card);
                }

                randomIndexes.Clear();
            }
        }

        public void Sort()
        {
            this.cards.Sort(new CardComparer());
        }

        public Card PullCard()
        {
            Card card = null;

            if (this.cards.Count > 0)
            {
                card = this.cards[0];
                this.cards.RemoveAt(0);
            }

            return card;
        }

        public int GetCardsCount()
        {
            return this.cards.Count;
        }

        public Card GetCard(int index)
        {
            if (index < this.GetCardsCount())
                return this.cards[index];
            else
                return null;

        }
    }
}
