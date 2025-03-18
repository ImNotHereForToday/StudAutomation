using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTasks.Pages
{
    class SauceDemoLogin : PageBase
    {
        private IWebElement userNameField => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordField => driver.FindElement(By.Id("password"));
        private IWebElement loginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement BurgerButton => driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));

        public SauceDemoLogin(IWebDriver driver) : base(driver)
        {
        }

        // This method is used to log in to the system
        public SauceDemoLogin LogInSystem(string username, string password)
        {
            userNameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();

            return this;
        }

        public SauceDemoLogin LogInSystem()
        {
            loginButton.Click();

            return this;
        }

        public SauceDemoLogin AssertSuccessfulLogIn()
        {
            string actualUrl = driver.Url;
            string expectedUrl = "https://www.saucedemo.com/inventory.html";
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));

            return this;
        }

        public SauceDemoLogin AssertSuccessfulLogOut()
        {
            string actualUrl = driver.Url;
            string expectedUrl = "https://www.saucedemo.com/";
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));

            return this;
        }

        public SauceDemoLogin ClickOnBurger()
        {
            BurgerButton.Click();

            return this;
        }

        public SauceDemoLogin LogOut()
        {
            Click(By.XPath("//a[@id='logout_sidebar_link']"));

            return this;
        }
    }
}
