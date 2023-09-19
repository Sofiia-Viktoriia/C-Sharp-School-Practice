using NUnit.Framework;
using OpenQA.Selenium;

namespace ToolsQAProject.Pages
{
    public class AlertFrameWindowsPage
    {
        public IWebDriver _webDriver;
        private IWebElement ButtonByName(string buttonName) => _webDriver.FindElement(By.XPath($"//div[@id='browserWindows']//button[text()='{buttonName}']"));
        private IWebElement SampleText => _webDriver.FindElement(By.XPath("//h1[@id='sampleHeading']"));

        public AlertFrameWindowsPage(IWebDriver webDriver)
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

        public string GetSampleTextValue()
        {
            return SampleText.Text;
        }
    }
}
