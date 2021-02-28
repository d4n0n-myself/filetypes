namespace FileTypeGuesser.NetCore.FileTypes.Microsoft.Old
{
    public class SlideShow : Microsoft
    {
        public SlideShow() : base("Microsoft PowerPoint Slideshow (old)", ".pps", new byte?[] {0xFD, 0xFF, 0xFF, 0xFF, 165/*todo*/, null, 0x00, 0x00})
        {
        }
    }
}