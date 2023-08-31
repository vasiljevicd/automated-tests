using System;
using NUnit.Framework;
using OpenQA.Selenium;
using ui.Config;

namespace ui.Core.Pages
{
	public class CompletePage : BasePage
	{
        private IWebElement completeTitle => driver.FindElement(By.XPath("//span[text()='Checkout: Complete!']"));
        private IWebElement backToHomeButton => driver.FindElement(By.Id("back-to-products"));

        public CompletePage()
		{
            url = Configuration.baseUrl + "/checkout-complete.html";

        }

        public void VerifyCompleteTitleIsDisplayed()
        {
            Assert.IsTrue(baseWebElement.IsElementDisplayed(completeTitle));

        }

        public void ClickOnTheBackToHomeButton()
        {
            baseWebElement.ClickOnElement(backToHomeButton);
        }
    }
}

