using OpenQA.Selenium;
using ToolsQAProject.Drivers;

namespace ToolsQAProject.StepDefinitions
{
    public class BaseStepDefinitions
    {
        public WebDriverManager DriverManager { get; }

        public BaseStepDefinitions(WebDriverManager webDriverManager)
        {
            DriverManager = webDriverManager;
        }

        public IWebDriver GetWebDriver()
        {
            return DriverManager.GetWebDriver();
        }
    }
}
