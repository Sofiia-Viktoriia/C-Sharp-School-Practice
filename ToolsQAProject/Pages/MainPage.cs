using OpenQA.Selenium;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages
{
    public class MainPage
    {
        private IWebDriver _webDriver;

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement CategoryByName(string categoryName) => _webDriver.FindElement(By.XPath("//div[@class='category-cards']" + 
            $"/div[contains(concat(' ', @class, ' '), ' card ') and .//h5[text()='{categoryName}']]"));

        public MainPage OpenCategory(string categoryName)
        {
            CategoryByName(categoryName).ScrollToElement().Click();
            return this;
        }
    }
}
