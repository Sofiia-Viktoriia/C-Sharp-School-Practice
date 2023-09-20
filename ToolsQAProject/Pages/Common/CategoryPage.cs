using OpenQA.Selenium;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages.Common
{
    public class CategoryPage
    {
        private IWebDriver _webDriver;
        private IWebElement SectionByName(string sectionName) => _webDriver.FindElement(By.XPath("//ul[@class='menu-list']" +
            $"/li[.//span[text()='{sectionName}']]"));

        public CategoryPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CategoryPage SelectSection(string sectionName)
        {
            SectionByName(sectionName).ScrollToElement().Click();
            return this;
        }
    }
}
