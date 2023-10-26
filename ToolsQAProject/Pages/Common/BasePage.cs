using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers.Extensions;

namespace ToolsQAProject.Pages.Common
{
    public abstract class BasePage<T> where T : BasePage<T>
    {
        private readonly IWebDriver _webDriver;
        private ReadOnlyCollection<IWebElement> AdsIframe => _webDriver.FindElements(By.XPath("//div[contains(@id,'google_ads_iframe') and .//iframe]"));

        protected BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public T RefreshPageIfAdsAreDisplayed()
        {
            foreach (var ads in AdsIframe)
            {
                ads.MakeHidden();
            }
            return (T)this;
        }
    }
}
