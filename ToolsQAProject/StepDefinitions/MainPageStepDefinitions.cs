using TechTalk.SpecFlow;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions
{
    [Binding]
    public class MainPageStepDefinitions
    {
        private readonly MainPage _mainPage;

        public MainPageStepDefinitions(MainPage mainPage)
        {
            _mainPage = mainPage;
        }

        [Given(@"user opens the '([^']*)' category")]
        public void GivenUserOpensTheCategory(string categoryName)
        {
            _mainPage.OpenCategory(categoryName);
        }
    }
}
