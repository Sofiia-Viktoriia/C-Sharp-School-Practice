﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using ToolsQAProject.Configurations;

namespace ToolsQAProject.Drivers
{
    public class WebDriverManager
    {
        private readonly AppSettingsOptions _appSettings;

        public WebDriverManager(AppSettingsOptions appSettings)
        {
            _appSettings = appSettings;
        }

        public IWebDriver GetWebDriver()
        {
            IWebDriver webDriver;
            switch (_appSettings.BrowserName)
            {
                case Browser.Chrome:
                    var options = new ChromeOptions();
                    options.AddExcludedArguments("enable-automation");
                    webDriver = new ChromeDriver(options);
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
