using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class InteractionsPageStepDefinitions
    {
        private InteractionsPage _interactionsPage;

        public InteractionsPageStepDefinitions(IWebDriver webDriver)
        {
            _interactionsPage = new InteractionsPage(webDriver);
        }

        [When(@"user switches to '([^']*)' tab")]
        public void WhenUserSelectsSquares(string tabName)
        {
            _interactionsPage.SwitchToTab(tabName);
        }

        [When(@"user selects squares")]
        public void WhenUserSelectsSquares(Table table)
        {
            int[] numbers = table.Rows.Select(r => int.Parse(r[0])).ToArray();
            foreach (int number in numbers)
            {
                _interactionsPage.SelectGridSquare(number);
            }
        }

        [Then(@"selected squares contain values")]
        public void ThenSelectedSquaresContainValues(Table table)
        {
            string[] expectedValues = table.Rows.Select(r => r[0]).ToArray();
            string[] actualValues = _interactionsPage.GetSelectedGridSquaresValues();
            Assert.That(actualValues.OrderBy(value => value).SequenceEqual(expectedValues.OrderBy(value => value)), Is.True,
                "Selected grid squares do not contain expected values");
        }
    }
}
