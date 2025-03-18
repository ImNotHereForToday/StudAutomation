using AutomationTasks.Pages;
using AutomationTasks.Pages.Module_1_Page;
using AutomationTasks.Pages.Module_3_Page;
using NUnit.Framework;
using static AutomationTasks.Pages.SauceDemoLogin;

namespace AutomationTasks.Tests.Module_3_Test
{
    [Parallelizable(ParallelScope.All)]
    class Module_3_Test : TestBase
    {
        public Module_3_Test() : base("https://www.saucedemo.com/")
        {
        }

        [Test, Order(1)]
        [Property("quit", "true")]
        public void AssertProductSorting()
        {
            var loginPage = new SauceDemoLogin(Driver);
            var module_3_Page = new Module_3_Page(Driver);
            loginPage.LogInSystem("standard_user", "secret_sauce");
            loginPage.AssertSuccessfulLogIn();
            module_3_Page.SelectFilter("Price (low to high)");
            module_3_Page.AssertFilterApplied();
        }

        [Test, Order(2)]
        [Property("quit", "true")]
        public void AddProductToCart()
        {
            var loginPage = new SauceDemoLogin(Driver);
            var module_1_Page = new Module_1_Page(Driver);
            var module_3_Page = new Module_3_Page(Driver);
            loginPage.LogInSystem("standard_user", "secret_sauce");
            loginPage.AssertSuccessfulLogIn();
            module_1_Page.ClickOnProduct("Sauce Labs Backpack");
            module_3_Page.AddProductToCart();
            module_3_Page.AssertThatProductWasAddedToCart("1");
        }

        [Test, Order(3)]
        [Property("quit", "true")]
        public void RemoveProductFromCart()
        {
            var loginPage = new SauceDemoLogin(Driver);
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
        }
    }
}
