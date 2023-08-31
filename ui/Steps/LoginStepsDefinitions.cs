using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using ui.Core;
using ui.Core.Pages;

namespace ui.Steps
{
    [Binding]
    public sealed class LoginStepsDefinitions
    {

        LoginPage loginPage = new LoginPage();
        ProductsPage productsPage = new ProductsPage();

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            loginPage.OpenPage();
        }

        [When("I enter username \"(.*)\" and password \"(.*)\"")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            loginPage.SetUsernameInput(username);
            loginPage.SetPasswordInput(password);
            
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            loginPage.ClickOnLoginButton();
        }

        [Then("I should be redirected to the products page")]
        public void ThenIShouldBeRedirectedToTheHomePage()
        {
            productsPage.VerifyProductsTitleIsDisplayed();
        }

        [Then("error message \"(.*)\" is shown on login page")]
        public void ThenErrorMessageIsShownOnLoginPage(string errorMessage)
        {
            loginPage.VerifyErrorMessageOnLoginPage(errorMessage);
        }

        [When("I logout from the application")]
        public void WhenILogoutFromTheApplication()
        {
            productsPage.ClickOnTheMenu();
            productsPage.ClickOnTheLogout();
        }

        [Then("I should be redirected to the login page")]
        public void ThenIShouldBeRedirectedToTheLoginPage()
        {
            loginPage.VerifyThatLoginPageIsOpened();
        }
    }
}
