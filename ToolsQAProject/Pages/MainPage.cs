using OpenQA.Selenium;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement CategoryByName(string categoryName) => WebDriver.FindElement(By.XPath("//div[@class='category-cards']" + 
            $"/div[contains(concat(' ', @class, ' '), ' card ') and .//h5[text()='{categoryName}']]"));

        public void OpenCategory(string categoryName)
        {
            CategoryByName(categoryName).ScrollToElement().Click();
        }
    }
}
