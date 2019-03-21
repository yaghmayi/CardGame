using System.Collections.Generic;

namespace CardGame.Core
{
    public class CardComparer : IComparer<Card>
    {
        public int Compare(Card card1, Card card2)
        {
            if (card1.Color > card2.Color)
                return 1;
            else if (card1.Color < card2.Color)
                return -1;
            else
            {
                if (card1.Value > card2.Value)
                    return 1;
                else if (card1.Value < card2.Value)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
