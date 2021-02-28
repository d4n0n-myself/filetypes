using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Microsoft.Xml
{
    public class Word : FileType
    {
        public Word() : base("Microsoft Word", ".docx", new MicrosoftXmlTypeMatcher("word"),true)
        {
        }
    }
}