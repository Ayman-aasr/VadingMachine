using VendingMacine.Money;

namespace VendingMacine.MoneySlot
{
    public interface IMoneySlot
    {
        double BalanceInUSD { get; set; }
        string Currency { get; set; }

        void CalculateBalanceInUSD();
        void UpdateBalance(IMoney money);
         ICoinSlot GetCoinSlot();
         INoteSlot GetNoteSlot();
         ICardSlot GetCardSlot();
    }

    public class MoneySlot : IMoneySlot
    {

        private readonly ICoinSlot _coinSlot;
        private readonly INoteSlot _noteSlot;
        private readonly ICardSlot _cardSlot;

        public double BalanceInUSD { get; set; }
        public string Currency { get; set; }

        public MoneySlot(ICoinSlot coinSlot, INoteSlot noteSlot, ICardSlot cardSlot)
        {
            _coinSlot = coinSlot;
            _noteSlot = noteSlot;
            _cardSlot = cardSlot;


        }



        public void UpdateBalance(IMoney money)
        {

           
            if (money.GetType() == typeof(Coin))

            {
                ICoin c = money as ICoin;

                _coinSlot.UpdateCoinsBalance(c);
            }
            else if (money.GetType() == typeof(Note))//if (money is Note)
            {
                INote n = money as INote;
                _noteSlot.UpdateNoteBalance(n);
            }
            CalculateBalanceInUSD();
        }

        public void CalculateBalanceInUSD()
        {
            var coinsSum = (_coinSlot.GetCoinBalance().NumberOf1Dollar * 1)
                + (_coinSlot.GetCoinBalance().NumberOf10c * 0.1)
                + (_coinSlot.GetCoinBalance().NumberOf20c * 0.2)
                + (_coinSlot.GetCoinBalance().NumberOf50c * 0.5);

            double noteSum = (_noteSlot.GetNoteBalance().NumberOf20Dollars * 20) + (_noteSlot.GetNoteBalance().NumberOf50Dollars * 50);

            BalanceInUSD = (coinsSum + noteSum + _cardSlot.GetCardBalance().GetCollectedFromCard());
        }

        public ICoinSlot GetCoinSlot()
        {
            return _coinSlot;
        }

        public INoteSlot GetNoteSlot()
        {
            return _noteSlot;
        }

        public ICardSlot GetCardSlot()
        {
            return _cardSlot ;
        }
    }
}
