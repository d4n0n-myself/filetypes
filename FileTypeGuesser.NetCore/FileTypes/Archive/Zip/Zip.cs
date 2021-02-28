using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Archive.Zip
{
    public class Zip : FileType
    {
        public Zip() : base("Zip archive, Ref. 1 & 2", ".zip",
            new SubHeaderFileTypeMatcher(new byte[] {0x50, 0x4B, 0x03, 0x04}, 19, new byte?[] {0x00, 0x00, 0x00}), true)
        {
        }
    }
}