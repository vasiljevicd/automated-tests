using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using ui.Config;

namespace ui.Core.Pages
{
	public class ProductsPage : BasePage
	{

        private IWebElement cartBadge => driver.FindElement(By.ClassName("shopping_cart_badge"));
        private IWebElement cartLink => driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement productsTitle => driver.FindElement(By.XPath("//span[text()='Products']"));
        private IWebElement menuButton => driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement logout => driver.FindElement(By.Id("logout_sidebar_link"));
        

        public ProductsPage()
		{
			url = Configuration.baseUrl + "inventory.html";

        }

        public void OpenPage()
        {
            baseWebElement.NavigateToURL(url);
        }

        public void VerifyProductsTitleIsDisplayed()
        {
            Assert.IsTrue(baseWebElement.IsElementDisplayed(productsTitle));
        }


        public void AddItemToTheCart(string item)
        {
            string[] words = item.Split(" ");
            string id = ("add-to-cart-" + string.Join("-", words)).ToLower();
            IWebElement AddToCartElement = baseWebElement.FindElementById(id);
            baseWebElement.ClickOnElement(AddToCartElement);

        }

        public void RemoveItemFromTheCart(string item)
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

        public void ClickOnTheItem(string item)
        {
            IWebElement ItemElement = baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'"+item+"')]");
            baseWebElement.ClickOnElement(ItemElement);
        }

        public void ClickOnTheCart()
        {
            baseWebElement.ClickOnElement(cartLink);
        }

        public void ClickOnTheMenu()
        {
            baseWebElement.ClickOnElement(menuButton);
        }

        public void ClickOnTheLogout()
        {
            baseWebElement.ClickOnElement(logout);
        }

        public string GetPriceForItem(string item)
        {
            return baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'"+item+"')]/../../..//div[@class='inventory_item_price']").Text;
        }

        public void VeryfyIsCartBageNotVisible()
        {
            bool isVisible = true;
            try
            {
                IWebElement badge = baseWebElement.FindElementByClassName("shopping_cart_badge");
            }
            catch(NoSuchElementException e)
            {
                isVisible = false;
            }

            Assert.IsFalse(isVisible);
        }
    }
}

