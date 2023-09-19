using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using TechTalk.SpecFlow;
using ToolsQAProject.Constants;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class WidgetsPageStepDefinitions
    {
        private IWebDriver _webDriver;
        private WidgetsPage _widgetsPage;

        public WidgetsPageStepDefinitions(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _widgetsPage = new WidgetsPage(webDriver);
        }

        [When(@"user enters '([^']*)' value into the auto completing field with multiple values")]
        public void WhenUserEntersValueIntoTheAutoCompletingFieldWithMultipleValues(string value)
        {
            _widgetsPage.FillAutoCompletingField(value);
        }

        [Then(@"list with (.*) suggestions appears")]
        public void ThenListWithSuggestionsAppears(int suggestionAmount)
        {
            Assert.That(_widgetsPage.GetAmountOfSuggestions(), Is.EqualTo(suggestionAmount), $"The amount of suggestions does not equal to {suggestionAmount}");
        }

        [Then(@"all suggestions contain '([^']*)' value")]
        public void ThenAllSuggestionsContainValue(string value)
        {
            Assert.Multiple(() =>
            {
                foreach (IWebElement suggestion in _widgetsPage.GetAllSuggestions())
                {
                    Assert.That(suggestion.Text, Does.Contain(value).IgnoreCase, $"'{suggestion.Text}' does not contain '{value}'");
                }
            });
        }

        [When(@"user adds values to the multiple color selection field")]
        public void WhenUserAddsValuesToTheMultipleColorSelectionField(Table table)
        {
            string[] values = table.Rows.Select(r => r[0]).ToArray();
            foreach (string value in values)
            {
                _widgetsPage.AddValueToAutoCompleteField(value);
            }
        }

        [When(@"user deletes values from the multiple color selection field")]
        public void WhenUserDeletesValuesFromTheMultipleColorSelectionField(Table table)
        {
            string[] values = table.Rows.Select(r => r[0]).ToArray();
            foreach (string value in values)
            {
                _widgetsPage.DeleteValueFromAutoCompleteField(value);
            }
        }

        [Then(@"the values are displayed in the multiple color selection field")]
        public void ThenTheValuesAreDisplayedInTheMultipleColorSelectionField(Table table)
        {
            string[] values = table.Rows.Select(r => r[0]).ToArray();
            Assert.Multiple(() =>
            {
                foreach (string value in values)
                {
                    Assert.That(_widgetsPage.IsAutoCompleteFieldValueDisplayed(value), Is.True, $"'{value}' value is not in the auto complete field");
                }
            });
        }

        [When(@"user starts filling the progress bar") ]
        public void WhenUserStartsFillingTheProgressBar()
        {
            _widgetsPage.ClickOnButton(Buttons.Start);
        }

        [When(@"user resets the progress bar")]
        public void WhenUserResetsTheProgressBar()
        {
            _widgetsPage.ClickOnButton(Buttons.Reset);
        }

        [Then(@"progress bar value reaches '([^']*)'")]
        public void ThenProgressBarValueReaches(string value)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            wait.Until(driver => _widgetsPage.GetProgressBarValue().Equals(value));
        }

        [Then(@"'([^']*)' button is displayed")]
        public void ThenButtonIsDisplayed(string buttonName)
        {
            Assert.That(_widgetsPage.IsButtonDisplayed(buttonName), Is.True, $"{buttonName} button is not displayed");
        }

        [Then(@"progress bar value equals to '([^']*)'")]
        public void ThenProgressBarValueEqualsTo(string value)
        {
            Assert.That(_widgetsPage.GetProgressBarValue, Is.EqualTo(value), $"Progress bar value does not equal to {value}");
        }
    }
}
