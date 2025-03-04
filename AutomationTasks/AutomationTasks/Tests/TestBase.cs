using AutomationTasks.Pages;
using AutomationTasks.Pages.Module_1_Page;
using AutomationTasks.Pages.Module_2_Page;
using AutomationTasks.Pages.Module_3_Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTasks.Tests
{
    class TestBase
    {
        public IWebDriver driver;
        private string browser;

        public static Module_1_Page module_1_Page;
        public static LoginPage loginPage;
        public static Module_2_Page module_2_Page;
        public static Module_3_Page module_3_Page;

        public TestBase(string browser)
        {
            this.browser = browser;
        }

        private void InitializeDriver()
        {
            if (driver == null)
            {
                driver = Factory.BrowserFactory.GetDriver(browser);
                loginPage = new LoginPage(driver);
                module_1_Page = new Module_1_Page(driver);
                module_2_Page = new Module_2_Page(driver);
                module_3_Page = new Module_3_Page(driver);
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeDriver();
        }

        [SetUp]
        public void Setup()
        {
            InitializeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        // This method is used to close the browser after the test is done
        // How to use :
        // Add [Property("quit", "true")] to each test that you want to close the browser after it is done
        // Example in : Module_2_Test.cs
        [TearDown]
        public void TearDown()
        {
            bool shouldQuit = TestContext.CurrentContext.Test.Properties.ContainsKey("quit");

            if (shouldQuit)
            {
                driver.Quit();
                driver = null; 
            }
            else
            {
                driver.Navigate().Refresh(); 
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
