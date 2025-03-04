using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTasks.Pages.Module_3_Page
{
    class Module_3_Page : PageBase
    {
        private IWebElement ProductCartBadge => driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));
        private IWebElement ProductCart => driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        private IWebElement RemoveProductButton => driver.FindElement(By.XPath("//button[@id='remove-sauce-labs-backpack']"));

        public Module_3_Page(IWebDriver driver) : base(driver)
        {
        }

        public void SelectFilter(string filterName)
        {
            var filterMenu = driver.FindElement(By.XPath("//select[@class='product_sort_container']"));
            filterMenu.Click();
            try
            {
                var filterOptions = driver.FindElement(By.XPath("//select[@class='product_sort_container']/option[text()='" + filterName + "']"));
                filterOptions.Click();
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Filter option not found");
            }
        }

        public List<string> GetProductPrices()
        {
            var productPrices = driver.FindElements(By.XPath("//div[@class='inventory_item_price']"));
            List<string> prices = new List<string>();
            foreach (var price in productPrices)
            {
                prices.Add(price.Text);
            }

            return prices;
        }

        public Module_3_Page AssertFilterApplied()
        {
            var prices = GetProductPrices().Select(price => decimal.Parse(price.Trim('$'))).ToList();
            Assert.That(prices, Is.Ordered.Ascending);

            return this;
        }

        public Module_3_Page AddProductToCart()
        {
            driver.FindElement(By.XPath("//button[@id='add-to-cart']")).Click();

            return this;
        }

        public Module_3_Page AssertThatProductWasAddedToCart(string itemCount)
        {
            Assert.That(ProductCartBadge.Displayed, Is.True);
            Assert.That(ProductCartBadge.Text, Is.EqualTo(itemCount));

            return this;
        }

        public Module_3_Page OpenCart()
        {
            ProductCart.Click();
            return this;
        }

        public Module_3_Page RemoveProduct()
        {
            RemoveProductButton.Click();

            return this;
        }

        public Module_3_Page AssertThatProductWasRemovedFromCart()
        {
            try
            {
                Assert.That(ProductCartBadge.Displayed, Is.False);
            }
            catch (NoSuchElementException)
            {
            }
            finally
            {
                var cartItems = driver.FindElements(By.XPath("//div[@class='cart_item']"));
                Assert.That(cartItems.Count, Is.EqualTo(0));
            }

            return this;
        }
    }
}
