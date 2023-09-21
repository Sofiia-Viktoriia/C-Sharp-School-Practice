using TechTalk.SpecFlow;
using ToolsQAProject.Constants;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class WidgetsPageStepDefinitions
    {
        private readonly WidgetsPage _widgetsPage;

        public WidgetsPageStepDefinitions(WidgetsPage widgetsPage)
        {
            _widgetsPage = widgetsPage;
        }

        [When(@"user enters '([^']*)' value into the auto completing field with multiple values")]
        public void WhenUserEntersValueIntoTheAutoCompletingFieldWithMultipleValues(string value)
        {
            _widgetsPage.FillAutoCompletingField(value);
        }

        [Then(@"list with (.*) suggestions appears")]
        public void ThenListWithSuggestionsAppears(int suggestionAmount)
        {
            _widgetsPage.VerifyAmountOfSuggestions(suggestionAmount);
        }

        [Then(@"all suggestions contain '([^']*)' value")]
        public void ThenAllSuggestionsContainValue(string value)
        {
            _widgetsPage.VerifyAllSuggestionsContainValue(value);
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
            _widgetsPage.VerifyAutoCompleteFieldValuesAreDisplayed(values);
        }

        [When(@"user starts filling the progress bar")]
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
            _widgetsPage.WaitUntilProgressBarValue(value);
        }

        [Then(@"'([^']*)' button is displayed")]
        public void ThenButtonIsDisplayed(string buttonName)
        {
            _widgetsPage.VerifyButtonIsDisplayed(buttonName);
        }

        [Then(@"progress bar value equals to '([^']*)'")]
        public void ThenProgressBarValueEqualsTo(string value)
        {
            _widgetsPage.VerifyProgressBarValue(value);
        }
    }
}
