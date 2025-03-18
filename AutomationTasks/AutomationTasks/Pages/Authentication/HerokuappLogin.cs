using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Pages.Authentication
{
    class HerokuappLogin : PageBase
    {
        private readonly By usernameLocator = By.XPath("//input[@id='username']");
        private readonly By passwordLocator = By.XPath("//input[@id='password']");
        private readonly By loginButtonLocator = By.XPath("//i[@class='fa fa-2x fa-sign-in']");
        private readonly By successMessageLocator = By.XPath("//div[@id='flash']");
        private readonly By loginPageLocator = By.XPath("//h2");
        private IWebElement FindElement(By locator) => driver.FindElement(locator);

        public HerokuappLogin(IWebDriver driver) : base(driver)
        {
        }

        // This method is used to log in to the system
        public HerokuappLogin InputCredentials()
        {
            var getUsername = FindElement(By.XPath("(//em)[1]")).Text;
            var getPassword = FindElement(By.XPath("(//em)[2]")).Text;
            FindElement(usernameLocator).SendKeys(getUsername);
            FindElement(passwordLocator).SendKeys(getPassword);

            return this;
        }

        public HerokuappLogin InputInvalidCredentials(string username, string password)
        {
            FindElement(usernameLocator).SendKeys(username);
            FindElement(passwordLocator).SendKeys(password);

            return this;
        }

        public HerokuappLogin ClickOnLoginButton()
        {
            FindElement(loginButtonLocator).Click();

            return this;
        }

        public HerokuappLogin AssertLoginAlertMessage(string alertText)
        {
            var successMessage = GetText(successMessageLocator);
            Assert.That(successMessage, Does.Contain(alertText));

            return this;
        }

        public HerokuappLogin AssertLogInPage(string logInPageContent)
        {
            var loginPage = GetText(loginPageLocator);
            Assert.That(loginPage, Is.EqualTo(logInPageContent));

            return this;
        }
    }
}
