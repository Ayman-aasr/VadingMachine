namespace VendingMacine.Money
{
    public interface ICoin:IMoney
    {
        int CoinValue { get; set; }
    }

    public class Coin : ICoin
    {
        public int CoinValue { get; set; }
        public char Category { get; set; }
        public string Currency { get; set; }
    }
}
