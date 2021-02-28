using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Image
{
    public class Bitmap : FileType
    {
        public Bitmap() : base("Bitmap", ".bmp", new ExactFileTypeMatcher(new byte[] {0x42, 0x4d}))
        {
        }
    }
}