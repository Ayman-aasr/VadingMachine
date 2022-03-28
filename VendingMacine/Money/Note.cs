namespace VendingMacine.Money
{
    public interface INote:IMoney
    {
        int NoteValue { get; set; }
    }

    public class Note : INote
    {
        public  Note()
        { }
        public int NoteValue { get; set; }
        public char Category { get; set; }
        public string Currency { get; set; }
    }
}
