using FileTypeGuesser.Matchers;

namespace FileTypeGuesser.FileTypes.Microsoft.Xml
{
    public class PowerPoint : FileType
    {
        public PowerPoint() : base("Microsoft PowerPoint", ".pptx", new MicrosoftXmlTypeMatcher("ppt"),true)
        {
        }
    }
}