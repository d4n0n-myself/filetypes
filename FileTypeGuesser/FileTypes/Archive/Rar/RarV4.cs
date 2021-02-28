using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Archive.Rar
{
    public class RarV4 : FileType
    {
        public RarV4() : base("Rar archive v4.x", ".rar", new ExactFileTypeMatcher(new byte[] {0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00}))
        {
        }
    }
}