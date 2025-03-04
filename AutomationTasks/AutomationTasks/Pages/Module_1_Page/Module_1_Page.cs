using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTasks.Pages.Module_1_Page
{
    class Module_1_Page : PageBase
    {
        private IWebElement itemDescription => driver.FindElement(By.XPath("//div[@data-test='inventory-item-desc']"));

        public Module_1_Page(IWebDriver driver) : base(driver)
        {
        }

        public Module_1_Page ClickOnProduct(string productName)
        {
            driver.FindElement(By.XPath($"//div[text()='{productName}']")).Click();

            return this;
        }

        public Module_1_Page AssertProdcutDescription(string descriptionText)
        {
            Assert.That(itemDescription.Text, Is.EqualTo(descriptionText));

            return this;
        }
    }
}
