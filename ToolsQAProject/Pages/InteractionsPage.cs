using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages
{
    public class InteractionsPage : BasePage
    {
        private IWebElement TabByName(string tabName) => WebDriver.FindElement(By.XPath($"//nav[@role='tablist']//a[text()='{tabName}']"));
        private ReadOnlyCollection<IWebElement> GridSquares => WebDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(concat(' ', @class, ' '), ' list-group-item ')]"));
        private ReadOnlyCollection<IWebElement> SelectedGridSquares => WebDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(concat(' ', @class, ' '), ' list-group-item ') " +
            "and contains(concat(' ', @class, ' '), ' active ')]"));

        public InteractionsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void SwitchToTab(string tabName)
        {
            TabByName(tabName).Click();
        }

        public void SelectGridSquare(int number)
        {
            GridSquares[number - 1].ScrollToElement().Click();
        }

        public string[] GetSelectedGridSquaresValues()
        {
            return SelectedGridSquares.Select(square => square.Text).ToArray();
        }
    }
}
