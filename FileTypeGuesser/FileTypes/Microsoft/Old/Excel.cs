namespace FileTypeGuesser.FileTypes.Microsoft.Old
{
    public class Excel : Microsoft
    {
        public Excel() : base("Microsoft Excel (old)", ".xls", new byte?[] {0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00})
        {
        }
    }
}