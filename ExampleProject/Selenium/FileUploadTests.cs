using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System.IO;
using System.Threading;

namespace ExampleProject.Selenium
{
    internal class FileUploadTests : BaseTest
    {
        private static readonly By fileUploadBtn = By.XPath(string.Format(preciseTextXpath, "File Upload"));
        private static readonly By chooseFileBtn = By.Id("file-upload");
        private static readonly By fileSubmitField = By.Id("file-submit");
        private static readonly By uploadedFileField = By.Id("uploaded-files");
        private static readonly string fileName = "UploadFileExample.txt";
        private static readonly string filePath = relativePathFolder + fileName;

        [Test]
        public void FileUploadTest()
        {
            driver.FindElement(fileUploadBtn).Click();
            FileInfo fileToUpload = new(filePath);
            driver.FindElement(chooseFileBtn).SendKeys(fileToUpload.FullName);
            driver.FindElement(fileSubmitField).Click();
            ClassicAssert.AreEqual(driver.FindElement(uploadedFileField).Text, fileName, 
                "File name is not correct or missing");
        }
    }
}
