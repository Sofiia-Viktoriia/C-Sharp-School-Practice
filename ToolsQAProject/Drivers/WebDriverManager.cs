using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using ToolsQAProject.Configurations;

namespace ToolsQAProject.Drivers
{
    public class WebDriverManager
    {
        private IWebDriver _driver;
        private AppSettingsOptions? _appSettings;

        public void StartWebDriver()
        {
            _appSettings = AppSettingsConfig.GetApplicationConfiguration();
            switch (_appSettings?.BrowserName)
            {
                case Browser.Chrome:
                    _driver = new ChromeDriver();
                    break;
                case Browser.Firefox:
                    _driver = new FirefoxDriver();
                    break;
                case Browser.Edge:
                    _driver = new EdgeDriver();
                    break;
                default:
                    throw new NotSupportedException("Not supported browser");
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.Url = _appSettings.URL;
            _driver.Manage().Window.Maximize();
        }

        public IWebDriver GetWebDriver()
        {
            return _driver;
        }

        public void StopWebDriver()
        {
            _driver?.Quit();
        }
    }
}
