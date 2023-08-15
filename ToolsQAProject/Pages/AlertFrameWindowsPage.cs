using NUnit.Framework;
using OpenQA.Selenium;

namespace ToolsQAProject.Pages
{
    public class AlertFrameWindowsPage : BasePage
    {
        private IWebElement ButtonByName(string buttonName) => WebDriver.FindElement(By.XPath($"//div[@id='browserWindows']//button[text()='{buttonName}']"));
        private IWebElement SampleText => WebDriver.FindElement(By.XPath("//h1[@id='sampleHeading']"));

        public AlertFrameWindowsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void ClickOnButton(string buttonName)
        {
            ButtonByName(buttonName).Click();
        }

        public void SwitchToAnotherTabWindow()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[1]);
        }

        public string GetSampleTextValue()
        {
            return SampleText.Text;
        }
    }
}
