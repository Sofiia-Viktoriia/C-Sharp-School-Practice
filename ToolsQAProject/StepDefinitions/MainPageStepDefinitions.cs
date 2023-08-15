using TechTalk.SpecFlow;
using ToolsQAProject.Drivers;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions
{
    [Binding]
    public class MainPageStepDefinitions : BaseStepDefinitions
    {
        private MainPage _mainPage;

        public MainPageStepDefinitions(WebDriverManager webDriverManager) : base(webDriverManager) 
        {
            _mainPage = new MainPage(GetWebDriver());
        }

        [Given(@"user opens the '([^']*)' category")]
        public void GivenUserOpensTheCategory(string categoryName)
        {
            _mainPage.OpenCategory(categoryName);
        }
    }
}
