using System.IO;

namespace FileTypeGuesser.Matchers
{
    public class RangeFileTypeMatcher : FileTypeMatcher
    {
        private readonly FileTypeMatcher matcher;

        private readonly int maximumStartLocation;

        public RangeFileTypeMatcher(FileTypeMatcher matcher, int maximumStartLocation)
        {
            this.matcher = matcher;
            this.maximumStartLocation = maximumStartLocation;
        }

        protected override bool MatchesPrivate(Stream stream)
        {
            for (var i = 0; i < maximumStartLocation; i++)
            {
                stream.Position = i;
                if (matcher.Matches(stream, false))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
