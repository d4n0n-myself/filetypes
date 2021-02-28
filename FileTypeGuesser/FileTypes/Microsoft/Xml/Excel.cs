using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Microsoft.Xml
{
    public class Excel : FileType
    {
        public Excel() : base("Microsoft Excel", ".xlsx", new MicrosoftXmlTypeMatcher("xl"),true)
        {
        }
    }
}