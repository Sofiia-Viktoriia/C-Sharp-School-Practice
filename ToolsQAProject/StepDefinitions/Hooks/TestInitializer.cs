using TechTalk.SpecFlow;
using ToolsQAProject.Drivers;

namespace ToolsQAProject.StepDefinitions.Hooks
{
    [Binding]
    public sealed class TestInitializer : BaseStepDefinitions
    {
        public TestInitializer(WebDriverManager webDriverManager) : base(webDriverManager)
        {
        }

        [BeforeScenario]
        public void StartWebDriver()
        {
            DriverManager.StartWebDriver();
        }

        [AfterScenario]
        public void StopWebDriver()
        {
            DriverManager.StopWebDriver();
        }
    }
}