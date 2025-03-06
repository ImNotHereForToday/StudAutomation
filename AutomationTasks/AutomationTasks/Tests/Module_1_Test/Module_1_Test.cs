using AutomationTasks.Pages.Module_3_Page;
using AutomationTasks.Pages;
using NUnit.Framework;
using AutomationTasks.Pages.Module_1_Page;

namespace AutomationTasks.Tests.Module_1_Test
{

    [TestFixture("chrome")]
    class Module_1_Test : TestBase
    {
        public Module_1_Test(string browser) : base(browser, "https://www.saucedemo.com/")    
        {   
        }

        const string itemDescription = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.";

        [Test]
        public void LogInTest()
        {
            var loginPage = new LoginPage(Driver);
            var module_1_Page = new Module_1_Page(Driver);

            loginPage.LogInSystem("standard_user", "secret_sauce");
            loginPage.AssertSuccessfulLogIn();
            module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            module_1_Page.AssertProdcutDescription(itemDescription);
            Driver.Quit();
        }
    }
}
