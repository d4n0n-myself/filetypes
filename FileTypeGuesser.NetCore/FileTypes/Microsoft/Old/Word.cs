namespace FileTypeGuesser.NetCore.FileTypes.Microsoft.Old
{
    public class Word : Microsoft
    {
        public Word() : base("Microsoft Word (old)", ".doc", new byte?[] {0xEC, 0xA5, 0xC1, 0x00})
        {
        }
    }
}