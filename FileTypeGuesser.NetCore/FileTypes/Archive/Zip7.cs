using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Archive
{
    public class Zip7 : FileType
    {
        public Zip7() : base("7z archive", ".7z",
            new ExactFileTypeMatcher(new byte[] {0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C}))
        {
        }
    }
}