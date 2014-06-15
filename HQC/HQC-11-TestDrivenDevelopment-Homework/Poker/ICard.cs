namespace Poker
{
    using System;
    public interface ICard : IComparable<ICard>
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}
