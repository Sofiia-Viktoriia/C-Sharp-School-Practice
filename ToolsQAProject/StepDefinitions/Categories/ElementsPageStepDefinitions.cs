using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToolsQAProject.Constants;
using ToolsQAProject.Entities;
using ToolsQAProject.Pages.ElementsPage;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class ElementsPageStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly TextBoxSection _textBoxSection;
        private readonly CheckBoxSection _checkBoxSection;
        private readonly WebTablesSection _webTablesSection;
        private readonly ButtonsSection _buttonsSection;

        public ElementsPageStepDefinitions(ScenarioContext scenarioContext, TextBoxSection textBoxSection,
            CheckBoxSection checkBoxSection, WebTablesSection webTablesSection, ButtonsSection buttonsSection)
        {
            _scenarioContext = scenarioContext;
            _textBoxSection = textBoxSection;
            _checkBoxSection = checkBoxSection;
            _webTablesSection = webTablesSection;
            _buttonsSection = buttonsSection;
        }

        [When(@"user submits the form with the next data")]
        public void WhenUserSubmitsTheFormWithTheNextData(UserForm userForm)
        {
            _textBoxSection
                .FillFullName(userForm.FullName)
                .FillEmail(userForm.Email)
                .FillCurrentAddress(userForm.CurrentAddress)
                .FillPermanentAddress(userForm.PermanentAddress)
                .SubmitUserForm();
        }

        [Then(@"the table should contain entered values")]
        public void ThenTheTableShouldContainEnteredValues(UserForm result)
        {
            _textBoxSection.VerifyOutputTableValues(result);
        }

        [When(@"user expands the '([^']*)' folder")]
        public void WhenUserExpandsTheFolder(string elementName)
        {
            _checkBoxSection.ExpandFolder(elementName);
        }

        [When(@"user selects the '([^']*)' element")]
        [When(@"user selects the '([^']*)' folder")]
        public void WhenUserSelectsTheElement(string folderName)
        {
            _checkBoxSection.SelectElement(folderName);
        }

        [When(@"user selects all elements in the '([^']*)' folder")]
        public void WhenUserSelectsAllElementsInTheFolder(string folderName)
        {
            _checkBoxSection.SelectAllElementsInFolder(folderName);
        }

        [Then(@"the selection result should be equal '([^']*)'")]
        public void ThenTheSelectionResultShouldBeEqual(string selectionResult)
        {
            _checkBoxSection.VerifySelectionResult(selectionResult);
        }

        [When(@"user sorts values in the table by '([^']*)' column")]
        public void WhenUserSortsValuesInTheTableByColumn(string columnName)
        {
            _webTablesSection.ClickOnColumnName(columnName);
        }

        [Then(@"the values in the '([^']*)' column should be sorted ascending")]
        public void ThenTheValuesInTheColumnShouldBeSortedAscending(string columnName)
        {
            _webTablesSection.VerifyColumnValuesSortedAscending(columnName);
        }

        [Given(@"the amount of rows is remembered")]
        public void GivenTheAmountOfRowsIsRemembered()
        {
            _scenarioContext["RowAmount"] = _webTablesSection.GetAmountOfRowsInTable();
        }

        [When(@"user deletes the row with the '([^']*)' value equals '([^']*)'")]
        public void WhenUserDeletesTheRowWithTheValueEquals(string columnName, string columnValue)
        {
            _webTablesSection.ClickOnRowDeleteButton(columnName, columnValue);
        }

        [Then(@"the amount of rows in the table reduced by (\d+)")]
        public void ThenTheAmountOfRowsInTheTableReducedBy(int reduceNumber)
        {
            var expectedRowAmount = (int)_scenarioContext["RowAmount"] - reduceNumber;
            _webTablesSection.VerifyAmountOfRowsInTable(expectedRowAmount);
        }

        [Then(@"the row with the '([^']*)' value equals '([^']*)' should not exist")]
        public void ThenTheRowWithTheValueEqualsShouldNotExist(string columnName, string columnValue)
        {
            _webTablesSection.VerifyColumnDoesNotContainValue(columnName, columnValue);
        }

        [When(@"user interacts with the '([^']*)' button")]
        public void WhenUserInteractsWithTheButton(string buttonName)
        {
            switch (buttonName)
            {
                case Buttons.DoubleClickMe:
                    _buttonsSection.DoubleClickOnButton(buttonName);
                    break;
                case Buttons.RightClickMe:
                    _buttonsSection.RightClickOnButton(buttonName);
                    break;
                case Buttons.ClickMe:
                    _buttonsSection.ClickOnButton(buttonName);
                    break;
            }
        }

        [Then(@"the result '([^']*)' should be displayed")]
        public void ThenTheResultShouldBeDisplayed(string result)
        {
            _buttonsSection.VerifyClickingResultIsDisplayed(result);
        }
    }
}
