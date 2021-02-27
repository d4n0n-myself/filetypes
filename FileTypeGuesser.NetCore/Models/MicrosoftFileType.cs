using System.Collections.Generic;
using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.Models
{
	public class MicrosoftFileType : FileType
	{
		private static readonly IEnumerable<byte> Header = new byte[] {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1};

		public MicrosoftFileType(string name, string extension, IEnumerable<byte?> subHeader, bool isCompressed = false) 
			: base(name, extension, new SubHeaderFileTypeMatcher(Header, 512, subHeader), isCompressed)
		{
		}
	}
}