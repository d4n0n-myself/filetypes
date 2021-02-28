using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Microsoft.Xml
{
    public class Excel : FileType
    {
        public Excel() : base("Microsoft Excel", ".xlsx", new MicrosoftXmlTypeMatcher("xl"),true)
        {
        }
    }
}