﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToolsQAProject.Constants;
using ToolsQAProject.Helpers;
using ToolsQAProject.StepDefinitions.Entities;

namespace ToolsQAProject.Pages
{
    public class ElementsPage
    {
        private IWebDriver _webDriver;
        private IWebElement UserFormFullNameInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//input[@id='userName']"));
        private IWebElement UserFormEmailInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//input[@id='userEmail']"));
        private IWebElement UserFormCurrentAddressInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//textarea[@id='currentAddress']"));
        private IWebElement UserFormPermanentAddressInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//textarea[@id='permanentAddress']"));
        private IWebElement UserFormSubmitButton => _webDriver.FindElement(By.XPath("//form[@id='userForm']//button[@id='submit']"));
        private IWebElement UserFormOutputName => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='name']"));
        private IWebElement UserFormOutputEmail => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='email']"));
        private IWebElement UserFormOutputCurrentAddress => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='currentAddress']"));
        private IWebElement UserFormOutputPermanentAddress => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='permanentAddress']"));
        private IWebElement ElementLabelByName(string elementName) => _webDriver.FindElement(By.XPath($"//div[@id='tree-node']//label/span[text()='{elementName}']"));
        private IWebElement ElementButtonByName(string elementName) => _webDriver.FindElement(By.XPath("//div[@id='tree-node']//span[@class='rct-text' " +
            $"and .//span[text()='{elementName}']]/button"));
        private ReadOnlyCollection<IWebElement> ElementsInFolderByName(string folderName) => _webDriver.FindElements(By.XPath("//div[@id='tree-node']" +
            $"//li[./span[@class='rct-text' and .//span[text()='{folderName}']]]//li//label"));
        private IWebElement SelectionResult => _webDriver.FindElement(By.XPath("//div[@class='check-box-tree-wrapper']/div[@id='result']"));
        private IWebElement TableColumnByName(string colunmName) => _webDriver.FindElement(By.XPath($"//div[@class='rt-table']//div[@role='columnheader' and ./div[text()='{colunmName}']]"));
        private ReadOnlyCollection<IWebElement> TableRows => _webDriver.FindElements(By.XPath("//div[@class='rt-table']//div[@role='row' and .//div[@class='action-buttons']]"));
        private ReadOnlyCollection<IWebElement> ColumnValuesByName(string columnName) => _webDriver.FindElements(By.XPath("//div[@class='rt-table']//div[@role='row' and .//div[@class='action-buttons']]" +
            $"/div[count(//div[@class='rt-table']//div[@role='columnheader' and ./div[text()='{columnName}']]/preceding-sibling::div) + 1]"));
        private IWebElement TableRowDeleteButtonByColumnNameAndValue(string columnName, string columnValue) => _webDriver.FindElement(By.XPath("//div[@class='rt-table']//div[@role='row' and " +
            $"./div[count(//div[@class='rt-table']//div[@role='columnheader' and ./div[text()='{columnName}']]/preceding-sibling::div) + 1][text()='{columnValue}']]//div[@class='action-buttons']/span[@title='Delete']"));
        private IWebElement ButtonByName(string buttonName) => _webDriver.FindElement(By.XPath($"//div/button[text()='{buttonName}']"));
        private IWebElement ClickingResultByText(string resultText) => _webDriver.FindElement(By.XPath($"//p[text()='{resultText}']"));

        public ElementsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ElementsPage FillFullName(string fullName)
        {
            UserFormFullNameInput.SendKeys(fullName);
            return this;
        }

        public ElementsPage FillEmail(string email)
        {
            UserFormEmailInput.SendKeys(email);
            return this;
        }

        public ElementsPage FillCurrentAddress(string currentAddress)
        {
            UserFormCurrentAddressInput.SendKeys(currentAddress);
            return this;
        }

        public ElementsPage FillPermanentAddress(string permanentAddress)
        {
            UserFormPermanentAddressInput.SendKeys(permanentAddress);
            return this;
        }

        public ElementsPage SubmitUserForm()
        {
            UserFormSubmitButton.ScrollToElement().Click();
            return this;
        }

        public ElementsPage VerifyOutputTableValues(Table table)
        {
            UserForm userForm = new UserForm
            {
                FullName = UserFormOutputName.Text.TextAfter(Labels.UserFormOutputNameMeta),
                Email = UserFormOutputEmail.Text.TextAfter(Labels.UserFormOutputEmailMeta),
                CurrentAddress = UserFormOutputCurrentAddress.Text.TextAfter(Labels.UserFormOutputCurrentAddressMeta),
                PermanentAddress = UserFormOutputPermanentAddress.Text.TextAfter(Labels.UserFormOutputPermanentAddressMeta)
            };

            table.CompareToInstance(userForm);
            return this;
        }

        public ElementsPage SelectElement(string elementName)
        {
            ElementLabelByName(elementName).Click();
            return this;
        }

        public ElementsPage ExpandFolder(string folderName)
        {
            ElementButtonByName(folderName).Click();
            return this;
        }

        public ElementsPage SelectElementsInFolder(string folderName)
        {
            foreach (IWebElement element in ElementsInFolderByName(folderName))
            {
                element.ScrollToElement().Click();
            }
            return this;
        }

        public ElementsPage VerifySelectionResult(string expectedResult)
        {
            Assert.That(SelectionResult.Text.Replace("\r\n", " "), Is.EqualTo(expectedResult), $"The selection result does not equal to {expectedResult}");
            return this;
        }

        public int GetAmountOfRowsInTable()
        {
            return TableRows.Count;
        }

        public ElementsPage VerifyAmountOfRowsInTable(int expectedAmount)
        {
            Assert.That(GetAmountOfRowsInTable(), Is.EqualTo(expectedAmount), $"The amount of table rows does not equal to {expectedAmount}");
            return this;
        }

        public ElementsPage ClickOnColumnName(string columnName)
        {
            TableColumnByName(columnName).Click();
            return this;
        }

        public ElementsPage VerifyColumnValuesSortedAscending(string columnName)
        {
            List<string> values = ColumnValuesByName(columnName).Select(element => element.Text).ToList();
            Assert.That(values.OrderBy(el => int.Parse(el)).SequenceEqual(values), Is.True, $"The {columnName} column values are not sorted ascending");
            return this;
        }

        public ElementsPage ClickOnRowDeleteButton(string columnName, string columnValue)
        {
            TableRowDeleteButtonByColumnNameAndValue(columnName, columnValue).Click();
            return this;
        }

        public ElementsPage VerifyColumnDoesNotContainValue(string columnName, string columnValue)
        {
            Assert.That(ColumnValuesByName(columnName).Select(element => element.Text).Contains(columnValue), Is.False, $"The row with the {columnName} value {columnValue} exists");
            return this;
        }

        public ElementsPage ClickOnButton(string buttonName)
        {
            ButtonByName(buttonName).ScrollToElement().Click();
            return this;
        }

        public ElementsPage DoubleClickOnButton(string buttonName)
        {
            new Actions(_webDriver).MoveToElement(ButtonByName(buttonName))
                .Click(ButtonByName(buttonName)).Click(ButtonByName(buttonName)).Build().Perform();
            return this;
        }

        public ElementsPage RightClickOnButton(string buttonName)
        {
            new Actions(_webDriver).MoveToElement(ButtonByName(buttonName)).ContextClick(ButtonByName(buttonName)).Build().Perform();
            return this;
        }

        public ElementsPage VerifyClickingResultIsDisplayed(string resultText)
        {
            Assert.That(ClickingResultByText(resultText).Displayed, Is.True, "The clicking result is not displayed");
            return this;
        }
    }
}
