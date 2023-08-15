using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using ToolsQAProject.Drivers;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class WidgetsPageStepDefinitions : BaseStepDefinitions
    {
        private WidgetsPage _widgetsPage;

        public WidgetsPageStepDefinitions(WebDriverManager webDriverManager) : base(webDriverManager)
        {
            _widgetsPage = new WidgetsPage(GetWebDriver());
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

        [When(@"user adds values to the auto completing field with multiple values")]
        public void WhenUserAddsValuesToTheAutoCompletingFieldWithMultipleValues(Table table)
        {
            string[] values = table.Rows.Select(r => r[0]).ToArray();
            foreach (string value in values)
            {
                _widgetsPage.AddValueToAutoCompleteField(value);
            }
        }

        [When(@"user deletes values from the auto completing field with multiple values")]
        public void WhenUserDeletesValuesFromTheAutoCompletingFieldWithMultipleValues(Table table)
        {
            string[] values = table.Rows.Select(r => r[0]).ToArray();
            foreach (string value in values)
            {
                _widgetsPage.DeleteValueFromAutoCompleteField(value);
            }
        }

        [Then(@"the values are displayed in the auto completing field with multiple values")]
        public void ThenTheValuesAreDisplayedInTheAutoCompletingFieldWithMultipleValues(Table table)
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

        [When(@"user clicks '([^']*)' button")]
        public void WhenUserClicksButton(string buttonName)
        {
            _widgetsPage.ClickOnButton(buttonName);
        }

        [Then(@"progress bar value reaches '([^']*)'")]
        public void ThenProgressBarValueReaches(string value)
        {
            var wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(20));
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
