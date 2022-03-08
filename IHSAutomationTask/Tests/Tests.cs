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

        [Test]
        public void Test2()
        {
            string nugetName = "NUnit";
            string version = "3.12.0";

            consolePage.AddNugetPackage(nugetName, version);

            Assert.True(consolePage.NugetWasAdded(nugetName));
        }
    }
}