using System.IO;
using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.Models
{
    public class FileType
    {
        private readonly FileTypeMatcher fileTypeMatcher;

        public string Name { get; }

        public string Extension { get; }

        public bool IsCompressed { get; }
        
        public static FileType Unknown { get; } = new("unknown", string.Empty, null);

        public FileType(string name, string extension, FileTypeMatcher matcher, bool isCompressed = false)
        {
            Name = name;
            Extension = extension;
            fileTypeMatcher = matcher;
            IsCompressed = isCompressed;
        }

        public bool Matches(Stream stream)
        {
            return fileTypeMatcher == null || fileTypeMatcher.Matches(stream);
        }
    }
}
