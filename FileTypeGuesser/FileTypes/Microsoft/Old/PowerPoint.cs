namespace FileTypeGuesser.FileTypes.Microsoft.Old
{
    public class PowerPoint : Microsoft
    {
        public PowerPoint() : base("Microsoft PowerPoint (old)", ".ppt", new byte?[] {0xFD, 0xFF, 0xFF, 0xFF, 166 /*todo*/, null, 0x00, 0x00})
        {
        }
    }
}