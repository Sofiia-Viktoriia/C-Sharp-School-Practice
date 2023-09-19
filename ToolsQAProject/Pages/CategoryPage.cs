using NUnit.Framework;
using OpenQA.Selenium;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages
{
    public class CategoryPage
    {
        private IWebDriver _webDriver;
        private IWebElement PageTitle(string pageTitle) => _webDriver.FindElement(By.XPath($"//div[text()='{pageTitle}']"));
        private IWebElement SectionByName(string sectionName) => _webDriver.FindElement(By.XPath("//ul[@class='menu-list']" +
            $"/li[.//span[text()='{sectionName}']]"));

        public CategoryPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void VerifyPageTitle(string pageTitle)
        {
            Assert.That(PageTitle(pageTitle).Displayed, Is.True, $"Page {pageTitle} is not displayed");
        }

        public void SelectSection(string sectionName)
        {
            SectionByName(sectionName).ScrollToElement().Click();
        }
    }
}
