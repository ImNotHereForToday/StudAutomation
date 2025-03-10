using AutomationTasks.Factory;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationTasks.Tests
{
    class TestBase
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public string browser;
        public string url;

        
        protected TestBase(string browser, string url) 
        {
            this.browser = browser;
            this.url = url;
        }

        public IWebDriver Driver => driver.Value;

        [SetUp]
        public void Setup()
        {
            driver.Value = BrowserFactory.GetDriver(browser);
            Driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Test.Properties.ContainsKey("quit") && driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value = null;
            }
        }
    }
}
