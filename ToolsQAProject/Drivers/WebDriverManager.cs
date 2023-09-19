using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using ToolsQAProject.Configurations;

namespace ToolsQAProject.Drivers
{
    public class WebDriverManager
    {
        private AppSettingsOptions? _appSettings;

        public IWebDriver GetWebDriver()
        {
            IWebDriver webDriver;
            _appSettings = AppSettingsConfig.GetApplicationConfiguration();
            switch (_appSettings?.BrowserName)
            {
                case Browser.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                case Browser.Firefox:
                    webDriver = new FirefoxDriver();
                    break;
                case Browser.Edge:
                    webDriver = new EdgeDriver();
                    break;
                default:
                    throw new NotSupportedException("Not supported browser");
            }
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            webDriver.Url = _appSettings.URL;
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }

        public void StopWebDriver(IWebDriver webDriver)
        {
            webDriver.Quit();
        }
    }
}
