﻿using NUnit.Framework;
using OpenQA.Selenium;
using ToolsQAProject.Constants;
using ToolsQAProject.Entities;
using ToolsQAProject.Helpers.Comparers;
using ToolsQAProject.Helpers.Extensions;
using ToolsQAProject.Pages.Common;

namespace ToolsQAProject.Pages.ElementsPage
{
    public class TextBoxSection : BasePage<TextBoxSection>
    {
        private readonly IWebDriver _webDriver;
        private IWebElement UserFormFullNameInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//input[@id='userName']"));
        private IWebElement UserFormEmailInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//input[@id='userEmail']"));
        private IWebElement UserFormCurrentAddressInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//textarea[@id='currentAddress']"));
        private IWebElement UserFormPermanentAddressInput => _webDriver.FindElement(By.XPath("//form[@id='userForm']//textarea[@id='permanentAddress']"));
        private IWebElement UserFormSubmitButton => _webDriver.FindElement(By.XPath("//form[@id='userForm']//button[@id='submit']"));
        private IWebElement UserFormOutputName => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='name']"));
        private IWebElement UserFormOutputEmail => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='email']"));
        private IWebElement UserFormOutputCurrentAddress => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='currentAddress']"));
        private IWebElement UserFormOutputPermanentAddress => _webDriver.FindElement(By.XPath("//div[@id='output']//p[@id='permanentAddress']"));

        public TextBoxSection(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public TextBoxSection FillFullName(string fullName)
        {
            UserFormFullNameInput.SendKeys(fullName);
            return this;
        }

        public TextBoxSection FillEmail(string email)
        {
            UserFormEmailInput.SendKeys(email);
            return this;
        }

        public TextBoxSection FillCurrentAddress(string currentAddress)
        {
            UserFormCurrentAddressInput.SendKeys(currentAddress);
            return this;
        }

        public TextBoxSection FillPermanentAddress(string permanentAddress)
        {
            UserFormPermanentAddressInput.SendKeys(permanentAddress);
            return this;
        }

        public TextBoxSection SubmitUserForm()
        {
            UserFormSubmitButton.ScrollToElement().Click();
            return this;
        }

        public TextBoxSection VerifyOutputTableValues(UserForm result)
        {
            UserForm userForm = new UserForm
            {
                FullName = UserFormOutputName.Text.TextAfter(Labels.UserFormOutputNameMeta),
                Email = UserFormOutputEmail.Text.TextAfter(Labels.UserFormOutputEmailMeta),
                CurrentAddress = UserFormOutputCurrentAddress.Text.TextAfter(Labels.UserFormOutputCurrentAddressMeta),
                PermanentAddress = UserFormOutputPermanentAddress.Text.TextAfter(Labels.UserFormOutputPermanentAddressMeta)
            };

            Assert.That(result, Is.EqualTo(userForm).Using(new UserFormComparer()));
            return this;
        }
    }
}
