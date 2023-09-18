using TechTalk.SpecFlow;
using ToolsQAProject.Drivers;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class CategoryPageStepDefinitions : BaseStepDefinitions
    {
        private CategoryPage _categoryPage;

        public CategoryPageStepDefinitions(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _categoryPage = new CategoryPage(GetWebDriver());
        }

        [Given(@"user opens the '([^']*)' section")]
        public void GivenUserOpensTheSection(string sectionName)
        {
            _categoryPage.SelectSection(sectionName);
        }
    }
}
