using System.Collections.Generic;

namespace FileTypeGuesser.NetCore
{
	public class MicrosoftFileType : FileType
	{
		private static readonly IEnumerable<byte> Header = new byte[] {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1};

		public MicrosoftFileType(string name, string extension, IEnumerable<byte> subHeader) : base(name, extension,
			new MicrosoftFileTypeMatcher(Header, subHeader))
		{
		}
	}
}