using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Image
{
    public class Gif89A : FileType
    {
        public Gif89A() : base("Graphics Interchange Format 89a", ".gif", new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61}))
        {
        }
    }
}