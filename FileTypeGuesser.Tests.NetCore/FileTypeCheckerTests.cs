using System.IO;
using System.Linq;
using FileTypeGuesser.NetCore;
using NUnit.Framework;

namespace FileTypeGuesser.Tests.NetCore
{
    [TestFixture]
    public class FileTypeCheckerTests
    {
        private FileTypeChecker checker;

        [SetUp]
        public void SetUp()
        {
            checker = new FileTypeChecker();
        }

        private static string GetPathToTestFileName(string extension)
        {
            return $@"../../../Resources/test.{extension}";
        }
        
        [Test]
        [TestCase("txt")]
        [TestCase("doc")]
        [TestCase("docx")]
        [TestCase("rtf")]
        [TestCase("xls")]
        [TestCase("xlsx")]
        [TestCase("pps")]
        [TestCase("ppt")]
        [TestCase("pptx")]
        [TestCase("pdf")]
        [TestCase("jpg")]
        [TestCase("bmp")]
        [TestCase("png")]
        [TestCase("tiff")]
        [TestCase("gif")]
        [TestCase("pcx")]
        [TestCase("zip")]
        [TestCase("rar")]
        [TestCase("7z")]
        public void TestExtension(string extension)
        {
            var fileStream = File.Open(GetPathToTestFileName(extension), FileMode.Open);
            var fileType = checker.GetFileType(fileStream);
            Assert.That(fileType != FileType.Unknown, $"Failed to identify {extension}");
            Assert.That(fileType.Extension == $".{extension}");
        }
    }
}
