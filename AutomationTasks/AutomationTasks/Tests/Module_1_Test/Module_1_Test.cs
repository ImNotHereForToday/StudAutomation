using NUnit.Framework;

namespace AutomationTasks.Tests.Module_1_Test
{

    [TestFixture("chrome")]
    class Module_1_Test : TestBase
    {
        public Module_1_Test(string browser) : base(browser)    
        {   
        }

        const string itemDescription = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.";

        [Test]
        public void logInTest()
        {
            Module_1_Test.loginPage.LogInSystem("standard_user", "secret_sauce");
            Module_1_Test.loginPage.AssertSuccessfulLogIn();
            Module_1_Test.module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            Module_1_Test.module_1_Page.AssertProdcutDescription(itemDescription);
        }
    }
}
