using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Image
{
    public class Jpg : FileType
    {
        public Jpg() : base("JPEG", ".jpg", new ExactFileTypeMatcher(new byte[] {0xFF, 0xD8, 0xFF, 0xE0}))
        {
        }
    }
}