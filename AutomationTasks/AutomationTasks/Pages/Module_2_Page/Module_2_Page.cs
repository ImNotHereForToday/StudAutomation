using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTasks.Pages.Module_2_Page
{
    class Module_2_Page : PageBase
    {
        private IWebElement LogInErrorContainer => driver.FindElement(By.XPath("//div[@class='error-message-container error']"));

        public Module_2_Page(IWebDriver driver) : base(driver)
        {
        }

        public Module_2_Page AssertUnsuccessfulLogInError(string errorMsg)
        {
            Assert.That(LogInErrorContainer.Text, Is.EqualTo(errorMsg));

            return this;
        }
    }
}
