namespace VendingMacine.Money
{
    public interface IMoney
    {
        char Category { get; set; }
        string Currency { get; set; }
    }

    public class Money : IMoney
    {
        public Money()
        { }
        public string Currency { get; set; }
        public char Category { get; set; }
    }
}
