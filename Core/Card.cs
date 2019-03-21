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
            return this.getColorString() + " " + this.getStringValue();
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

        private string getColorString()
        {
            char clover = '\u2663';
            char spade = '\u2660';
            char diamond = '\u2666';
            char heart = '\u2665';

            string colorStr = null;

            switch (this.Color)
            {
                case CardColor.Heart:
                    colorStr = heart.ToString();
                break;

                case CardColor.Diamond:
                    colorStr = diamond.ToString();
                break;

                case CardColor.Spade:
                    colorStr = spade.ToString();
                break;

                case CardColor.Clover:
                    colorStr = clover.ToString();
                break;
            }

            return colorStr;
        }

    }
}
