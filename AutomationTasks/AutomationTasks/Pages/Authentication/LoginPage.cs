using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTasks.Pages
{
    class LoginPage
    {
        public class SauceDemoLogin : PageBase
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
        public class HerokuappLogin : PageBase
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
}
