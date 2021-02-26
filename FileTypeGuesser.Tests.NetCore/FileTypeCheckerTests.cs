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
        
        [Test]
        public void TestPdf()
        {
            var fileStream = File.Open($@"../../../Resources/advancedquantumthermodynamics.pdf", FileMode.Open);
            var fileType = checker.GetFileType(fileStream);
            Assert.That(fileType != null);
            Assert.That(fileType.Extension == ".pdf");
        }
        
        [Test]
        public void TestBmp()
        {
            var fileStream = File.Open($@"../../../Resources/LAND.BMP", FileMode.Open);
            var fileType = checker.GetFileType(fileStream);
            Assert.That(fileType != null);
            Assert.That(fileType.Extension == ".bmp");
        }
        
        [Test]
        public void TestWord()
        {
            var fileStream = File.Open($@"C:\Users\d.sibaev\Desktop\form.ExpertReview.Panel124.Panel144.ExpertReviewAttach[1].doc", FileMode.Open);
            var fileType = checker.GetFileType(fileStream);
            Assert.That(fileType != null);
            Assert.That(fileType.Extension == ".doc");
        }
        
        [Test]
        public void TestExcel()
        {
            var fileStream = File.Open($@"C:\Users\d.sibaev\Desktop\test.xls", FileMode.Open);
            var fileType = checker.GetFileType(fileStream);
            Assert.That(fileType != null);
            Assert.That(fileType.Extension == ".xls");
        }
    }
}
