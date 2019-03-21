namespace CardGame.Core
{
    public class Card
    {
        public CardColor Color { get; set; }
        public CardValue Value { get; set; }

        public Card(CardColor color, CardValue value)
        {
            Color = color;
            Value = value;
        }

        public override string ToString()
        {
            return this.Color + " " + this.getStringValue();
        }

        private string getStringValue()
        {
            if (this.Value.Equals(CardValue.Ace) || this.Value.Equals(CardValue.Jack) ||
                this.Value.Equals(CardValue.Queen) || this.Value.Equals(CardValue.King))
            {
                return this.Value.ToString().Substring(0, 1);
            }
            else
            {
                return ((int) this.Value).ToString();
            }
        }

    }
}
