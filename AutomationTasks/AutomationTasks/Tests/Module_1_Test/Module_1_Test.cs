using NUnit.Framework;
using static AutomationTasks.Factory.BrowserFactory;

namespace AutomationTasks.Tests.Module_1_Test
{
    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    class Module_1_Test : TestBase
    {
        public Module_1_Test(Browser browser) : base(browser, "https://www.saucedemo.com/") 
        {   
        }

        const string itemDescription = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.";

        [Test]
        [Property("quit", "true")]
        public void LogInTest()
        {
            sauceDemoLogin.LogInSystem("standard_user", "secret_sauce");
            sauceDemoLogin.AssertSuccessfulLogIn();
            module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            module_1_Page.AssertProdcutDescription(itemDescription);
        }
    }
}
