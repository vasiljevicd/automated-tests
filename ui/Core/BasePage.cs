using OpenQA.Selenium;
using ui.Hook;

namespace ui.Core
{
    public class BasePage
    {

        public IWebDriver driver;
        public BaseWebElement baseWebElement;
        public string url;

        public BasePage()
        {
            driver = Hooks.driver;
            baseWebElement = Hooks.webElement;

        }

        public void NavigateToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetPageURL()
        {
            return driver.Url;
        }
    }
}