using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using ui.Config;

namespace ui.Core.Pages
{
	public class LoginPage : BasePage
	{
        private IWebElement usernameInput => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordInput => driver.FindElement(By.Id("password"));
        private IWebElement loginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement errorMessage => driver.FindElement(By.XPath("//div[@class='error-message-container error']/h3"));

        public LoginPage()
		{
			url = Configuration.baseUrl;

        }

        public void OpenPage()
        {
            baseWebElement.NavigateToURL(url);
        }

        public void SetUsernameInput(string username)
        {
            baseWebElement.SetText(usernameInput, username);
        }

        public void SetPasswordInput(string password)
        {
            baseWebElement.SetText(passwordInput, password);
        }

        public void ClickOnLoginButton()
        {
            baseWebElement.ClickOnElement(loginButton);
        }

        public void VerifyErrorMessageOnLoginPage(string errorMessageString)
        {
            Assert.AreEqual(errorMessageString, baseWebElement.GetElementText(errorMessage));
        }

        public void VerifyThatLoginPageIsOpened()
        {
            Assert.AreEqual(url, GetPageURL());
        }
    }
}

