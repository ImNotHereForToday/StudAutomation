using AutomationTasks.Pages;
using AutomationTasks.Pages.Module_1_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Tests
{
    class TestBase
    {
        private IWebDriver driver;
        private string browser;

        public static Module_1_Page module_1_page;
        public static LoginPage loginPage;

        public TestBase(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            driver = Factory.BrowserFactory.GetDriver(browser);


            module_1_page = new Module_1_Page(driver);
            loginPage = new LoginPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
