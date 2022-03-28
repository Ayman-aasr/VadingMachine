using System;

namespace VendingMacine.MoneySlot
{
    public interface ICoinsBalance
    {
        int NumberOf10c { get; set; }
        int NumberOf1Dollar { get; set; }
        int NumberOf20c { get; set; }
        int NumberOf50c { get; set; }

        string ToString();
    }

    public class CoinsBalance : ICoinsBalance
    {
        public int NumberOf10c { get; set; }
        public int NumberOf20c { get; set; }
        public int NumberOf50c { get; set; }
        public int NumberOf1Dollar { get; set; }

        public CoinsBalance()
        {
            this.NumberOf10c = 0;
            this.NumberOf20c = 0;
            this.NumberOf50c = 0;
            this.NumberOf1Dollar = 0;
        }
        public override string ToString()
        {
            var result = $"CoinsBalance[{System.Environment.NewLine}numberOf10c={NumberOf10c}, {System.Environment.NewLine}numberOf20c={NumberOf20c},{System.Environment.NewLine}numberOf50c={NumberOf50c},{Environment.NewLine}numberOf1Dollar={NumberOf1Dollar}]";

            return result.Replace("[", "{").Replace("]", "}");
        }
    }
}
