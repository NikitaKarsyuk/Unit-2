using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;

namespace ExampleProject.Selenium
{
    internal class IFrameTests : BaseTest
    {
        private static readonly By framesBtn = By.XPath(string.Format(preciseTextXpath, "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format(preciseTextXpath, "iFrame"));
        private static readonly By editBtn = By.XPath(string.Format(preciseTextXpath, "Edit"));
        private static readonly By undoBtn = By.XPath(string.Format(preciseTextXpath, "Undo"));
        private static readonly By textField = By.Id("tinymce");

        private static readonly string textIsNotDisplayedMsg = "Text is not displayed";
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";
        private static readonly string iframeId = "mce_0_ifr";
        [Test]
        public void IFrameTest()
        {
            driver.FindElement(framesBtn).Click();
            driver.FindElement(iframeBtn).Click();
            driver.SwitchTo().Frame(iframeId);

            driver.FindElement(textField).SendKeys(randomValue);
            Assert.That(driver.FindElement(By.XPath(string.Format(preciseTextXpath, initText + randomValue))).Displayed,
                    textIsNotDisplayedMsg);

            driver.SwitchTo().DefaultContent();
            driver.FindElement(editBtn).Click();
            driver.FindElement(undoBtn).Click();

            driver.SwitchTo().Frame(iframeId);
            ClassicAssert.IsTrue(driver.FindElement(By.XPath(string.Format(preciseTextXpath, initText))).Displayed, textIsNotDisplayedMsg);
        }
    }
}