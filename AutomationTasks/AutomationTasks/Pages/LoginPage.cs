using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTasks.Pages
{
    class LoginPage : PageBase
    {
        private IWebElement userNameField => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordField => driver.FindElement(By.Id("password"));
        private IWebElement loginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement Burger => driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // This method is used to log in to the system
        public LoginPage LogInSystem(string username, string password)
        {
            userNameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();

            return this;
        }

        public LoginPage LogInSystem()
        {
            loginButton.Click();

            return this;
        }

        public LoginPage AssertSuccessfulLogIn()
        {
            string actualUrl = driver.Url;
            string expectedUrl = "https://www.saucedemo.com/inventory.html";
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));

            return this;
        }

        public LoginPage AssertSuccessfulLogOut()
        {
            string actualUrl = driver.Url;
            string expectedUrl = "https://www.saucedemo.com/";
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));

            return this;
        }

        public LoginPage ClickOnBurger()
        {
            Burger.Click();

            return this;
        }

        public LoginPage LogOut()
        {
            click(By.XPath("//a[@id='logout_sidebar_link']"));

            return this;
        }
    }
}
