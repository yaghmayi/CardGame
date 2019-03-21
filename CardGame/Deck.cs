using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            this.Cards = new List<Card>();

            foreach (CardColor cardColor in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                {
                    Card card = new Card(cardColor, cardValue);

                    this.Cards.Add(card);
                }
            }
        }

        public void Mix()
        {
            List<int> randomIndexes = new List<int>();

            do
            {
                Random r = new Random();
                int index = r.Next(this.Cards.Count);

                if (!randomIndexes.Contains(index))
                    randomIndexes.Add(index);
            }
            while (randomIndexes.Count == this.Cards.Count);

            foreach (int index in randomIndexes)
            {
                Card card = this.Cards[index];

                this.Cards.Remove(card);
                this.Cards.Insert(0, card);
            }
        }

        public void Sort()
        {
            this.Cards.Sort(new CardComparer());
        }

        public Card PullCard()
        {
            Card card = null;

            if (this.Cards.Count > 0)
            {
                card = this.Cards[0];
                this.Cards.RemoveAt(0);
            }

            return card;
        }
    }
}
