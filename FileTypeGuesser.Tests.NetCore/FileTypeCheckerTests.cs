using System.IO;
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

        private static string GetPathToTestFileName(string fileNameWithExtension)
        {
            return $@"../../../Resources/{fileNameWithExtension}";
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
        [TestCase("zip", "empty")]
        [TestCase("rar")]
        [TestCase("7z")]
        public void TestExtension(string extension, string testFileName = null)
        {
            testFileName ??= "test";
            var fileStream = File.Open(GetPathToTestFileName(testFileName + "." + extension), FileMode.Open);
            var fileType = checker.GetFileType(fileStream);
            Assert.That(fileType.Extension == $".{extension}", $"Extension doesn't match: {extension} != {fileType.Extension}");
        }
    }
}