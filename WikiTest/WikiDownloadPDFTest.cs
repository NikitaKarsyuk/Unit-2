using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTest
{
    internal class WikiDownloadPDFTest : BaseTest
    {
        private static readonly By uniqueLocatorOfPage = By.XPath("//*[contains(@id,'wiki')]");
        private static readonly By searchString = By.Id("searchInput");
        private static readonly By submitBtn = By.XPath("//*[contains(@class, 'pure-button')]");
        private static readonly By toolsBtn = By.XPath("//input[contains(@id,'page-tools')]");
        private static readonly By downloadBtn = By.Id("coll-download-as-rl");
        private static readonly By fileDownloadBtn = By.XPath(string.Format(preciseTextXpath, "Download"));
        private static readonly By fileName = By.XPath(string.Format(partialTextXpath, ".pdf"));
        private string fullPathName = "";

        [Test]
        public void Test()
        {
            Assert.That(WaitForPageIsOpened(uniqueLocatorOfPage), "Page is not opened");
            driver.FindElement(searchString).SendKeys("Albert Einstein");
            driver.FindElement(submitBtn).Click();
            driver.FindElement(toolsBtn).Click();
            driver.FindElement(downloadBtn).Click();
            driver.FindElement(fileDownloadBtn).Click();
            fullPathName = relativePathFolder + driver.FindElement(fileName).Text.ToString();
            wait.Until(condition => IsFileDownloaded(fullPathName));
            Assert.That(IsFileDownloaded(fullPathName), "File is not downloaded");
        }

        private bool WaitForPageIsOpened(By uniqueElementOfThePageLocator)
        {
            IWebElement uniqueElementOfPage = wait.Until(driver => driver.FindElement(uniqueElementOfThePageLocator));
            return uniqueElementOfPage.Displayed;
        }

        private bool IsFileDownloaded(string filePath)
        {
            var newFile = new FileInfo(Path.GetFullPath(filePath));
            return newFile.Exists;
        }
    }
}
