using NUnit.Framework;

namespace AutomationTasks.Tests.Module_2_Test
{
    class Module_2_Test : TestBase
    {
        public Module_2_Test() : base("https://www.saucedemo.com/")
        {   
        }

        string noCredErrorMessage = "Epic sadface: Username is required";
        string badCredErrorMessage = "Epic sadface: Username and password do not match any user in this service";

        [Test, Order(1)]
        [Property("quit", "true")]
        public void NoCredlogInTest()
        {
            sauceDemoLogin.LogInSystem();
            module_2_Page.AssertUnsuccessfulLogInError(noCredErrorMessage);
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        public void BadCredlogInTest()
        {
            sauceDemoLogin.LogInSystem("invalid_user", "invalid_password");
            sauceDemoLogin.LogInSystem();
            module_2_Page.AssertUnsuccessfulLogInError(badCredErrorMessage);
        }
    }
}
