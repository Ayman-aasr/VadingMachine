namespace VendingMacine.MoneySlot
{
    public interface ICoinSlot
    {
        void UpdateCoinsBalance(Money.ICoin coin);
         CoinsBalance GetCoinBalance();
    }

    public class CoinSlot : ICoinSlot
    {
        private ICoinsBalance CoinsBalance { get; set; }

        public CoinSlot(ICoinsBalance coinsBalance)
        {
            CoinsBalance = coinsBalance;
        }

        public void UpdateCoinsBalance(Money.ICoin coin)
        {

            switch (coin.Category)
            {
                case 'c':
                    switch (coin.CoinValue)
                    {
                        case 10:
                            CoinsBalance.NumberOf10c += 1;
                            break;
                        case 20:
                            CoinsBalance.NumberOf20c += 1;
                            break;
                        case 50:
                            CoinsBalance.NumberOf50c += 1;
                            break;
                    }
                    break;
                case '$':
                    {
                        CoinsBalance.NumberOf1Dollar += 1;
                        break;
                    }

            }

        }

        public CoinsBalance GetCoinBalance()
        {
            return CoinsBalance as CoinsBalance;
        }
    }
}
