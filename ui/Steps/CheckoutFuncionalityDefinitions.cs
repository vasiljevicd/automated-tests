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
    public sealed class CheckoutFuncionalityStepsDefinitions
    {

        MyInformationPage myInformationPage = new MyInformationPage();
        OverviewPage overviewPage = new OverviewPage();
        CompletePage completePage = new CompletePage();
        CartPage cartPage = new CartPage();
        public Dictionary<string, string> itemsAndPrices = new Dictionary<string, string>();


        [When("I click on the checkout button")]
        public void WhenIClickOnTheCheckoutButton()
        {
            cartPage.ClickOnTheCheckoutButton();

        }

        [Then("I should be redirected to the checkout your information page")]
        public void ThenIShouldBeRedirectedToTheCheckoutYourInformationPage()
        {
            myInformationPage.VerifyYourInformationTitleIsDisplayed();
        }

        [When("I enter first name \"(.*)\" , last name \"(.*)\" and postal code \"(.*)\"")]
        public void WhenIFirstNameLastNameAndPostalCode(string firstName, string lastName, string postalCode)
        {
            myInformationPage.SetFirstNameInput(firstName);
            myInformationPage.SetLastNameInput(lastName);
            myInformationPage.SetPostalCodeInput(postalCode);

        }

        [When("I click on the continue button")]
        public void WhenIClickOnTheContinueButton()
        {
            myInformationPage.ClickOnTheContinueButton();

        }

        [Then("I should be redirected to the overview page")]
        public void ThenIShouldBeRedirectedToTheOverviewPage()
        {
            overviewPage.VerifyOverviewTitleIsDisplayed();
        }

        [Then("error message \"(.*)\" is shown on checkout your information page")]
        public void ThenErrorMessageIsShownOnYourInfomationPage(string errorMessage)
        {
            myInformationPage.VerifyErrorMessageOnYourInformationPage(errorMessage);
        }

        [When("I get price for the item \"(.*)\" from the cart page")]
        public void WhenIGetTheItemPriceFromTheProductPage(string item)
        {
            itemsAndPrices.Add(item, cartPage.GetPriceForItem(item));
        }

        [Then("the price for the item \"(.*)\" in the overview should be the same as on cart page")]
        public void ThenThePriceInTheOverviewShouldBeTheSameAsOnCartPage(string item)
        {
            overviewPage.VerifyPriceForItemOnOverviewPage(itemsAndPrices[item], item);
        }

        [Then("the quantity of the item \"(.*)\" in the overview should be (.*)")]
        public void ThenTheQuantityInTheOverviewShouldBe(string item, string quantity)
        {
            overviewPage.VerifyQuantutyOfItemOnOverviewPage(item, quantity);
        }

          [Then("the item total in the overview should be sum of all items in the cart")]
        public void ThenTheItemTotalShouldBeTheSumOfAllItems()
        {
            overviewPage.VerifyItemTotalOnOverviewPage(itemsAndPrices);
        }

        [Then("the tax in the overview should be 8% of items total")]
        public void ThenTheTaxShouldBe8percentOfTheSumOfAllItems()
        {
            overviewPage.VerifyTaxOnOverviewPage(itemsAndPrices);
        }

        [Then("the total in the overview should be sum of tax and items total")]
        public void ThenTheTotalShouldBeTheSumOfItemTotalAndTax()
        {
            overviewPage.VerifyTotalOnOverviewPage(itemsAndPrices);
        }

        [When("I click on the cancel button")]
        public void WhenIClickOnTheCancelButton()
        {
            overviewPage.ClickOnTheCancelButton();

        }

        [When("I click on the finish button")]
        public void WhenIClickOnTheFinishButton()
        {
            overviewPage.ClickOnTheFinishButton();

        }

        [Then("I should be redirected to the checkout complete page")]
        public void ThenIShouldBeRedirectedToTheCheckoutCompletePage()
        {
            completePage.VerifyCompleteTitleIsDisplayed();
        }

        [When("I click on the back to home button")]
        public void WhenIClickOnTheBackToHomeButton()
        {
            completePage.ClickOnTheBackToHomeButton();

        }
    }
}
