using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace ExampleProject.Selenium
{
    internal class DataTableTests : BaseTest
    {
        private static readonly By sortableDataTables = By.XPath(string.Format(preciseTextXpath, "Sortable Data Tables"));
        private static readonly By dueColumn = By.XPath("//*[@id='table1']//td[4]");
        private readonly double expectedSum = 251.00;
        private static readonly string currencyRegex = "[^\\d.]";
        [Test]
        public void DataTableTest()
        {
            driver.FindElement(sortableDataTables).Click();
            var elementsList = driver.FindElements(dueColumn);
            var actualSum = 0.0;

            foreach (var element in elementsList)
            {
                actualSum += Convert.ToDouble(Regex.Replace(element.Text, currencyRegex, "").Replace(".",","));
            }

            ClassicAssert.AreEqual(expectedSum, actualSum, 
                "Sum is not corrent"); 
        }
    }
}
