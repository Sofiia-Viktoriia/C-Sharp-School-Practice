using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ToolsQAProject.Drivers
{
    public class WebDriverManager
    {
        private IWebDriver _driver;

        public void StartWebDriver()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? browserName = configuration.GetSection("AppSettings")["BrowserName"];
            switch (browserName)
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "edge":
                    _driver = new EdgeDriver();
                    break;
                default:
                    throw new NotSupportedException("Not supported browser");
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.Url = configuration.GetSection("AppSettings")["URL"];
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
