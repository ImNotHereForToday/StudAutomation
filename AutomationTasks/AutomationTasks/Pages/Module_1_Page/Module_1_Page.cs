using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Pages.Module_1_Page
{
    class Module_1_Page : PageBase
    {
        public Module_1_Page(IWebDriver driver) : base(driver) { }


        public IWebElement itemDescription => driver.FindElement(By.XPath("//div[@data-test='inventory-item-desc']"));


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
