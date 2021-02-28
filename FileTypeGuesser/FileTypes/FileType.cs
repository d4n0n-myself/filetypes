using System.IO;
using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes
{
    public abstract class FileType
    {
        private readonly FileTypeMatcher fileTypeMatcher;

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public string Name { get; }

        public string Extension { get; }

        public bool IsCompressed { get; }
        
        public static FileType Default { get; } = new Txt();

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
