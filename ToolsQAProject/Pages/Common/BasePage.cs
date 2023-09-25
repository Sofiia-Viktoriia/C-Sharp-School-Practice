using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ToolsQAProject.Pages.Common
{
    public abstract class BasePage<T> where T : BasePage<T>
    {
        private readonly IWebDriver _webDriver;
        private ReadOnlyCollection<IWebElement> AdsIframe => _webDriver.FindElements(By.XPath("//div[@id='adplus-anchor']//iframe"));

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public T RefreshPageIfAdsAreDisplayed()
        {
            while (AdsIframe.Count > 0)
            {
                _webDriver.Navigate().Refresh();
            }

            return Self();
        }

        protected abstract T Self();
    }
}
