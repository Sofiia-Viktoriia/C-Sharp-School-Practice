using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class AlertsFramesAndWindowsPageStepDefinitions
    {
        private AlertFrameWindowsPage _alertFrameWindowsPage;
        private const string SampleText = "This is a sample page";

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
            _alertFrameWindowsPage.SwitchToAnotherTabWindow();
            Assert.That(_alertFrameWindowsPage.GetSampleTextValue, Is.EqualTo(SampleText), $"The sample text does not equal to {SampleText}");
        }
    }
}
