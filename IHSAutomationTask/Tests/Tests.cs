using System;
using IHSAutomationTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IHSAutomationTask
{
    public class Tests
    {
        public IWebDriver driver;
        public ConsolePage consolePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            consolePage = new ConsolePage(driver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
        }

        [Test]
        public void Test1()
        {
            consolePage.runBtn.Click();
            string output = consolePage.GetOutput();

            Assert.True(output == "Hello World");
        }
    }
}