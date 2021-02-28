using FileTypeGuesser.NetCore.Matchers;

namespace FileTypeGuesser.NetCore.FileTypes.Microsoft.Xml
{
    public class PowerPoint : FileType
    {
        public PowerPoint() : base("Microsoft PowerPoint", ".pptx", new MicrosoftXmlTypeMatcher("ppt"),true)
        {
        }
    }
}