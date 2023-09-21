using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Pages.Common;

namespace ToolsQAProject.StepDefinitions.Common
{
    [Binding]
    public class CategoryPageStepDefinitions
    {
        private readonly CategoryPage _categoryPage;

        public CategoryPageStepDefinitions(IWebDriver webDriver)
        {
            _categoryPage = new CategoryPage(webDriver);
        }

        [Given(@"user opens the '([^']*)' section")]
        public void GivenUserOpensTheSection(string sectionName)
        {
            _categoryPage.SelectSection(sectionName);
        }
    }
}
