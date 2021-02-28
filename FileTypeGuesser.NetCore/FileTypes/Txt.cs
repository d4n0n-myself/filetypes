namespace FileTypeGuesser.NetCore.FileTypes
{
    public class Txt : FileType
    {
        public Txt() : base("Text document", ".txt", null)
        {
        }
    }
}