using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Archive.Zip
{
    public class EmptyZip : FileType
    {
        public EmptyZip() : base("Empty zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	0x50, 0x4B, 0x05, 0x06}), true)
        {
        }
    }
}