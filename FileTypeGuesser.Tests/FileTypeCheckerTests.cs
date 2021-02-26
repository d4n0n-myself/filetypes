namespace FileTypeGuesser.Tests
{
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    using NUnit.Framework;

    using Properties;

    [TestFixture]
    public class FileTypeCheckerTests
    {
        private MemoryStream bitmap;

        private MemoryStream pdf;

        private FileTypeChecker checker;

        [TestFixtureSetUp]
        public void SetUp()
        {
            bitmap= new MemoryStream();
            // LAND.bmp is from http://www.fileformat.info/format/bmp/sample/
            Resources.LAND.Save(bitmap, ImageFormat.Bmp);
            // http://boingboing.net/2015/03/23/free-pdf-advanced-quantum-the.html
            pdf = new MemoryStream(Resources.advancedquantumthermodynamics);
            checker = new FileTypeChecker();
        }

        [Test]
        [Repeat(1000)]
        public void TestPdf()
        {
            var fileTypes = checker.GetFileTypes(pdf);
            CollectionAssert.AreEquivalent(
                new[] { "Portable Document Format" },
                fileTypes.Select(fileType => fileType.Name));
        }

        [Test]
        [Repeat(1000)]
        public void TestBmp()
        {
            var fileTypes = checker.GetFileTypes(bitmap);
            CollectionAssert.AreEquivalent(
                new[] { "Bitmap" },
                fileTypes.Select(fileType => fileType.Name));
        }
        
        [Test]
        public void TestWord()
        {
            var fileStream = File.Open($@"C:\Users\d.sibaev\Desktop\form.ExpertReview.Panel124.Panel144.ExpertReviewAttach[1].doc", FileMode.Open);
            
            var fileTypes = checker.GetFileTypes(fileStream);
            CollectionAssert.AreEquivalent(
                new[] { "Microsoft Word (old)" },
                fileTypes.Select(fileType => fileType.Name));
        }
        
        [Test]
        public void TestExcel()
        {
            var fileStream = File.Open($@"C:\Users\d.sibaev\Desktop\test.xls", FileMode.Open);
            var fileTypes = checker.GetFileTypes(fileStream);
            CollectionAssert.AreEquivalent(
                new[] { "Microsoft Word (old)" },
                fileTypes.Select(fileType => fileType.Name));
        }
    }
}
