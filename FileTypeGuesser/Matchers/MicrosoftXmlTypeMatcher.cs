using System.IO;
using System.IO.Packaging;
using System.Linq;

namespace FileTypeGuesser.Matchers
{
    public class MicrosoftXmlTypeMatcher : ExactFileTypeMatcher
    {
        private readonly string requiredExtension;
        private static readonly byte[] MicrosoftFileHeader = {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00};

        public MicrosoftXmlTypeMatcher(string requiredExtension) : base(MicrosoftFileHeader)
        {
            this.requiredExtension = requiredExtension;
        }

        protected override bool MatchesPrivate(Stream stream)
        {
            var package = Package.Open(stream, FileMode.Open, FileAccess.Read);
            var hasRequiredExtension = package
                .GetParts()
                .Select(packagePart => packagePart.Uri.ToString().Split('/')[1])
                .Any(str => str == requiredExtension);
            return hasRequiredExtension;
        }
    }
}