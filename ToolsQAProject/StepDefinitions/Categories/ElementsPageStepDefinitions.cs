using NUnit.Framework;
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
        private ElementsPage _elementsPage;
        private const string DoubleClickMeButtonName = "Double Click Me";
        private const string RightClickMeButtonName = "Right Click Me";
        private const string ClickMeButtonName = "Click Me";

        public ElementsPageStepDefinitions(IWebDriver webDriver)
        {
            _elementsPage = new ElementsPage(webDriver);
        }

        [When(@"user submits the form with the next data")]
        public void WhenUserSubmitsTheFormWithTheNextData(Table table)
        {
            UserForm userForm = table.CreateInstance<UserForm>();
            _elementsPage.FillUserForm(userForm);
            _elementsPage.SubmitUserForm();
        }

        [Then(@"the table should contain entered values")]
        public void ThenTheTableShouldContainEnteredValues(Table table)
        {
            UserForm userForm = new UserForm
            {
                FullName = _elementsPage.GetUserFormOutputName(),
                Email = _elementsPage.GetUserFormOutputEmail(),
                CurrentAddress = _elementsPage.GetUserFormOutputCurrentAddress(),
                PermanentAddress = _elementsPage.GetUserFormOutputPermanentAddress()
            };

            table.CompareToInstance(userForm);
        }

        [When(@"user opens the '([^']*)' element")]
        public void WhenUserOpensTheElement(string elementName)
        {
            _elementsPage.OpenElement(elementName);
        }

        [When(@"user selects the '([^']*)' element")]
        public void WhenUserSelectsTheElement(string elementName)
        {
            _elementsPage.SelectElement(elementName);
        }

        [When(@"user selects all elements in the '([^']*)' folder")]
        public void WhenUserSelectsAllElementsInTheFolder(string folderName)
        {
            _elementsPage.SelectElementsInFolder(folderName);
        }

        [Then(@"the selection result should be equal '([^']*)'")]
        public void ThenTheSelectionResultShouldBeEqual(string selectionResult)
        {
            Assert.That(_elementsPage.GetSelectionResult().Replace("\r\n", " "), Is.EqualTo(selectionResult), $"The selection result does not equal to {selectionResult}");
        }

        [Given(@"the amount of rows equals (\d+)")]
        public void GivenTheAmountOfRowsEquals(int rowAmount)
        {
            Assert.That(_elementsPage.GetAmountOfRowsInTable, Is.EqualTo(rowAmount), $"The amount of table rows does not equal to {rowAmount}");
        }

        [When(@"user clicks on the '([^']*)' column name")]
        public void WhenUserClicksOnTheColumnName(string columnName)
        {
            _elementsPage.ClickOnColumnName(columnName);
        }

        [Then(@"the values in the '([^']*)' numeric column should be sorted ascending")]
        public void ThenTheValuesInTheNumericColumnShouldBeSortedAscending(string columnName)
        {
            List<string> values = _elementsPage.GetColumnValues(columnName);
            Assert.That(values.OrderBy(el => int.Parse(el)).SequenceEqual(values), Is.True, $"The {columnName} column values are not sorted ascending");
        }

        [When(@"user deletes the row with the '([^']*)' value equals '([^']*)'")]
        public void WhenUserDeletesTheRowWithTheValueEquals(string columnName, string columnValue)
        {
            _elementsPage.ClickOnRowDeleteButton(columnName, columnValue);
        }

        [Then(@"the amount of rows should be equal (\d+)")]
        public void ThenTheAmountOfRowsShouldBeEqual(int rowAmount)
        {
            Assert.That(_elementsPage.GetAmountOfRowsInTable, Is.EqualTo(rowAmount), $"The amount of table rows does not equal to {rowAmount}");
        }

        [Then(@"the row with the '([^']*)' value equals '([^']*)' should not exist")]
        public void ThenTheRowWithTheValueEqualsShouldNotExist(string columnName, string columnValue)
        {
            Assert.That(_elementsPage.IfColumnContainsValue(columnName, columnValue), Is.False, $"The row with the {columnName} value {columnValue} exists");
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
            Assert.That(_elementsPage.IfClickingResultDisplayed(result), Is.True, "The clicking result is not displayed");
        }
    }
}
