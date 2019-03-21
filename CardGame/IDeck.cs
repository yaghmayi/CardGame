using CardGame.Core;

namespace CardGame
{
    public interface IDeck
    {
        void Sort();
        void Mix();
        Card PullCard();
    }
}
