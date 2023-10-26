using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Configurations;
using ToolsQAProject.Drivers;

namespace ToolsQAProject.StepDefinitions.Hooks
{
    [Binding]
    public sealed class TestInitializer
    {
        private readonly IObjectContainer _objectContainer;
        private readonly WebDriverManager _webDriverManager;

        public TestInitializer(WebDriverManager webDriverManager, IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _webDriverManager = webDriverManager;
        }

        [BeforeTestRun]
        public static void SetUp(AppSettingsConfig config)
        {
            config.SetApplicationConfiguration();
        }

        [BeforeScenario]
        public void StartWebDriver()
        {
            var webDriver = _webDriverManager.GetWebDriver();
            _objectContainer.RegisterInstanceAs(webDriver);
        }

        [AfterScenario]
        public void StopWebDriver(IWebDriver webDriver)
        {
            _webDriverManager.StopWebDriver(webDriver);
        }
    }
}