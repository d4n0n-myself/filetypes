using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileTypeGuesser.NetCore.Matchers;
using FileTypeGuesser.NetCore.Models;

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
            // new ("Text", ".pcx", new ExactFileTypeMatcher(new byte[] {})),
            
            new ("Zip archive", ".zip", new SubHeaderFileTypeMatcher(new byte[] {	0x50, 0x4B, 0x03, 0x04}, 19, new byte?[]{ 0x00, 0x00, 0x00}), true),
            new ("Zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	0x50, 0x4B, 0x05, 0x06}), true), // empty zip file
            new ("Zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	0x50, 0x4B, 0x07, 0x08}),true), // multivolume zip
            new ("Zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x01, 0x00}),true),
            new ("Zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	0x63, 0x00, 0x00, 0x00, 0x00, 0x00,}),true),
            // new ("Zip archive", ".zip", new ExactFileTypeMatcher(new byte[] {	})),
            new ("Rar archive", ".rar", new ExactFileTypeMatcher(new byte[] {	0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00}),true),
            new ("Rar archive", ".rar", new ExactFileTypeMatcher(new byte[] {	0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00}),true),
            new ("7z archive", ".7z", new ExactFileTypeMatcher(new byte[] {0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C})),
            
            // new ("Text", ".txt", new ExactFileTypeMatcher(new byte[] {})),
            new ("Text", ".rtf", new ExactFileTypeMatcher(new byte[] {0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31})),

            new("Portable Document Format", ".pdf", new RangeFileTypeMatcher(new ExactFileTypeMatcher(new byte[] {0x25, 0x50, 0x44, 0x46}), 1019)),
            
            new MicrosoftFileType("Microsoft Word (old)", ".doc", new byte?[] {0xEC, 0xA5, 0xC1, 0x00}),
            new MicrosoftFileType("Microsoft Excel (old)", ".xls", new byte?[] {0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00}),
            new MicrosoftFileType("Microsoft PowerPoint (old)", ".ppt", new byte?[] {0xFD, 0xFF, 0xFF, 0xFF, null, null, 0x00, 0x00}),
            
            new ("Microsoft Word", ".docx", new ExactFileTypeMatcher(new byte[] {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00}),true),
            new ("Microsoft Excel", ".xlsx", new ExactFileTypeMatcher(new byte[] {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00}),true),
            new ("Microsoft PowerPoint", ".pptx", new ExactFileTypeMatcher(new byte[] {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00}),true)
        };

        public FileType GetFileType(Stream fileContent)
        {
            return GetFileTypes(fileContent).FirstOrDefault() ?? FileType.Unknown;
        }

        private IEnumerable<FileType> GetFileTypes(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var first = stream.ReadByte();
            var second = stream.ReadByte();
            stream.Seek(0, SeekOrigin.Begin);
            var chars = Encoding.ASCII.GetChars(new[] { (byte)first, (byte)second});
            var isCompressed = chars[0] == 'P' && chars[1] == 'K';

            return knownFileTypes
                .Where(fileType => fileType.IsCompressed == isCompressed && fileType.Matches(stream))
                .ToArray();
        }
    }
}
