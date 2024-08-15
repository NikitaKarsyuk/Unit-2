using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace WikiTest
{
    internal class BaseTest
    {
        protected WebDriver driver;
        protected WebDriverWait wait = null;

        protected static readonly string preciseTextXpath = "//*[text()='{0}']";
        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";
        protected static readonly string relativePathFolder = @"C:\Users\valen\Downloads\";
        protected static readonly string url = "https://www.wikipedia.org/";
        protected static readonly int maxWait = 10;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", Path.GetFullPath(relativePathFolder));
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}