using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace AutomationTasks.Pages.Module_5_Page
{
    class Module_5_Page : PageBase
    {
        private IWebElement checkbox1 => driver.FindElement(By.XPath("//form[@id='checkboxes']/input[@type='checkbox'][1]"));
        private IWebElement checkbox2 => driver.FindElement(By.XPath("//form[@id='checkboxes']/input[@type='checkbox'][2]"));

        public Module_5_Page(IWebDriver driver) : base(driver)
        {
        }

        public Module_5_Page ClickOnLinkPage(string linkHref)
        {
            var link = driver.FindElement(By.XPath("//a[@href='" + linkHref + "']"));
            link.Click();

            return this;
        }

        public Module_5_Page SwitchToOtherWindow()
        {
            var windows = driver.WindowHandles;
            driver.SwitchTo().Window(windows[1]);

            return this;
        }

        public Module_5_Page AssertPageTitle(string expectedTitle)
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));

            return this;
        }

        public Module_5_Page CloseOtherWindow()
        {
            var windows = driver.WindowHandles;
            driver.SwitchTo().Window(windows[1]);
            driver.Close();
            driver.SwitchTo().Window(windows[0]);

            return this;
        }

        public Module_5_Page AssertWindowClosed()
        {
            var windows = driver.WindowHandles;
            Assert.That(windows.Count, Is.EqualTo(1));

            return this;
        }

        public Module_5_Page InputCredentials()
        {
            var getUsername = driver.FindElement(By.XPath("(//em)[1]"));
            var getPassword = driver.FindElement(By.XPath("(//em)[2]"));
            var inputUsername = driver.FindElement(By.XPath("//input[@id='username']"));
            inputUsername.SendKeys(getUsername.Text);
            var inputPassword = driver.FindElement(By.XPath("//input[@id='password']"));
            inputPassword.SendKeys(getPassword.Text);

            return this;
        }

        public Module_5_Page ClickOnLoginButton()
        {
            var loginButton = driver.FindElement(By.XPath("//i[@class='fa fa-2x fa-sign-in']"));
            loginButton.Click();

            return this;
        }

        public Module_5_Page AssertSuccessfulLogIn(string alertText)
        {
            var successMessage = GetText(By.XPath("//div[@id='flash']"));
            Assert.That(successMessage, Does.Contain(alertText));

            return this;
        }

        public Module_5_Page AssertLogInPage(string logInPageContent)
        {
            var loginPage = GetText(By.XPath("//h2"));
            Assert.That(loginPage, Is.EqualTo(logInPageContent));

            return this;
        }

        public Module_5_Page ClickOnStartButton()
        {
            var startButton = driver.FindElement(By.XPath("//div[@id='start']//button"));
            startButton.Click();

            return this;
        }

        public Module_5_Page WaitForElementToBeDisplayed(string finishedText)
        {
            var finishedElement = GetText(By.XPath("//div[@id='finish']"));
            Assert.That(finishedElement, Is.EqualTo(finishedText));

            return this;
        }

        public Module_5_Page ScrollToElement(string elementXPath, string TrueFalse)
        {
            var element = driver.FindElement(By.XPath(elementXPath));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(" + TrueFalse + ");", element);

            return this;
        }

        public Module_5_Page GetLastElement()
        {
            IWebElement parentElement = driver.FindElement(By.Id("large-table"));
            var latestValue = parentElement
                .FindElements(By.XPath(".//tr"))
                .LastOrDefault()?
                .FindElements(By.TagName("td"))
                .LastOrDefault()?
                .Text;
            Assert.That(latestValue, Is.EqualTo("50.50"));

            return this;
        }

        public Module_5_Page SelectAndUnselectCheckBoxes()
        {
            if (!checkbox1.Selected)
            {
                checkbox1.Click();
            }
            if (checkbox2.Selected)
            {
                checkbox2.Click();
            }
            Assert.That(checkbox1.Selected, Is.True, "Checkbox 1 should be selected.");
            Assert.That(checkbox2.Selected, Is.False, "Checkbox 2 should be unselected.");

            return this;
        }

    }
}
