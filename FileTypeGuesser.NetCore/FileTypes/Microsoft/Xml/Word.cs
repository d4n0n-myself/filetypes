using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Microsoft.Xml
{
    public class Word : FileType
    {
        public Word() : base("Microsoft Word", ".docx", new MicrosoftXmlTypeMatcher("word"),true)
        {
        }
    }
}