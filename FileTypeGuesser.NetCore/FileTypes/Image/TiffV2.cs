using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Image
{
    public class TiffV2 : FileType
    {
        public TiffV2() : base("Text", ".tiff", new ExactFileTypeMatcher(new byte[] {0x49, 0x49, 0x2A, 0x00}))
        {
        }
    }
}