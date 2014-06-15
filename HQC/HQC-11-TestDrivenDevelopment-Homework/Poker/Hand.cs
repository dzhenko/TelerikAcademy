namespace Poker
{
    using System;

    using System.Collections.Generic;

    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cards can not be null");
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this.cards);
        }

        public override bool Equals(object other)
        {
            if (other as Hand == null)
            {
                return false;
            }

            var otherAsHand = (Hand)other;

            foreach (var card in otherAsHand.Cards)
            {
                if (!this.Cards.Contains(card))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
