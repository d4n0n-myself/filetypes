using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileTypeGuesser.NetCore
{
    public class FileTypeChecker
    {
        private readonly IList<FileType> knownFileTypes = new List<FileType>
        {
            new("Bitmap", ".bmp", new ExactFileTypeMatcher(new byte[] {0x42, 0x4d})),
            new("Portable Network Graphic", ".png", new ExactFileTypeMatcher(new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A})),
            new("JPEG", ".jpg", new ExactFileTypeMatcher(new byte[] {0xFF, 0xD8, 0xFF, 0xE0})),
            new("Graphics Interchange Format 87a", ".gif", new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61})),
            new("Graphics Interchange Format 89a", ".gif", new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61})),
            new ("Text", ".tiff", new ExactFileTypeMatcher(new byte[] {0x49, 0x20, 0x49})),
            // new ("Text", ".pcx", new ExactFileTypeMatcher()),
            
            // new ("Zip archive", ".zip", new ExactFileTypeMatcher()),
            // new ("Rar archive", ".rar", new ExactFileTypeMatcher()),
            // new ("7z archive", ".7z", new ExactFileTypeMatcher()),
            
            // new ("Text", ".txt", new ExactFileTypeMatcher()),
            // new ("Text", ".rtf", new ExactFileTypeMatcher()),

            new("Portable Document Format", ".pdf", new RangeFileTypeMatcher(new ExactFileTypeMatcher(new byte[] {0x25, 0x50, 0x44, 0x46}), 1019)),
            
            new MicrosoftFileType("Microsoft Word (old)", ".doc", new byte[] {0xEC, 0xA5, 0xC1, 0x00}),
            new MicrosoftFileType("Microsoft Word", ".docx", new byte[] {0xEC, 0xA5, 0xC1, 0x00}),
            new MicrosoftFileType("Microsoft Excel (old)", ".xls", new byte[] {0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00}),
            new MicrosoftFileType("Microsoft Excel", ".xlsx", new byte[] {0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00}),
            new MicrosoftFileType("Microsoft PowerPoint (old)", ".ppt", new byte[] {0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00}),
            new MicrosoftFileType("Microsoft PowerPoint", ".pptx", new byte[] {0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00})
        };

        public FileType GetFileType(Stream fileContent)
        {
            return GetFileTypes(fileContent).FirstOrDefault() ?? FileType.Unknown;
        }

        private IEnumerable<FileType> GetFileTypes(Stream stream)
        {
            return knownFileTypes.Where(fileType => fileType.Matches(stream)).ToArray();
        }
    }
}
