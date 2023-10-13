using OpenQA.Selenium;
using ToolsQAProject.Helpers.Extensions;
using ToolsQAProject.Pages.Common;

namespace ToolsQAProject.Pages
{
    public class MainPage : BasePage<MainPage>
    {
        private readonly IWebDriver _webDriver;
        private IWebElement CategoryByName(string categoryName) => _webDriver.FindElement(By.XPath("//div[@class='category-cards']" +
            $"/div[contains(concat(' ', @class, ' '), ' card ') and .//h5[text()='{categoryName}']]"));

        public MainPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public MainPage OpenCategory(string categoryName)
        {
            CategoryByName(categoryName).ScrollToElement().Click();
            return this;
        }
    }
}
