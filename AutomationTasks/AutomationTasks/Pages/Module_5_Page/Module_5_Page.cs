using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace AutomationTasks.Pages.Module_5_Page
{
    class Module_5_Page : PageBase
    {
        private readonly By checkbox1Locator = By.XPath("//form[@id='checkboxes']/input[@type='checkbox'][1]");
        private readonly By checkbox2Locator = By.XPath("//form[@id='checkboxes']/input[@type='checkbox'][2]");
        private readonly By startButtonLocator = By.XPath("//div[@id='start']//button");
        private readonly By finishLocator = By.XPath("//div[@id='finish']");
        private readonly By tableLocator = By.Id("large-table");

        public Module_5_Page(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FindElement(By locator) => driver.FindElement(locator);

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

        public Module_5_Page ClickOnStartButton()
        {
            FindElement(startButtonLocator).Click();
            
            return this;
        }

        public Module_5_Page WaitForElementToBeDisplayed(string finishedText)
        {
            var finishedElement = GetText(finishLocator);
            Assert.That(finishedElement, Is.EqualTo(finishedText));
            
            return this;
        }

        public Module_5_Page ScrollToElement(string elementXPath, string TrueFalse)
        {
            var element = FindElement(By.XPath(elementXPath));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(" + TrueFalse + ");", element);
            
            return this;
        }

        public Module_5_Page GetLastElement()
        {
            IWebElement parentElement = FindElement(tableLocator);
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
            var checkbox1 = FindElement(checkbox1Locator);
            var checkbox2 = FindElement(checkbox2Locator);

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
