using OpenQA.Selenium;

namespace ToolsQAProject.Pages
{
    public class BasePage
    {
        public IWebDriver WebDriver { get; }

        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
