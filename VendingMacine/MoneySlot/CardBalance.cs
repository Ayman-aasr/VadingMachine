namespace VendingMacine.MoneySlot
{
    public interface ICardBalance
    {
        double GetCollectedFromCard();
        void SetCollectedFromCard(double collectedFromCard);
        string ToString();
    }

    public class CardBalance : ICardBalance
    {
        private double _collectedFromCard;

        public CardBalance()
        {
            this._collectedFromCard = 0.0;
        }

        public double GetCollectedFromCard()
        {
            return _collectedFromCard;
        }

        public void SetCollectedFromCard(double collectedFromCard)
        {
            _collectedFromCard = collectedFromCard;
        }

        public override string ToString()
        {
            return $"CardBalance[ncollectedFromCard={_collectedFromCard}]".Replace("[", "{").Replace("]", "}");
        }
    }
}
