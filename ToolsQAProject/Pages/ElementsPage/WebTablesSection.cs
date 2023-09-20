﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ToolsQAProject.Pages.ElementsPage
{
    public class WebTablesSection
    {
        private IWebDriver _webDriver;
        private IWebElement TableColumnByName(string colunmName) => _webDriver.FindElement(By.XPath($"//div[@class='rt-table']//div[@role='columnheader' and ./div[text()='{colunmName}']]"));
        private ReadOnlyCollection<IWebElement> TableRows => _webDriver.FindElements(By.XPath("//div[@class='rt-table']//div[@role='row' and .//div[@class='action-buttons']]"));
        private ReadOnlyCollection<IWebElement> ColumnValuesByName(string columnName) => _webDriver.FindElements(By.XPath("//div[@class='rt-table']//div[@role='row' and .//div[@class='action-buttons']]" +
            $"/div[count(//div[@class='rt-table']//div[@role='columnheader' and ./div[text()='{columnName}']]/preceding-sibling::div) + 1]"));
        private IWebElement TableRowDeleteButtonByColumnNameAndValue(string columnName, string columnValue) => _webDriver.FindElement(By.XPath("//div[@class='rt-table']//div[@role='row' and " +
            $"./div[count(//div[@class='rt-table']//div[@role='columnheader' and ./div[text()='{columnName}']]/preceding-sibling::div) + 1][text()='{columnValue}']]//div[@class='action-buttons']/span[@title='Delete']"));

        public WebTablesSection(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public int GetAmountOfRowsInTable()
        {
            return TableRows.Count;
        }

        public WebTablesSection VerifyAmountOfRowsInTable(int expectedAmount)
        {
            Assert.That(GetAmountOfRowsInTable(), Is.EqualTo(expectedAmount), $"The amount of table rows does not equal to {expectedAmount}");
            return this;
        }

        public WebTablesSection ClickOnColumnName(string columnName)
        {
            TableColumnByName(columnName).Click();
            return this;
        }

        public WebTablesSection VerifyColumnValuesSortedAscending(string columnName)
        {
            List<string> values = ColumnValuesByName(columnName).Select(element => element.Text).ToList();
            Assert.That(values.OrderBy(el => int.Parse(el)).SequenceEqual(values), Is.True, $"The {columnName} column values are not sorted ascending");
            return this;
        }

        public WebTablesSection ClickOnRowDeleteButton(string columnName, string columnValue)
        {
            TableRowDeleteButtonByColumnNameAndValue(columnName, columnValue).Click();
            return this;
        }

        public WebTablesSection VerifyColumnDoesNotContainValue(string columnName, string columnValue)
        {
            Assert.That(ColumnValuesByName(columnName).Select(element => element.Text).Contains(columnValue), Is.False, $"The row with the {columnName} value {columnValue} exists");
            return this;
        }
    }
}
