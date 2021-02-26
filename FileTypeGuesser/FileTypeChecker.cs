﻿namespace FileTypeGuesser
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileTypeChecker
    {
        private static readonly IList<FileType> knownFileTypes = new List<FileType>
        {
            // new FileType("Bitmap", ".bmp", new ExactFileTypeMatcher(new byte[] {0x42, 0x4d})),
            // new FileType("Portable Network Graphic", ".png",
            //     new ExactFileTypeMatcher(new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A})),
            // new FileType("JPEG", ".jpg",
            //     new FuzzyFileTypeMatcher(new byte?[] {0xFF, 0xD, 0xFF, 0xE0, null, null, 0x4A, 0x46, 0x49, 0x46, 0x00})),
            // new FileType("Graphics Interchange Format 87a", ".gif",
            //     new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61})),
            // new FileType("Graphics Interchange Format 89a", ".gif",
            //     new ExactFileTypeMatcher(new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61})),
            // new FileType("Portable Document Format", ".pdf", new RangeFileTypeMatcher(new ExactFileTypeMatcher(new byte[] { 0x25, 0x50, 0x44, 0x46 }), 1019)),
            new FileType("Microsoft Word (old)", ".doc", new ExactFileTypeMatcher(new byte[] {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1}))
            // ... Potentially more in future
        };

        public FileType GetFileType(Stream fileContent)
        {
            return GetFileTypes(fileContent).FirstOrDefault() ?? FileType.Unknown;
        }

        public IEnumerable<FileType> GetFileTypes(Stream stream)
        {
            return knownFileTypes.Where(fileType => fileType.Matches(stream));
        }
    }
}
