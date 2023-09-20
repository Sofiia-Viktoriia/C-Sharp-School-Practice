using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToolsQAProject.Pages;
using ToolsQAProject.StepDefinitions.Entities;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class ElementsPageStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private ElementsPage _elementsPage;
        private const string DoubleClickMeButtonName = "Double Click Me";
        private const string RightClickMeButtonName = "Right Click Me";
        private const string ClickMeButtonName = "Click Me";

        public ElementsPageStepDefinitions(IWebDriver webDriver, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _elementsPage = new ElementsPage(webDriver);
        }

        [When(@"user submits the form with the next data")]
        public void WhenUserSubmitsTheFormWithTheNextData(Table table)
        {
            UserForm userForm = table.CreateInstance<UserForm>();
            _elementsPage.FillUserForm(userForm)
                .SubmitUserForm();
        }

        [Then(@"the table should contain entered values")]
        public void ThenTheTableShouldContainEnteredValues(Table table)
        {
            _elementsPage.VerifyOutputTableValues(table);
        }

        [When(@"user expands the '([^']*)' folder")]
        public void WhenUserExpandsTheFolder(string elementName)
        {
            _elementsPage.ExpandFolder(elementName);
        }

        [When(@"user selects the '([^']*)' element")]
        [When(@"user selects the '([^']*)' folder")]
        public void WhenUserSelectsTheElement(string folderName)
        {
            _elementsPage.SelectElement(folderName);
        }

        [When(@"user selects all elements in the '([^']*)' folder")]
        public void WhenUserSelectsAllElementsInTheFolder(string folderName)
        {
            _elementsPage.SelectElementsInFolder(folderName);
        }

        [Then(@"the selection result should be equal '([^']*)'")]
        public void ThenTheSelectionResultShouldBeEqual(string selectionResult)
        {
            _elementsPage.VerifySelectionResult(selectionResult);
        }

        [When(@"user sorts values in the table by '([^']*)' column")]
        public void WhenUserSortsValuesInTheTableByColumn(string columnName)
        {
            _elementsPage.ClickOnColumnName(columnName);
        }

        [Then(@"the values in the '([^']*)' column should be sorted ascending")]
        public void ThenTheValuesInTheColumnShouldBeSortedAscending(string columnName)
        {
            _elementsPage.VerifyColumnValuesSortedAscending(columnName);
        }

        [Given(@"the amount of rows is remembered")]
        public void GivenTheAmountOfRowsIsRemembered()
        {
            _scenarioContext["RowAmount"] = _elementsPage.GetAmountOfRowsInTable();
        }

        [When(@"user deletes the row with the '([^']*)' value equals '([^']*)'")]
        public void WhenUserDeletesTheRowWithTheValueEquals(string columnName, string columnValue)
        {
            _elementsPage.ClickOnRowDeleteButton(columnName, columnValue);
        }

        [Then(@"the amount of rows in the table reduced by (\d+)")]
        public void ThenTheAmountOfRowsInTheTableReducedBy(int reduceNumber)
        {
            var expectedRowAmount = (int)_scenarioContext["RowAmount"] - reduceNumber;
            _elementsPage.VerifyAmountOfRowsInTable(expectedRowAmount);
        }

        [Then(@"the row with the '([^']*)' value equals '([^']*)' should not exist")]
        public void ThenTheRowWithTheValueEqualsShouldNotExist(string columnName, string columnValue)
        {
            _elementsPage.VerifyColumnDoesNotContainValue(columnName, columnValue);
        }

        [When(@"user interacts with the '([^']*)' button")]
        public void WhenUserInteractsWithTheButton(string buttonName)
        {
            switch (buttonName)
            {
                case DoubleClickMeButtonName:
                    _elementsPage.DoubleClickOnButton(buttonName);
                    break;
                case RightClickMeButtonName:
                    _elementsPage.RightClickOnButton(buttonName);
                    break;
                case ClickMeButtonName:
                    _elementsPage.ClickOnButton(buttonName);
                    break;
            }
        }

        [Then(@"the result '([^']*)' should be displayed")]
        public void ThenTheResultShouldBeDisplayed(string result)
        {
            _elementsPage.VerifyClickingResultIsDisplayed(result);
        }
    }
}
