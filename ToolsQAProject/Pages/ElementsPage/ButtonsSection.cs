﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ToolsQAProject.Helpers.Extensions;
using ToolsQAProject.Pages.Common;

namespace ToolsQAProject.Pages.ElementsPage
{
    public class ButtonsSection : BasePage<ButtonsSection>
    {
        private readonly IWebDriver _webDriver;
        private IWebElement ButtonByName(string buttonName) => _webDriver.FindElement(By.XPath($"//div/button[text()='{buttonName}']"));
        private IWebElement ClickingResultByText(string resultText) => _webDriver.FindElement(By.XPath($"//p[text()='{resultText}']"));

        public ButtonsSection(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public ButtonsSection ClickOnButton(string buttonName)
        {
            ButtonByName(buttonName).ScrollToElement().Click();
            return this;
        }

        public ButtonsSection DoubleClickOnButton(string buttonName)
        {
            new Actions(_webDriver).MoveToElement(ButtonByName(buttonName))
                .DoubleClick(ButtonByName(buttonName)).Build().Perform();
            return this;
        }

        public ButtonsSection RightClickOnButton(string buttonName)
        {
            RefreshPageIfAdsAreDisplayed();
            new Actions(_webDriver).ContextClick(ButtonByName(buttonName)).Build().Perform();
            return this;
        }

        public ButtonsSection VerifyClickingResultIsDisplayed(string resultText)
        {
            Assert.That(ClickingResultByText(resultText).Displayed, Is.True, "The clicking result is not displayed");
            return this;
        }
    }
}
