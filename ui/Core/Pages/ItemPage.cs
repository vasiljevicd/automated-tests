using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using ui.Config;

namespace ui.Core.Pages
{
	public class ItemPage : BasePage
	{

        private IWebElement cartBadge => driver.FindElement(By.ClassName("shopping_cart_badge"));
        private IWebElement cartLink => driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement backToProductsButton => driver.FindElement(By.Id("back-to-products"));

        public ItemPage()
		{
			url = Configuration.baseUrl + "/inventory.html";

        }


        public void AddItemToTheCart(string item)
        {
            string[] words = item.Split(" ");
            string id = ("add-to-cart-" + string.Join("-", words)).ToLower();
            IWebElement AddToCartElement = baseWebElement.FindElementById(id);
            baseWebElement.ClickOnElement(AddToCartElement);

        }

        public void RemoveItemToTheCart(string item)
        {
            string[] words = item.Split(" ");
            string id = ("remove-" + string.Join("-", words)).ToLower();
            IWebElement AddToCartElement = baseWebElement.FindElementById(id);
            baseWebElement.ClickOnElement(AddToCartElement);

        }

        public void VerifyNumberInCartBadge(int numberOfItems)
        {
            Assert.AreEqual(numberOfItems, int.Parse(baseWebElement.GetElementText(cartBadge)));
        }

        public void ClickOnTheBackToProductsButton()
        {
            baseWebElement.ClickOnElement(backToProductsButton);
        }

        public void ClickOnTheItem(string item)
        {
            IWebElement ItemElement = baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'"+item+"')]");
            baseWebElement.ClickOnElement(ItemElement);
        }

        public void ClickOnTheCart()
        {
            baseWebElement.ClickOnElement(cartLink);
        }

        public string GetPriceForItem(string item)
        {
            return baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'"+item+"')]/../../..//div[@class='inventory_item_price']").Text;
        }

        public void VeryfyIsCartBageNotVisible()
        {
            Assert.IsFalse(baseWebElement.IsElementDisplayed(cartBadge));
        }
    }
}

