using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileTypeGuesser.FileTypes;

namespace FileTypeGuesser
{
    public class FileTypeChecker
    {
        private static readonly IList<FileType> KnownFileTypes = GetKnownFileTypes();

        public FileType GetFileType(Stream fileContent)
        {
            return GetFileTypes(fileContent).FirstOrDefault() ?? FileType.Default;
        }

        private IEnumerable<FileType> GetFileTypes(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var first = stream.ReadByte();
            var second = stream.ReadByte();
            stream.Seek(0, SeekOrigin.Begin);
            var chars = Encoding.ASCII.GetChars(new[] {(byte) first, (byte) second});
            var isCompressed = chars[0] == 'P' && chars[1] == 'K';

            return KnownFileTypes
                .Where(fileType => fileType.IsCompressed == isCompressed && fileType.Matches(stream))
                .ToArray();
        }

        private static IList<FileType> GetKnownFileTypes()
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => !x.IsDynamic)
                .SelectMany(x => x.GetExportedTypes()
                    .Where(y => y.IsClass && !y.IsAbstract && y != typeof(Txt)) // todo Txt 
                    .Where(typeof(FileType).IsAssignableFrom))
                .ToArray();

            return types.Select(x => (FileType) Activator.CreateInstance(x)).ToList();
        }
    }
}