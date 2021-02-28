using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Archive.Zip
{
    public class MultiVolumeZip : FileType
    {
        public MultiVolumeZip() : base("MultiVolume zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	0x50, 0x4B, 0x07, 0x08}),true)
        {
        }
    }
}