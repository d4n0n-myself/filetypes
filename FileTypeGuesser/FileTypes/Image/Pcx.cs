using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Image
{
    public class Pcx : FileType
    {
        public Pcx() : base("ZSOFT Paintbrush", ".pcx", new FuzzyFileTypeMatcher(new byte?[] {0x0A, null, 0x01}))
        {
        }
    }
}