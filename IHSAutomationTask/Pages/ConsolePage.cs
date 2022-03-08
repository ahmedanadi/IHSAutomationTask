using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IHSAutomationTask.Pages
{
    public class ConsolePage
    {
        IWebDriver driver;

        public ConsolePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement runBtn => driver.FindElement(By.Id("run-button"));

        public IWebElement runLoader => driver.FindElement(By.Id("stats-loader"));

        private IWebElement outputText => driver.FindElement(By.Id("output"));

        public string GetOutput()
        {
            WaitForOutput();
            return this.outputText.Text;
        }

        private void WaitForOutput()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.Until(x => runLoader.Displayed == false);
        }

    }
}
