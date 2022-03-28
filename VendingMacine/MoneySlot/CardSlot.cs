namespace VendingMacine.MoneySlot
{
    public interface ICardSlot
    {
        CardBalance GetCardBalance();
        void setCardBalance(CardBalance cardBalance);
    }

    public class CardSlot : ICardSlot
    {

        private ICardBalance _cardBalance;

        public CardSlot(ICardBalance cardBalance)
        {
            _cardBalance = cardBalance;
        }

        public CardBalance GetCardBalance()
        {
            return _cardBalance as CardBalance;
        }

        public void setCardBalance(CardBalance cardBalance)
        {
            this._cardBalance = cardBalance;
        }
    }
}
