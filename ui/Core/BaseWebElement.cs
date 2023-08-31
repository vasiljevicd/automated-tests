using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Xml.Linq;

namespace ui.Core
{
	public class BaseWebElement
	{

		private static  IWebDriver _driver;
		private WebDriverWait wait;

		public BaseWebElement(IWebDriver driver)
		{
			_driver = driver;

        }

		public void NavigateToURL(string url){
			 _driver.Navigate().GoToUrl(url);
             WaitPageToLoad();

        }

		public void SetText(IWebElement element, string text){
			WaitForElementToBeDisplayed(element);
            element.SendKeys(text);
		}

        public void ClickOnElement(IWebElement element)
        {
            WaitForElementToBeClicable(element);
            element.Click();
            WaitPageToLoad();
        }

		public string GetElementText(IWebElement element)
		{
            WaitForElementToBeDisplayed(element);
            return element.Text;
		}

        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                WaitForElementToBeDisplayed(element);
                return element.Displayed;
            }catch(NoSuchElementException e)
            {
                return false;
            }
  
        }


        //finding element methods
        public IWebElement FindElementById(string id)
        {
            return _driver.FindElement(By.Id(id));
        }

        public IWebElement FindElementByClassName(string className)
        {

            return _driver.FindElement(By.ClassName(className));
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            return _driver.FindElement(By.XPath(xpath));
        }

        //waiting methods
        public bool WaitForElementToBeDisplayed(IWebElement element)
		{
            int count = 0;
            try
            {
			while(!element.Displayed && count/10 <= 100){
					count++;
					ImplicitWait(200);
                }
			return true;
			} catch(NoSuchElementException e){
				return false;
			}
			
		}

        public void WaitForElementToBeClicable(IWebElement element)
        {
            try
            {
                wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            
            }catch(Exception e)
            {
                throw e;
            }
          

        }

        public void WaitPageToLoad()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");

            }
            catch (Exception e)
            {
                throw e;
            }


        }


        public void ImplicitWait(int ms)
		{
            Thread.Sleep(ms);
        }

    }
}