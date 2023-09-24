using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Constants;
using ToolsQAProject.Helpers.Extensions;

namespace ToolsQAProject.Pages.ElementsPage
{
    public class CheckBoxSection
    {
        private readonly IWebDriver _webDriver;
        private IWebElement ElementByName(string elementName) => _webDriver.FindElement(By.XPath($"//div[@id='tree-node']//span[@class='rct-text' and .//span[text()='{elementName}']]"));
        private IWebElement ElementCheckboxByName(string elementName) => ElementByName(elementName).FindElement(By.XPath($".//span[@class='rct-checkbox']/*[local-name() = 'svg']"));
        private IWebElement ElementButtonByName(string elementName) => ElementByName(elementName).FindElement(By.XPath($"./button"));
        private ReadOnlyCollection<IWebElement> ElementsCheckboxesInFolderByName(string folderName) => _webDriver.FindElements(By.XPath("//div[@id='tree-node']" +
            $"//li[./span[@class='rct-text' and .//span[text()='{folderName}']]]//li//span[@class='rct-checkbox']/*[local-name() = 'svg']"));
        private IWebElement SelectionResult => _webDriver.FindElement(By.XPath("//div[@class='check-box-tree-wrapper']/div[@id='result']"));

        public CheckBoxSection(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CheckBoxSection SelectElement(string elementName)
        {
            var checkbox = ElementCheckboxByName(elementName);
            if(checkbox.GetAttribute(Attributes.Class).Contains(AttributeValues.UncheckedCheckbox))
            {
                checkbox.Click();
            }
            return this;
        }

        public CheckBoxSection ExpandFolder(string folderName)
        {
            ElementButtonByName(folderName).Click();
            return this;
        }

        public CheckBoxSection SelectAllElementsInFolder(string folderName)
        {
            foreach (IWebElement checkbox in ElementsCheckboxesInFolderByName(folderName))
            {
                if (checkbox.GetAttribute(Attributes.Class).Contains(AttributeValues.UncheckedCheckbox))
                {
                    checkbox.ScrollToElement().Click();
                }
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
