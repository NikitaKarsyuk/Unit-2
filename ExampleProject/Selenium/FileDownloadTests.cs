using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace ExampleProject.Selenium
{
    internal class FileDownloadTests : BaseTest
    {
        private static readonly string fileName = "test.txt";

        private static readonly By fileDownloadBtn = By.XPath(string.Format(preciseTextXpath, "File Download"));
        private static readonly By fileNameField = By.XPath(string.Format(preciseTextXpath, fileName));
        private static readonly string filePath = relativePathFolder + fileName;
        private static readonly FileInfo downloadedFile = new(Path.GetFullPath(filePath));

        [Test]
        public void FileDownloadTest()
        {
            driver.FindElement(fileDownloadBtn).Click();
            Assert.That(driver.FindElement(fileNameField).Displayed, "File is not displayed");
            driver.FindElement(fileNameField).Click();
            wait.Until(condition => IsFileDownloaded(filePath));
            Assert.That(IsFileDownloaded(filePath), "File is not downloaded");
        }

        private bool IsFileDownloaded(string filePath)
        {
            var newFile = new FileInfo(Path.GetFullPath(filePath));
            return newFile.Exists;
        }

        [TearDown]
        public void DeleteFile()
        {
            Thread.Sleep(5000);
            if (downloadedFile.Exists)
            {
                downloadedFile.Delete();
            }
        }
    }
}
