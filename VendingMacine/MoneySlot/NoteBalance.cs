using System;
namespace VendingMacine.MoneySlot
{
    public interface INoteBalance
    {
        int NumberOf20Dollars { get; set; }
        int NumberOf50Dollars { get; set; }

        string ToString();
    }

    public class NoteBalance : INoteBalance
    {
        public int NumberOf20Dollars { get; set; }
        public int NumberOf50Dollars { get; set; }

        public NoteBalance()
        {
            this.NumberOf20Dollars = 0;
            this.NumberOf50Dollars = 0;
        }

        public override string ToString()
        {
            return $"NoteBalance[{Environment.NewLine}NumberOf20Dollars={NumberOf20Dollars},{Environment.NewLine} NumberOf50Dollars={NumberOf50Dollars} ]".Replace("[", "{").Replace("]", "}");
        }
    }
}
