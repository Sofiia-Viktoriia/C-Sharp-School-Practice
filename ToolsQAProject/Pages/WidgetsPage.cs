using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers.Extensions;

namespace ToolsQAProject.Pages
{
    public class WidgetsPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement AutoCompleteMultipleValuesInput => _webDriver.FindElement(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']//input"));
        private ReadOnlyCollection<IWebElement> AutoCompleteSuggestions => _webDriver.FindElements(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']" +
            "//div[contains(concat(' ', @class, ' '), ' auto-complete__menu-list ')]/div"));
        private IWebElement AutoCompleteSuggestionByText(string text) => _webDriver.FindElement(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']" +
            $"//div[contains(concat(' ', @class, ' '), ' auto-complete__menu-list ')]/div[text()='{text}']"));
        private ReadOnlyCollection<IWebElement> AutoCompleteFieldValues => _webDriver.FindElements(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']" +
            $"//div[contains(concat(' ', @class, ' '), ' auto-complete__multi-value ')]/div[contains(concat(' ', @class, ' '), ' auto-complete__multi-value__label ')]"));
        private IWebElement AutoCompleteFiledValueRemoveButtonByText(string text) => _webDriver.FindElement(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']" +
            $"//div[contains(concat(' ', @class, ' '), ' auto-complete__multi-value ') and ./div[text()='{text}']]/div[contains(concat(' ', @class, ' '), ' auto-complete__multi-value__remove ')]"));
        private IWebElement ButtonByName(string buttonName) => _webDriver.FindElement(By.XPath($"//div[@id='progressBarContainer']//button[text()='{buttonName}']"));
        private IWebElement ProgressBar => _webDriver.FindElement(By.XPath("//div[@id='progressBarContainer']//div[@id='progressBar']/div"));

        public WidgetsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public WidgetsPage FillAutoCompletingField(string value)
        {
            AutoCompleteMultipleValuesInput.ScrollToElement().SendKeys(value);
            return this;
        }

        public WidgetsPage VerifyAmountOfSuggestions(int expectedAmount)
        {
            Assert.That(AutoCompleteSuggestions.Count, Is.EqualTo(expectedAmount), $"The amount of suggestions does not equal to {expectedAmount}");
            return this;
        }

        public WidgetsPage VerifyAllSuggestionsContainValue(string value)
        {
            Assert.Multiple(() =>
            {
                foreach (IWebElement suggestion in AutoCompleteSuggestions)
                {
                    Assert.That(suggestion.Text, Does.Contain(value).IgnoreCase, $"'{suggestion.Text}' does not contain '{value}'");
                }
            });
            return this;
        }

        public WidgetsPage AddValueToAutoCompleteField(string value)
        {
            FillAutoCompletingField(value);
            AutoCompleteSuggestionByText(value).Click();
            return this;
        }

        public WidgetsPage DeleteValueFromAutoCompleteField(string value)
        {
            AutoCompleteFiledValueRemoveButtonByText(value).Click();
            return this;
        }

        public WidgetsPage VerifyAutoCompleteFieldValuesAreDisplayed(string[] values)
        {
            string[] actualResult = AutoCompleteFieldValues.Select(element => element.Text).ToArray();
            Assert.That(values.SequenceEqual(actualResult), Is.True, "Expected entered values don't equal to the actual result");
            return this;
        }

        public WidgetsPage ClickOnButton(string buttonName)
        {
            ButtonByName(buttonName).ScrollToElement().Click();
            return this;
        }

        public WidgetsPage VerifyButtonIsDisplayed(string buttonName)
        {
            Assert.That(ButtonByName(buttonName).Displayed, Is.True, $"{buttonName} button is not displayed");
            return this;
        }

        public WidgetsPage WaitUntilProgressBarValue(string value)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            wait.Until(driver => ProgressBar.Text.Equals(value));
            return this;
        }

        public WidgetsPage VerifyProgressBarValue(string value)
        {
            Assert.That(ProgressBar.Text, Is.EqualTo(value), $"Progress bar value does not equal to {value}");
            return this;
        }
    }
}
