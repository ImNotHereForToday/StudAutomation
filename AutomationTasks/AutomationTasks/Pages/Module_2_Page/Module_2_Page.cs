using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Pages.Module_2_Page
{
    class Module_2_Page : PageBase
    {
        public Module_2_Page(IWebDriver driver) : base(driver) { }

        public IWebElement LogInErrorContainer => driver.FindElement(By.XPath("//div[@class='error-message-container error']"));


        public Module_2_Page AssertUnsuccessfulLogInError(string errorMsg)
        {
            Assert.That(LogInErrorContainer.Text, Is.EqualTo(errorMsg));
            return this;
        }

    }
}
