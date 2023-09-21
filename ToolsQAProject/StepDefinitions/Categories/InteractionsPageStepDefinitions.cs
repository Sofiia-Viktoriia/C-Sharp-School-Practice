using TechTalk.SpecFlow;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class InteractionsPageStepDefinitions
    {
        private readonly InteractionsPage _interactionsPage;

        public InteractionsPageStepDefinitions(InteractionsPage interactionsPage)
        {
            _interactionsPage = interactionsPage;
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
            _interactionsPage.VerifySelectedGridSquaresValues(expectedValues);
        }
    }
}
