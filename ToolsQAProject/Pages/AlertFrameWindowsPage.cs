using NUnit.Framework;
using OpenQA.Selenium;
using ToolsQAProject.Pages.Common;

namespace ToolsQAProject.Pages
{
    public class AlertFrameWindowsPage : BasePage<AlertFrameWindowsPage>
    {
        public readonly IWebDriver _webDriver;
        private IWebElement ButtonByName(string buttonName) => _webDriver.FindElement(By.XPath($"//div[@id='browserWindows']//button[text()='{buttonName}']"));
        private IWebElement SampleText => _webDriver.FindElement(By.XPath("//h1[@id='sampleHeading']"));

        public AlertFrameWindowsPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public AlertFrameWindowsPage ClickOnButton(string buttonName)
        {
            ButtonByName(buttonName).Click();
            return this;
        }

        public AlertFrameWindowsPage SwitchToAnotherTabWindow()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[^1]);
            return this;
        }

        public AlertFrameWindowsPage VerifySampleTextValue(string expectedSampleText)
        {
            Assert.That(SampleText.Text, Is.EqualTo(expectedSampleText), $"The sample text does not equal to {expectedSampleText}");
            return this;
        }
    }
}
