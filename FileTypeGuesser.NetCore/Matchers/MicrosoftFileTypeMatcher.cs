using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileTypeGuesser.NetCore
{
    public class MicrosoftFileTypeMatcher : FileTypeMatcher
    {
        private readonly byte[] header;
        private readonly byte[] subHeader;

        public MicrosoftFileTypeMatcher(IEnumerable<byte> header, IEnumerable<byte> subHeader)
        {
            this.header = header.ToArray();
            this.subHeader = subHeader.ToArray();
        }

        protected override bool MatchesPrivate(Stream stream)
        {
            if (header.Any(b => stream.ReadByte() != b))
            {
                return false;
            }

            stream.Seek(512, SeekOrigin.Begin);

            return subHeader.All(b => stream.ReadByte() == b);
        }
    }
}
