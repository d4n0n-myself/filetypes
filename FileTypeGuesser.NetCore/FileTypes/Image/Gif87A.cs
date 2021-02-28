using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Image
{
    public class Gif87A : FileType
    {
        public Gif87A() : base("Graphics Interchange Format 87a", ".gif", new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61}))
        {
        }
    }
}