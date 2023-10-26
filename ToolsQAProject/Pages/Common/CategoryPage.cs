using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ToolsQAProject.Helpers.Extensions;

namespace ToolsQAProject.Pages.Common
{
    public class CategoryPage : BasePage<CategoryPage>
    {
        private readonly IWebDriver _webDriver;
        private IWebElement SectionByName(string sectionName) => _webDriver.FindElement(By.XPath("//ul[@class='menu-list']" +
            $"/li[.//span[text()='{sectionName}']]"));

        public CategoryPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public CategoryPage SelectSection(string sectionName)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3));
            wait.Until(driver => SectionByName(sectionName).Displayed);
            SectionByName(sectionName).ScrollToElement().Click();
            return this;
        }
    }
}
