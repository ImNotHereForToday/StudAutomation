using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Pages
{
    class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { }

        private IWebElement userNameField => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordField => driver.FindElement(By.Id("password"));
        private IWebElement loginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement headerLogo => driver.FindElement(By.XPath("//div[@class='app_logo']"));


        public LoginPage NavigateToDefaultPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            return this;
        }
        public LoginPage LogInSystem(string username, string password)
        {
            userNameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();
            return this;
        }
        public LoginPage AssertSuccessfulLogIn()
        {
            Assert.That(headerLogo.Text, Is.EqualTo("Swag Labs"));
            return this;
        }


    }
}
