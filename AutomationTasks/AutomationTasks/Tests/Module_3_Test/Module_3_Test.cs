using AutomationTasks.Pages.Module_1_Page;
using AutomationTasks.Pages;
using NUnit.Framework;
using AutomationTasks.Pages.Module_3_Page;

namespace AutomationTasks.Tests.Module_3_Test
{
    [TestFixture("chrome")]
    [Parallelizable(ParallelScope.All)]
    class Module_3_Test : TestBase
    {
        public Module_3_Test(string browser) : base(browser , "https://www.saucedemo.com/")
        {
        }

        [Test, Order(1)]
        [Property("quit", "true")]
        [Parallelizable(ParallelScope.Self)]
        public void AssertProductSorting()
        {
            var loginPage = new LoginPage(Driver);
            var module_3_Page = new Module_3_Page(Driver);

            loginPage.LogInSystem("standard_user", "secret_sauce");
            loginPage.AssertSuccessfulLogIn();
            module_3_Page.SelectFilter("Price (low to high)");
            module_3_Page.AssertFilterApplied();
            Driver.Quit();
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        [Parallelizable(ParallelScope.Self)]
        public void AddProductToCart()
        {
            var loginPage = new LoginPage(Driver);
            var module_1_Page = new Module_1_Page(Driver);
            var module_3_Page = new Module_3_Page(Driver);

            loginPage.LogInSystem("standard_user", "secret_sauce");
            loginPage.AssertSuccessfulLogIn();
            module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            module_3_Page.AddProductToCart();
            module_3_Page.AssertThatProductWasAddedToCart("1");
            Driver.Quit();
        }

        [Test, Order(3)]
        [Property("quit", "true")]
        [Parallelizable(ParallelScope.Self)]
        public void RemoveProductFromCart()
        {
            var loginPage = new LoginPage(Driver);
            var module_1_Page = new Module_1_Page(Driver);
            var module_3_Page = new Module_3_Page(Driver);

            loginPage.LogInSystem("standard_user", "secret_sauce");
            loginPage.AssertSuccessfulLogIn();
            module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            module_3_Page.AddProductToCart();
            module_3_Page.AssertThatProductWasAddedToCart("1");
            module_3_Page.OpenCart();
            module_3_Page.RemoveProduct();
            module_3_Page.AssertThatProductWasRemovedFromCart();
            loginPage.ClickOnBurger();
            loginPage.LogOut();
            loginPage.AssertSuccessfulLogOut();
            Driver.Quit();
        }
    }
}
