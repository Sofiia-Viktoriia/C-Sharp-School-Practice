using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers;

namespace ToolsQAProject.Pages.ElementsPage
{
    public class CheckBoxSection
    {
        private IWebDriver _webDriver;
        private IWebElement ElementLabelByName(string elementName) => _webDriver.FindElement(By.XPath($"//div[@id='tree-node']//label/span[text()='{elementName}']"));
        private IWebElement ElementButtonByName(string elementName) => _webDriver.FindElement(By.XPath("//div[@id='tree-node']//span[@class='rct-text' " +
            $"and .//span[text()='{elementName}']]/button"));
        private ReadOnlyCollection<IWebElement> ElementsInFolderByName(string folderName) => _webDriver.FindElements(By.XPath("//div[@id='tree-node']" +
            $"//li[./span[@class='rct-text' and .//span[text()='{folderName}']]]//li//label"));
        private IWebElement SelectionResult => _webDriver.FindElement(By.XPath("//div[@class='check-box-tree-wrapper']/div[@id='result']"));

        public CheckBoxSection(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CheckBoxSection SelectElement(string elementName)
        {
            ElementLabelByName(elementName).Click();
            return this;
        }

        public CheckBoxSection ExpandFolder(string folderName)
        {
            ElementButtonByName(folderName).Click();
            return this;
        }

        public CheckBoxSection SelectElementsInFolder(string folderName)
        {
            foreach (IWebElement element in ElementsInFolderByName(folderName))
            {
                element.ScrollToElement().Click();
            }
            return this;
        }

        public CheckBoxSection VerifySelectionResult(string expectedResult)
        {
            Assert.That(SelectionResult.Text.Replace("\r\n", " "), Is.EqualTo(expectedResult), $"The selection result does not equal to {expectedResult}");
            return this;
        }
    }
}
