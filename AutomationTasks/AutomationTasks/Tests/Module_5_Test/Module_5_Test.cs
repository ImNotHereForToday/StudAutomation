using AutomationTasks.Pages.Module_5_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace AutomationTasks.Tests.Module_5_Test
{
    class Module_5_Test : TestBase
    {
        public Module_5_Test() : base("http://the-internet.herokuapp.com/")
        {
        }

        [Test, Order(1)]
        [Property("quit", "true")]
        public void NewWindowHandling()
        {
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
            module_5_Page.ClickOnLinkPage("/login");
            herokuappLogin.InputCredentials();
            herokuappLogin.ClickOnLoginButton();
            herokuappLogin.AssertLoginAlertMessage("You logged into a secure area!");
            Driver.Navigate().Back();
            herokuappLogin.AssertLogInPage("Login Page");
            Driver.Navigate().Forward();
            herokuappLogin.AssertLoginAlertMessage("You logged into a secure area!");
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        public void NavigateToUrlAndRefresh()
        {
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

        [Test, Order(3)]
        [Property("quit", "true")]
        public void MaximizeWindowAndChangeWindowSize()
        {
            int expectedWidth = 800;
            int expectedHeight = 600;
            module_5_Page.ClickOnLinkPage("/large");
            module_5_Page.ScrollToElement("//div[@id='page-footer']", "true");
            Driver.Manage().Window.Maximize();
            module_5_Page.ScrollToElement("//table", "false");
            module_5_Page.GetLastElement();
            Driver.Manage().Window.Size = new Size(expectedWidth, expectedHeight);
            Assert.That(Driver.Manage().Window.Size.Width, Is.EqualTo(802));
            Assert.That(Driver.Manage().Window.Size.Height, Is.EqualTo(602));
        }
    }
    public class Module_5_Test_HeadLessMode
    {
        [Test]
        [Property("quit", "true")]
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
