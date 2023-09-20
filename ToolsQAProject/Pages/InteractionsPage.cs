using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages
{
    public class InteractionsPage
    {
        private IWebDriver _webDriver;
        private IWebElement TabByName(string tabName) => _webDriver.FindElement(By.XPath($"//nav[@role='tablist']//a[text()='{tabName}']"));
        private ReadOnlyCollection<IWebElement> GridSquares => _webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(concat(' ', @class, ' '), ' list-group-item ')]"));
        private ReadOnlyCollection<IWebElement> SelectedGridSquares => _webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(concat(' ', @class, ' '), ' list-group-item ') " +
            "and contains(concat(' ', @class, ' '), ' active ')]"));

        public InteractionsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public InteractionsPage SwitchToTab(string tabName)
        {
            TabByName(tabName).Click();
            return this;
        }

        public InteractionsPage SelectGridSquare(int number)
        {
            GridSquares[number - 1].ScrollToElement().Click();
            return this;
        }

        public InteractionsPage VerifySelectedGridSquaresValues(string[] expectedValues)
        {
            string[] actualValues = SelectedGridSquares.Select(square => square.Text).ToArray();
            Assert.That(actualValues.OrderBy(value => value).SequenceEqual(expectedValues.OrderBy(value => value)), Is.True,
                "Selected grid squares do not contain expected values");
            return this;
        }
    }
}
