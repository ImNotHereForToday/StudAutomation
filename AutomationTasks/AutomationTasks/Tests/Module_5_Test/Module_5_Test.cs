using AutomationTasks.Pages.Module_5_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace AutomationTasks.Tests.Module_5_Test
{
    [TestFixture("chrome")]
    class Module_5_Test : TestBase
    {
        public Module_5_Test(string browser) : base(browser, "http://the-internet.herokuapp.com/")
        {
        }

        [Test, Order(1)]
        [Property("quit", "true")]
        public void NewWindowHandling()
        {
            var module_5_Page = new Module_5_Page(Driver);
            module_5_Page.ClickOnLinkPage("/windows");
            module_5_Page.ClickOnLinkPage("/windows/new");
            module_5_Page.SwitchToOtherWindow();
            module_5_Page.AssertPageTitle("New Window");
            module_5_Page.CloseOtherWindow();
            module_5_Page.AssertWindowClosed();
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        public void FormAuthentication()
        {
            var module_5_Page = new Module_5_Page(Driver);
            module_5_Page.ClickOnLinkPage("/login");
            module_5_Page.InputCredentials();
            module_5_Page.ClickOnLoginButton();
            module_5_Page.AssertSuccessfulLogIn("You logged into a secure area!");
            Driver.Navigate().Back();
            module_5_Page.AssertLogInPage("Login Page");
            Driver.Navigate().Forward();
            module_5_Page.AssertSuccessfulLogIn("You logged into a secure area!");
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        public void NavigateToUrlAndRefresh()
        {
            var module_5_Page = new Module_5_Page(Driver);
            var baseUrl = "http://the-internet.herokuapp.com/";
            module_5_Page.ClickOnLinkPage("/dynamic_loading");
            module_5_Page.ClickOnLinkPage("/dynamic_loading/1");
            module_5_Page.ClickOnStartButton();
            module_5_Page.WaitForElementToBeDisplayed("Hello World!");
            var currentUrl = Driver.Url;
            Driver.Navigate().GoToUrl(baseUrl);
            Assert.That(currentUrl, Is.Not.EqualTo(baseUrl), "Did not navigate back to the homepage.");
            Driver.Navigate().Refresh();
        }

        //The test doesn't pass because of the window size Expected :800 actual : 802
        //Searched for any fixed , tried with js script still didin't help.
        [Test, Order(3)]
        [Property("quit", "true")]
        public void MaximizeWindowAndChangeWindowSize()
        {
            var module_5_Page = new Module_5_Page(Driver);
            int expectedWidth = 800;
            int expectedHeight = 600;
            module_5_Page.ClickOnLinkPage("/large");
            module_5_Page.ScrollToElement("//div[@id='page-footer']", "true");
            Driver.Manage().Window.Maximize();
            module_5_Page.ScrollToElement("//table", "false");
            module_5_Page.GetLastElement();
            Driver.Manage().Window.Size = new Size(expectedWidth, expectedHeight);
            Assert.That(Driver.Manage().Window.Size.Width, Is.EqualTo(expectedWidth));
            Assert.That(Driver.Manage().Window.Size.Height, Is.EqualTo(expectedHeight));
        }
    }
    public class Module_5_Test_HeadLessMode
    {
        [Test]
        public void HeadlessMode()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            using (IWebDriver headlessDriver = new ChromeDriver(options))
            {
                var module_5_Page = new Module_5_Page(headlessDriver);
                headlessDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
                module_5_Page.ClickOnLinkPage("/checkboxes");
                module_5_Page.SelectAndUnselectCheckBoxes();
            }
        }
    }
}
