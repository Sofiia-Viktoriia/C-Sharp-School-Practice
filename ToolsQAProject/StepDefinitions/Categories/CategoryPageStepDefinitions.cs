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

        [Given(@"user is on the '([^']*)' category page")]
        public void GivenUserIsOnTheCategoryPage(string pageTitle)
        {
            _categoryPage.VerifyPageTitle(pageTitle);
        }

        [Given(@"user opens the '([^']*)' section")]
        public void GivenUserOpensTheSection(string sectionName)
        {
            _categoryPage.SelectSection(sectionName);
        }
    }
}
