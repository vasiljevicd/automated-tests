using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using ui.Config;

namespace ui.Core.Pages
{
	public class CartPage :BasePage
	{
        private IWebElement cartTitle => driver.FindElement(By.XPath("//span[text()='Your Cart']"));
        private IWebElement checkoutButton => driver.FindElement(By.Id("checkout"));

        public CartPage()
		{
			url = Configuration.baseUrl + "cart.html";

        }

        public string GetPriceForItem(string item)
        {
            return baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'" + item + "')]/../../..//div[@class='inventory_item_price']").Text;
        }

        public string GetQuantityForItem(string item)
        {
            return baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'" + item + "')]/../../..//div[@class='cart_quantity']").Text;
        }

        public void VerifyPriceForItemOnCartPage(string itemPrice, string item)
		{
            Assert.AreEqual(itemPrice, GetPriceForItem(item));
        }

        public void VerifyQuantutyOfItemOnCartPage(string item, string itemQuantity)
        {
            Assert.AreEqual(itemQuantity, GetQuantityForItem(item));
        }

        public void RemoveItemFromTheCart(string item)
        {
            string[] words = item.Split(" ");
            string id = ("remove-" + string.Join("-", words)).ToLower();
            IWebElement AddToCartElement = baseWebElement.FindElementById(id);
            baseWebElement.ClickOnElement(AddToCartElement);

        }

        public void VeryfyIsCartEmpty()
        {
            bool isEmpty = false;
            try
            {
                baseWebElement.FindElementByClassName("cart_item");
         
            }catch(NoSuchElementException e)
            {
                isEmpty = true;
            }

            Assert.IsTrue(isEmpty);
        }

        public void VerifyCartTitleIsDisplayed()
        {
            Assert.IsTrue(baseWebElement.IsElementDisplayed(cartTitle));

        }

        public void ClickOnTheCheckoutButton()
        {
            baseWebElement.ClickOnElement(checkoutButton);
        }

    }
}

