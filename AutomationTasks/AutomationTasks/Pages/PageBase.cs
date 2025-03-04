using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected void click(By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            driver.FindElement(locator).Click();
        }
        protected void type(By locator, string text)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            driver.FindElement(locator).SendKeys(text);
        }
        protected string getText(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElement(locator).Text;
        }

    }
}
