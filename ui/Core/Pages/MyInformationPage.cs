using System;
using NUnit.Framework;
using OpenQA.Selenium;
using ui.Config;

namespace ui.Core.Pages
{
	public class MyInformationPage :BasePage
	{
        private IWebElement firstNameInput => driver.FindElement(By.Id("first-name"));
        private IWebElement lastNameInput => driver.FindElement(By.Id("last-name"));
        private IWebElement postalCodeInput => driver.FindElement(By.Id("postal-code"));
        private IWebElement yourInfomationTitle => driver.FindElement(By.XPath("//span[text()='Checkout: Your Information']"));
        private IWebElement continueButton => driver.FindElement(By.Id("continue"));
        private IWebElement errorMessage => driver.FindElement(By.XPath("//div[@class='error-message-container error']/h3"));


        public MyInformationPage()
		{
            url = Configuration.baseUrl + "checkout-step-one.html";

        }

        public void SetFirstNameInput(string firstName)
        {
            baseWebElement.SetText(firstNameInput, firstName);
        }

        public void SetLastNameInput(string lastName)
        {
            baseWebElement.SetText(lastNameInput, lastName);
        }

        public void SetPostalCodeInput(string postalCode)
        {
            baseWebElement.SetText(postalCodeInput, postalCode);
        }

        public void VerifyYourInformationTitleIsDisplayed()
        {
            Assert.IsTrue(baseWebElement.IsElementDisplayed(yourInfomationTitle));

        }

        public void ClickOnTheContinueButton()
        {
            baseWebElement.ClickOnElement(continueButton);
        }

        public void VerifyErrorMessageOnYourInformationPage(string errorMessageString)
        {
            Assert.AreEqual(errorMessageString, baseWebElement.GetElementText(errorMessage));
        }
    }
}

