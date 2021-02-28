using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileTypeGuesser.Matchers
{
    public class FuzzyFileTypeMatcher : FileTypeMatcher
    {
        private readonly byte?[] bytes;

        public FuzzyFileTypeMatcher(IEnumerable<byte?> bytes)
        {
            this.bytes = bytes.ToArray();
        }

        protected override bool MatchesPrivate(Stream stream)
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var b in bytes)
            {
                var c = stream.ReadByte();
                if (c == -1 || (b.HasValue && c != b.Value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
