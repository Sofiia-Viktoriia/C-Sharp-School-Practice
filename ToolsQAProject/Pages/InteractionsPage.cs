using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers.Extensions;
using ToolsQAProject.Pages.Common;

namespace ToolsQAProject.Pages
{
    public class InteractionsPage : BasePage<InteractionsPage>
    {
        private readonly IWebDriver _webDriver;
        private IWebElement TabByName(string tabName) => _webDriver.FindElement(By.XPath($"//nav[@role='tablist']//a[text()='{tabName}']"));
        private ReadOnlyCollection<IWebElement> GridSquares => _webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(concat(' ', @class, ' '), ' list-group-item ')]"));
        private ReadOnlyCollection<IWebElement> SelectedGridSquares => _webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(concat(' ', @class, ' '), ' list-group-item ') " +
            "and contains(concat(' ', @class, ' '), ' active ')]"));

        public InteractionsPage(IWebDriver webDriver) : base(webDriver)
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
            IEnumerable<string> actualValues = SelectedGridSquares.Select(square => square.Text);
            Assert.That(expectedValues, Is.EqualTo(actualValues), "Selected grid squares do not contain expected values");
            return this;
        }
    }
}
