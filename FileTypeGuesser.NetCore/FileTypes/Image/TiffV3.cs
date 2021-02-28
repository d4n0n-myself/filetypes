using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Image
{
    public class TiffV3 : FileType
    {
        public TiffV3() : base("Text", ".tiff", new ExactFileTypeMatcher(new byte[] {0x4D, 0x4D, 0x00, 0x2A}))
        {
        }
    }
}