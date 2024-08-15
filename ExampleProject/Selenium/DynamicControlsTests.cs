using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace ExampleProject.Selenium
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By dynamicControl = By.XPath(string.Format(preciseTextXpath, "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format(preciseTextXpath, "Enable"));
        private static readonly By inputField = By.XPath("//*[@id='input-example']//input");
        private static readonly string randomValue = Guid.NewGuid().ToString();


        [Test]
        public void DynamicControlsTest()
        {
            driver.FindElement(dynamicControl).Click();
            driver.FindElement(enableBtn).Click();
            var inputeFieldElement = driver.FindElement(inputField);
            Assert.That(IsEnable(inputeFieldElement), "input is not enable");
            inputeFieldElement.SendKeys(randomValue);
            ClassicAssert.AreEqual(driver.FindElement(inputField).GetAttribute("value"), randomValue, "Text is not displayed");
        }
        private bool IsEnable(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (TimeoutException)
            {
                return false;
            }
            return true;
        }
    }
}
