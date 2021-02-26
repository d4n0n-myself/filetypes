using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileTypeGuesser.NetCore
{
    public class ExactFileTypeMatcher : FileTypeMatcher
    {
        private readonly byte[] bytes;

        public ExactFileTypeMatcher(IEnumerable<byte> bytes)
        {
            this.bytes = bytes.ToArray();
        }

        protected override bool MatchesPrivate(Stream stream)
        {
            return bytes.All(b => stream.ReadByte() == b);
        }
    }
}
