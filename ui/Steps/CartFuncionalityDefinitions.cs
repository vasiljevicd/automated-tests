using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using ui.Core;
using ui.Core.Pages;

namespace ui.Steps
{
    [Binding]
    public sealed class CartFuncionalityStepsDefinitions
    {
  
        ProductsPage productsPage = new ProductsPage();
        CartPage cartPage = new CartPage();
        ItemPage itemPage = new ItemPage();
        public Dictionary<string, string> itemsAndPrices = new Dictionary<string, string>();

        [Given("I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            productsPage.VerifyProductsTitleIsDisplayed();
        }

        [When("I add the item \"(.*)\" from the products page")]
        public void WhenIAddTheItemFromTheHomePage(string item)
        {
            productsPage.AddItemToTheCart(item);
            
        }

        [Then("shopping cart badge should be (.*)")]
        public void ThenShoppingCartBadgeShouldBe(int numberOfItems)
        {
            productsPage.VerifyNumberInCartBadge(numberOfItems);
        }

        [Then("shopping cart badge should not be visible")]
        public void ThenShoppingCartBadgeShoulNotBeVisible()
        {
            productsPage.VeryfyIsCartBageNotVisible();
        }


        [When("I click on the item \"(.*)\"")]
        public void WhenIClickOnTheItem(string item)
        {
            productsPage.ClickOnTheItem(item);
            
        }

        [When("I add the item \"(.*)\" from the item page")]
        public void WhenIAddTheItemFromTheItemPage(string item)
        {
            productsPage.ClickOnTheItem(item);
            itemPage.AddItemToTheCart(item);
        }

        [When("I add the item \"(.*)\" from the item page and go back to products")]
        public void WhenIAddTheItemFromTheItemPageAndGoBackToProducts(string item)
        {
            productsPage.ClickOnTheItem(item);
            itemPage.AddItemToTheCart(item);
            itemPage.ClickOnTheBackToProductsButton();
        }

        [When("I get price for the item \"(.*)\" from the products page")]
        public void WhenIGetTheItemPriceOnTheProductsPage(string item)
        {
            itemsAndPrices.Add(item, productsPage.GetPriceForItem(item));
        }

        [When("I click on the cart")]
        public void WhenIClikOnTheCart()
        {
            productsPage.ClickOnTheCart();
        }

        [When("I remove the item \"(.*)\" from the products page")]
        public void WhenIRemoveTheItemFromTheHomePage(string item)
        {
            productsPage.RemoveItemFromTheCart(item);

        }

        [Then("the price for the item \"(.*)\" in the cart should be the same as on products page")]
        public void ThenThePriceInTheCartShouldBeTheSameAsOnProductsPage(string item)
        {
            cartPage.VerifyPriceForItemOnCartPage(itemsAndPrices[item], item);
        }

        [Then("the quantity of the item \"(.*)\" in the cart should be (.*)")]
        public void ThenTheQuantityInTheCartShouldBe(string item, string quantity)
        {
            cartPage.VerifyQuantutyOfItemOnCartPage(item, quantity);
        }

        [When("I remove the item \"(.*)\" from the cart page")]
        public void WhenIRemoveTheItemFromTheCartPage(string item)
        {
            cartPage.RemoveItemFromTheCart(item);

        }

        [Then("shopping cart should be empty")]
        public void ThenShoppingCartBadgeShoulBeEmpty()
        {
            cartPage.VeryfyIsCartEmpty();
        }

        [Given("I am on the cart page")]
        public void GivenIAmOnTheCartPage()
        {
            cartPage.VerifyCartTitleIsDisplayed();
        }

        [When("I click on back to products button from the item page")]
        public void WhenIClikOnTheBackToProductsButton()
        {
            itemPage.ClickOnTheBackToProductsButton();
        }

    }
}
