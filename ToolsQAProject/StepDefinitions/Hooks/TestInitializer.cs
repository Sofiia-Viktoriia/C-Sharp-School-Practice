using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Drivers;

namespace ToolsQAProject.StepDefinitions.Hooks
{
    [Binding]
    public sealed class TestInitializer
    {
        private readonly IObjectContainer _objectContainer;
        private WebDriverManager _webDriverManager;

        public TestInitializer(WebDriverManager webDriverManager, IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _webDriverManager = webDriverManager;
        }

        [BeforeScenario]
        public void StartWebDriver()
        {
            var webDriver = _webDriverManager.GetWebDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
        }

        [AfterScenario]
        public void StopWebDriver()
        {
            _webDriverManager.StopWebDriver();
        }
    }
}