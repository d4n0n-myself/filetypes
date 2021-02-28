using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes
{
    public class Pdf : FileType
    {
        public Pdf() : base("Portable Document Format", ".pdf", new RangeFileTypeMatcher(new ExactFileTypeMatcher(new byte[] {0x25, 0x50, 0x44, 0x46}), 1019))
        {
        }
    }
}