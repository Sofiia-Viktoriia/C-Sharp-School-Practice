﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers;
using ToolsQAProject.StepDefinitions.Entities;

namespace ToolsQAProject.Pages
{
    internal class ElementsPage
    {
        private IWebDriver _webDriver;
        private const string _userFormOutputNameMeta = "Name:";
        private const string _userFormOutputEmailMeta = "Email:";
        private const string _userFormOutputCurrentAddressMeta = "Current Address :";
        private const string _userFormOutputPermanentAddressMeta = "Permananet Address :";
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

        public void FillUserForm(UserForm userForm)
        {
            UserFormFullNameInput.SendKeys(userForm.FullName);
            UserFormEmailInput.SendKeys(userForm.Email);
            UserFormCurrentAddressInput.SendKeys(userForm.CurrentAddress);
            UserFormPermanentAddressInput.SendKeys(userForm.PermanentAddress);
        }

        public void SubmitUserForm()
        {
            UserFormSubmitButton.ScrollToElement().Click();
        }

        public string GetUserFormOutputName()
        {
            return UserFormOutputName.Text.TextAfter(_userFormOutputNameMeta);
        }

        public string GetUserFormOutputEmail()
        {
            return UserFormOutputEmail.Text.TextAfter(_userFormOutputEmailMeta);
        }

        public string GetUserFormOutputCurrentAddress()
        {
            return UserFormOutputCurrentAddress.Text.TextAfter(_userFormOutputCurrentAddressMeta);
        }

        public string GetUserFormOutputPermanentAddress()
        {
            return UserFormOutputPermanentAddress.Text.TextAfter(_userFormOutputPermanentAddressMeta);
        }

        public void SelectElement(string elementName)
        {
            ElementLabelByName(elementName).Click();
        }

        public void ExpandFolder(string folderName)
        {
            ElementButtonByName(folderName).Click();
        }

        public void SelectElementsInFolder(string folderName)
        {
            foreach (IWebElement element in ElementsInFolderByName(folderName))
            {
                element.ScrollToElement().Click();
            }
        }

        public string GetSelectionResult()
        {
            return SelectionResult.Text;
        }

        public int GetAmountOfRowsInTable()
        {
            return TableRows.Count;
        }

        public void ClickOnColumnName(string columnName)
        {
            TableColumnByName(columnName).Click();
        }

        public List<string> GetColumnValues(string columnName)
        {
            return ColumnValuesByName(columnName).Select(element => element.Text).ToList();
        }

        public void ClickOnRowDeleteButton(string columnName, string columnValue)
        {
            TableRowDeleteButtonByColumnNameAndValue(columnName, columnValue).Click();
        }

        public bool IfColumnContainsValue(string columnName, string columnValue)
        {
            return ColumnValuesByName(columnName).Select(element => element.Text).Contains(columnValue);
        }

        public void ClickOnButton(string buttonName)
        {
            ButtonByName(buttonName).ScrollToElement().Click();
        }

        public void DoubleClickOnButton(string buttonName)
        {
            new Actions(_webDriver).MoveToElement(ButtonByName(buttonName))
                .Click(ButtonByName(buttonName)).Click(ButtonByName(buttonName)).Build().Perform();
        }

        public void RightClickOnButton(string buttonName)
        {
            new Actions(_webDriver).MoveToElement(ButtonByName(buttonName)).ContextClick(ButtonByName(buttonName)).Build().Perform();
        }

        public bool IfClickingResultDisplayed(string resultText)
        {
            return ClickingResultByText(resultText).Displayed;
        }
    }
}
