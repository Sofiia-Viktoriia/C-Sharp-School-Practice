using TechTalk.SpecFlow;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class AlertsFramesAndWindowsPageStepDefinitions
    {
        private readonly AlertFrameWindowsPage _alertFrameWindowsPage;

        public AlertsFramesAndWindowsPageStepDefinitions(AlertFrameWindowsPage alertFrameWindowsPage)
        {
            _alertFrameWindowsPage = alertFrameWindowsPage;
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
