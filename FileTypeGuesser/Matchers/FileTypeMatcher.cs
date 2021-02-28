using System;
using System.IO;

namespace FileTypeGuesser.Matchers
{
    public abstract class FileTypeMatcher
    {
        public bool Matches(Stream stream, bool resetPosition = true)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (!stream.CanRead || stream.Position != 0 && !stream.CanSeek)
            {
                throw new ArgumentException("File contents must be a readable stream", nameof(stream));
            }
            if (stream.Position != 0 && resetPosition)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            return MatchesPrivate(stream);
        }

        protected abstract bool MatchesPrivate(Stream stream);
    }
}
