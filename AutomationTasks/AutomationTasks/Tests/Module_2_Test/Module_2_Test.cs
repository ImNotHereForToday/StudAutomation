using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Tests.Module_2_Test
{
    [TestFixture("chrome")]
    class Module_2_Test : TestBase
    {
        public Module_2_Test(string browser) : base(browser) { }

        string noCredErrorMessage = "Epic sadface: Username is required";
        string badCredErrorMessage = "Epic sadface: Username and password do not match any user in this service";

        [Test , Order(1)]
        [Property("quit", "true")]
        public void NoCredlogInTest()
        {
            loginPage
                     .LogInSystem();

            module_2_Page
                         .AssertUnsuccessfulLogInError(noCredErrorMessage);


        }
        [Test, Order(2)]
        public void badCredlogInTest()
        {
            loginPage.LogInSystem("invalid_user", "invalid_password")
                     .LogInSystem();

            module_2_Page
                         .AssertUnsuccessfulLogInError(badCredErrorMessage);


        }
    }
}
