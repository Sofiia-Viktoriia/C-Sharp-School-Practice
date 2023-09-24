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
        public void WhenUserSelectsSquares(int[] numbers)
        {
            foreach (int number in numbers)
            {
                _interactionsPage.SelectGridSquare(number);
            }
        }

        [Then(@"selected squares contain values")]
        public void ThenSelectedSquaresContainValues(string[] expectedValues)
        {
            _interactionsPage.VerifySelectedGridSquaresValues(expectedValues);
        }
    }
}
