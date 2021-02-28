using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Archive.Rar
{
    public class RarV5 : FileType
    {
        public RarV5() : base("Rar archive v5", ".rar", new ExactFileTypeMatcher(new byte[] {	0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00}))
        {
        }
    }
}