using VendingMacine.Money;

namespace VendingMacine.MoneySlot
{
    public interface INoteSlot
    {
        void UpdateNoteBalance(INote note);
        NoteBalance GetNoteBalance();
    }

    public class NoteSlot : INoteSlot
    {
        private readonly INoteBalance _noteBalance;
        public NoteSlot(INoteBalance noteBalance)
        {
            _noteBalance = noteBalance;
        }

        public NoteBalance GetNoteBalance()
        {
            return _noteBalance as NoteBalance;
        }

        public void UpdateNoteBalance(INote note)
        {

            switch (note.Category)
            {
                case '$':
                    switch (note.NoteValue)
                    {
                      
                        case 20:
                            _noteBalance.NumberOf20Dollars += 1;
                            break;
                        case 50:
                            _noteBalance.NumberOf50Dollars += 1;
                            break;
                    }
                    break;
            }

        }
    }
}
