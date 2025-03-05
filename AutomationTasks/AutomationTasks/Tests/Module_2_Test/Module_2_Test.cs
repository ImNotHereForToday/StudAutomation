using AutomationTasks.Pages.Module_3_Page;
using AutomationTasks.Pages;
using NUnit.Framework;
using AutomationTasks.Pages.Module_2_Page;

namespace AutomationTasks.Tests.Module_2_Test
{
    [TestFixture("chrome")]
    class Module_2_Test : TestBase
    {
        public Module_2_Test(string browser) : base(browser)    
        {   
        }

        string noCredErrorMessage = "Epic sadface: Username is required";
        string badCredErrorMessage = "Epic sadface: Username and password do not match any user in this service";

        [Test, Order(1)]
        public void NoCredlogInTest()
        {
            var loginPage = new LoginPage(Driver);
            var module_2_Page = new Module_2_Page(Driver);

            loginPage.LogInSystem();
            module_2_Page.AssertUnsuccessfulLogInError(noCredErrorMessage);
        }

        [Test, Order(2)]
        public void BadCredlogInTest()
        {
            var loginPage = new LoginPage(Driver);
            var module_2_Page = new Module_2_Page(Driver);

            loginPage.LogInSystem("invalid_user", "invalid_password");
            loginPage.LogInSystem();
            module_2_Page.AssertUnsuccessfulLogInError(badCredErrorMessage);
        }
    }
}
