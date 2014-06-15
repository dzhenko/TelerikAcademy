namespace Poker
{
    using System;

    public class Card : ICard, IComparable<ICard>
    {
        private CardFace face;
        private CardSuit suit;

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }


        public CardFace Face
        {
            get
            {
                return this.face;
            }

            private set
            {
                // no need for check - a card can not be created with null value
                this.face = value;
            }
        }

        public CardSuit Suit
        {
            get
            {
                return this.suit;
            }

            private set
            {
                // no need for check - a card can not be created with null value
                this.suit = value;
            }
        }

        public override bool Equals(object other)
        {
            if (other as Card == null)
            {
                return false;
            }

            var otherAsCard = (Card)other;

            var areSame = this.Face == otherAsCard.Face && this.Suit == otherAsCard.Suit;
            return areSame;
        }

        public int CompareTo(ICard other)
        {
            var faceComparison = ((int)this.Face).CompareTo((int)other.Face);

            if (faceComparison == 0)
            {
                var suitComparison = ((int)this.Suit).CompareTo((int)other.Suit);
                return suitComparison;
            }
            else
            {
                return faceComparison;
            }
        }

        public override string ToString()
        {
            var faceAsInt = (int)this.Face;
            var symbol = this.getSuitSymbol(this.Suit);

            if (faceAsInt <= 10)
            {
                return faceAsInt.ToString() + symbol;
            }
            else
            {
                var firstLetter = this.Face.ToString()[0];
                return firstLetter.ToString() + symbol;
            }
        }

        private char getSuitSymbol(CardSuit suit)
        {
            switch (suit)
            {
                case CardSuit.Clubs: return '\x05';  //♣  
                case CardSuit.Diamonds: return '\x04';  //♦
                case CardSuit.Hearts: return '\x03'; //♥
                default: return '\x06';  //♠
            }
        }
    }
}
