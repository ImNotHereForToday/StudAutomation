using NUnit.Framework;

namespace AutomationTasks.Tests.Module_7_Page
{
    
    // These tests were made to just complete module_7 POM req. 
    // They are the same tests used in login page , with exception that
    // there is a logout check.
    class Module_7_Test : TestBase
    {
        public Module_7_Test() : base("http://the-internet.herokuapp.com/")
        {
        }

        [Test, Order(1)]
        [Property("quit", "true")]
        public void ValidLogin()
        {
            module_5_Page.ClickOnLinkPage("/login");
            herokuappLogin.InputCredentials();
            herokuappLogin.ClickOnLoginButton();
            herokuappLogin.AssertLoginAlertMessage("You logged into a secure area!");
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        public void InvalidLogin()
        {
            module_5_Page.ClickOnLinkPage("/login");
            herokuappLogin.InputInvalidCredentials("invalidUsername", "invalidPassword");
            herokuappLogin.ClickOnLoginButton();
            herokuappLogin.AssertLoginAlertMessage("Your username is invalid!");
        }

        [Test, Order(3)]
        [Property("quit", "true")]
        public void NoCredLogin()
        {
            module_5_Page.ClickOnLinkPage("/login");
            herokuappLogin.ClickOnLoginButton();
            herokuappLogin.AssertLoginAlertMessage("Your username is invalid!");
        }

        [Test, Order(4)]
        [Property("quit", "true")]
        public void Logout()
        {
            ValidLogin();
            module_5_Page.ClickOnLinkPage("/logout");
            herokuappLogin.AssertLoginAlertMessage("You logged out of the secure area!");
        }
    }
}
