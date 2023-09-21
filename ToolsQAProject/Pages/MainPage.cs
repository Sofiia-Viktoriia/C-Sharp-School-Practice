using OpenQA.Selenium;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages
{
    public class MainPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement CategoryByName(string categoryName) => _webDriver.FindElement(By.XPath("//div[@class='category-cards']" + 
            $"/div[contains(concat(' ', @class, ' '), ' card ') and .//h5[text()='{categoryName}']]"));

        public MainPage(IWebDriver webDriver)
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
