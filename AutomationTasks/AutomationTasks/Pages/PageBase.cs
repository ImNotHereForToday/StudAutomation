using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationTasks.Pages
{
    class PageBase
    {
        protected IWebDriver driver;
        private WebDriverWait wait;

        public PageBase(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void click(By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            driver.FindElement(locator).Click();
        }

        public void type(By locator, string text)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            driver.FindElement(locator).SendKeys(text);
        }

        public string getText(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            IWebElement element = driver.FindElement(locator);
            string text = element.Text;

            return text;
        }
    }
}
