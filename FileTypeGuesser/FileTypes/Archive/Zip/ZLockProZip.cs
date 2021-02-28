using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Archive.Zip
{
    public class ZLockProZip : FileType
    {
        public ZLockProZip() : base("ZLock Pro Zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x01, 0x00}),true)
        {
        }
    }
}