using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes
{
    public class Rtf : FileType
    {
        public Rtf() : base("Text", ".rtf", new ExactFileTypeMatcher(new byte[] {0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31}))
        {
        }
    }
}