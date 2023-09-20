using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class AlertsFramesAndWindowsPageStepDefinitions
    {
        private AlertFrameWindowsPage _alertFrameWindowsPage;

        public AlertsFramesAndWindowsPageStepDefinitions(IWebDriver webDriver)
        {
            _alertFrameWindowsPage = new AlertFrameWindowsPage(webDriver);
        }

        [When(@"user opens '([^']*)'")]
        public void WhenUserOpens(string value)
        {
            _alertFrameWindowsPage.ClickOnButton(value);
        }

        [Then(@"a new tab/window opens with '([^']*)' text in it")]
        public void ThenANewTabWindowOpensWithTextInIt(string text)
        {
            _alertFrameWindowsPage.SwitchToAnotherTabWindow()
                .VerifySampleTextValue(text);
        }
    }
}
