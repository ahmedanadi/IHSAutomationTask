using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IHSAutomationTask.Pages
{
    public class ConsolePage
    {
        IWebDriver driver;
        WebDriverWait wait;

        public ConsolePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
        }

        public IWebElement runBtn => driver.FindElement(By.Id("run-button"));

        public IWebElement runLoader => driver.FindElement(By.Id("stats-loader"));

        private IWebElement outputText => driver.FindElement(By.Id("output"));

        private IWebElement nugetPackagesSearch => driver.FindElement(By.ClassName("new-package"));
        private IWebElement nugetSearchSpinner => driver.FindElement(By.ClassName("nuget-search-spinner"));
        private IWebElement nugetSearchMenu => driver.FindElement(By.Id("menu"));
        private IWebElement addedNugetsList => driver.FindElement(By.ClassName("nuget-packages"));

        private IWebElement preloadingDialog => driver.FindElement(By.Id("preload-dialog"));

        public string GetOutput()
        {
            WaitForRunOutput();
            return this.outputText.Text;
        }

        public void AddNugetPackage(string nugetName, string version)
        {
            nugetPackagesSearch.SendKeys(nugetName);
            WaitForNugetSearch();

            var package = nugetSearchMenu.FindElement(By.XPath($"//a[contains(text(),'{nugetName}')]"));
            package.Click();

            var el = driver.FindElement(By.XPath($"//a[contains(text(),'{version}')]"));
            el.Click();
        }

        public bool NugetWasAdded(string nugetName)
        {
            WaitForLoadingDialog();
            var list = new List<IWebElement>(addedNugetsList.FindElements(By.TagName("li")));
            var el = list.Find(x => x.Text.Contains(nugetName));

            return el != null;
        }

        private void WaitForRunOutput()
        {
            wait.Until(x => runLoader.Displayed == false);
        }

        private void WaitForNugetSearch()
        {
            wait.Until(x => nugetSearchSpinner.Displayed == false);
        }

        private void WaitForLoadingDialog()
        {
            wait.Until(x => preloadingDialog.Displayed == false);
        }
    }
}
