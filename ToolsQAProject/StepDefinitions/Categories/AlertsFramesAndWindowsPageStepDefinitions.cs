using NUnit.Framework;
using TechTalk.SpecFlow;
using ToolsQAProject.Drivers;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class AlertsFramesAndWindowsPageStepDefinitions : BaseStepDefinitions
    {
        private AlertFrameWindowsPage _alertFrameWindowsPage;
        private const string SampleText = "This is a sample page";

        public AlertsFramesAndWindowsPageStepDefinitions(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _alertFrameWindowsPage = new AlertFrameWindowsPage(GetWebDriver());
        }

        [When(@"user clicks on '([^']*)' button")]
        public void WhenUserClicksOnButton(string buttonName)
        {
            _alertFrameWindowsPage.ClickOnButton(buttonName);
        }

        [Then(@"a new tab/window opens with '([^']*)' text in it")]
        public void ThenANewTabWindowOpensWithTextInIt(string text)
        {
            _alertFrameWindowsPage.SwitchToAnotherTabWindow();
            Assert.That(_alertFrameWindowsPage.GetSampleTextValue, Is.EqualTo(SampleText), $"The sample text does not equal to {SampleText}");
        }
    }
}
