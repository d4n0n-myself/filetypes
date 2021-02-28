using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Image
{
    public class TiffV1 : FileType
    {
        public TiffV1() : base("Text", ".tiff", new ExactFileTypeMatcher(new byte[] {0x49, 0x20, 0x49}))
        {
        }
    }
}