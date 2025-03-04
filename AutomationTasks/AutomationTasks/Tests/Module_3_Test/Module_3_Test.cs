using AutomationTasks.Pages.Module_1_Page;
using NUnit.Framework;

namespace AutomationTasks.Tests.Module_3_Test
{
    [TestFixture("chrome")]
    class Module_3_Test : TestBase
    {
        public Module_3_Test(string browser) : base(browser)
        {
        }

        [Test, Order(1)]
        [Property("quit", "true")]
        public void AssertProductSorting()
        {
            Module_3_Test.loginPage.LogInSystem("standard_user", "secret_sauce");
            Module_3_Test.loginPage.AssertSuccessfulLogIn();
            Module_3_Test.module_3_Page.SelectFilter("Price (low to high)");
            Module_3_Test.module_3_Page.AssertFilterApplied();
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        public void AddProductToCart()
        {
            Module_3_Test.loginPage.LogInSystem("standard_user", "secret_sauce");
            Module_3_Test.loginPage.AssertSuccessfulLogIn();
            Module_3_Test.module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            Module_3_Test.module_3_Page.AddProductToCart();
            Module_3_Test.module_3_Page.AssertThatProductWasAddedToCart("1");
        }

        [Test, Order(3)]
        [Property("quit", "true")]
        public void RemoveProductFromCart()
        {
            Module_3_Test.loginPage.LogInSystem("standard_user", "secret_sauce");
            Module_3_Test.loginPage.AssertSuccessfulLogIn();
            Module_3_Test.module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            Module_3_Test.module_3_Page.AddProductToCart();
            Module_3_Test.module_3_Page.AssertThatProductWasAddedToCart("1");
            Module_3_Test.module_3_Page.OpenCart();
            Module_3_Test.module_3_Page.RemoveProduct();
            Module_3_Test.module_3_Page.AssertThatProductWasRemovedFromCart();
            Module_3_Test.loginPage.ClickOnBurger();
            Module_3_Test.loginPage.LogOut();
            Module_3_Test.loginPage.AssertSuccessfulLogOut();
        }
    }
}
