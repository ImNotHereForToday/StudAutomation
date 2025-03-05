using AutomationTasks.Pages;
using AutomationTasks.Pages.Module_1_Page;
using AutomationTasks.Pages.Module_2_Page;
using AutomationTasks.Pages.Module_3_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using AutomationTasks.Factory;

namespace AutomationTasks.Tests
{
    class TestBase
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private string browser;

        public TestBase(string browser)
        {
            this.browser = browser;
        }

        public IWebDriver Driver => driver.Value;

        [SetUp]
        public void Setup()
        {
            driver.Value = BrowserFactory.GetDriver(browser);
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
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
