using NUnit.Framework;

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
            Module_2_Test.loginPage.LogInSystem();
            Module_2_Test.module_2_Page.AssertUnsuccessfulLogInError(noCredErrorMessage);
        }

        [Test, Order(2)]
        public void badCredlogInTest()
        {
            Module_2_Test.loginPage.LogInSystem("invalid_user", "invalid_password");
            Module_2_Test.loginPage.LogInSystem();
            Module_2_Test.module_2_Page.AssertUnsuccessfulLogInError(badCredErrorMessage);
        }
    }
}
