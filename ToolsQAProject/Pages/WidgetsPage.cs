using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages
{
    internal class WidgetsPage
    {
        private IWebDriver _webDriver;
        private IWebElement AutoCompleteMultipleValuesInput => _webDriver.FindElement(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']//input"));
        private ReadOnlyCollection<IWebElement> AutoCompleteSuggestions => _webDriver.FindElements(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']" +
            "//div[contains(concat(' ', @class, ' '), ' auto-complete__menu-list ')]/div"));
        private IWebElement AutoCompleteSuggestionByText(string text) => _webDriver.FindElement(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']" +
            $"//div[contains(concat(' ', @class, ' '), ' auto-complete__menu-list ')]/div[text()='{text}']"));
        private IWebElement AutoCompleteFiledValueByText(string text) => _webDriver.FindElement(By.XPath("//div[@id='autoCompleteContainer']//div[@id='autoCompleteMultiple']"+ 
            $"//div[contains(concat(' ', @class, ' '), ' auto-complete__multi-value ') and ./div[text()='{text}']]"));
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

        public int GetAmountOfSuggestions()
        {
            return AutoCompleteSuggestions.Count;
        }

        public ReadOnlyCollection<IWebElement> GetAllSuggestions()
        {
            return AutoCompleteSuggestions;
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

        public bool IsAutoCompleteFieldValueDisplayed(string value)
        {
            return AutoCompleteFiledValueByText(value).Displayed;
        }

        public WidgetsPage ClickOnButton(string buttonName)
        {
            ButtonByName(buttonName).ScrollToElement().Click();
            return this;
        }

        public bool IsButtonDisplayed(string buttonName)
        {
            return ButtonByName(buttonName).Displayed;
        }

        public string GetProgressBarValue()
        {
            return ProgressBar.Text;
        }
    }
}
