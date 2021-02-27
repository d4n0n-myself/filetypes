using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileTypeGuesser.NetCore.Matchers
{
    public class SubHeaderFileTypeMatcher : FileTypeMatcher
    {
        private readonly byte[] header;
        private readonly byte?[] subHeader;
        private readonly long subHeaderPosition;

        public SubHeaderFileTypeMatcher(IEnumerable<byte> header, long subHeaderPosition, IEnumerable<byte?> subHeader)
        {
            this.subHeaderPosition = subHeaderPosition;
            this.header = header.ToArray();
            this.subHeader = subHeader.ToArray();
        }

        protected override bool MatchesPrivate(Stream stream)
        {
            if (header.Any(b => stream.ReadByte() != b))
            {
                return false;
            }

            stream.Seek(subHeaderPosition, SeekOrigin.Begin);

            return subHeader.All(b => stream.ReadByte() == b);
        }
    }
}
