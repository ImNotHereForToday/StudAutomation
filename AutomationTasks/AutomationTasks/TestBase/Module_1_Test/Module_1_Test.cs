using AutomationTasks.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Tests.Module_1_Test
{

    [TestFixture("chrome")]
    class Module_1_Test : TestBase
    {
        public Module_1_Test(string browser) : base(browser) { }

        string itemDescription = "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.";


        [Test]
        public void loginTest()
        {
            loginPage.NavigateToDefaultPage()
                     .LogInSystem("standard_user", "secret_sauce")
                     .AssertSuccessfulLogIn();

            module_1_page
                         .ClickOnProduct("Sauce Labs Backpack")
                         .AssertProdcutDescription(itemDescription);


        }
    }
}
