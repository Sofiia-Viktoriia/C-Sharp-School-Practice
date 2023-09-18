using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions
{
    [Binding]
    public class MainPageStepDefinitions
    {
        private MainPage _mainPage;

        public MainPageStepDefinitions(IWebDriver webDriver)
        {
            _mainPage = new MainPage(webDriver);
        }

        [Given(@"user opens the '([^']*)' category")]
        public void GivenUserOpensTheCategory(string categoryName)
        {
            _mainPage.OpenCategory(categoryName);
        }
    }
}
