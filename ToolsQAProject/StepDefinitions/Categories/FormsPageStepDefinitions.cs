using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ToolsQAProject.Pages;
using ToolsQAProject.StepDefinitions.Entities;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class FormsPageStepDefinitions
    {
        private FormsPage _formsPage;
        private StudentRegistrationForm _studentRegistrationForm;

        public FormsPageStepDefinitions(IWebDriver webDriver, StudentRegistrationForm form)
        {
            _formsPage = new FormsPage(webDriver);
            _studentRegistrationForm = form;
        }

        [When(@"user fills the form with values")]
        public void WhenUserFillsTheFormWithValues(Table table)
        {
            _studentRegistrationForm = new StudentRegistrationForm
            {
                FirstName = table.Rows[0]["FirstName"],
                LastName = table.Rows[0]["LastName"],
                Email = table.Rows[0]["Email"],
                Gender = table.Rows[0]["Gender"],
                MobilePhone = table.Rows[0]["MobilePhone"],
                DateOfBirth = table.Rows[0]["DateOfBirth"],
                Subjects = table.Rows[0]["Subjects"].Split("; ").ToList(),
                Hobbies = table.Rows[0]["Hobbies"].Split("; ").ToList(),
                CurrentAddress = table.Rows[0]["CurrentAddress"],
                State = table.Rows[0]["State"],
                City = table.Rows[0]["City"]
            };
            _formsPage.FillStudentRegistrationForm(_studentRegistrationForm);
        }

        [When(@"user submits the form")]
        public void WhenUserSubmitsTheForm()
        {
            _formsPage.ClickSubmitButton();
        }

        [Then(@"modal page with entered values is displayed")]
        public void ThenModalPageWithEnteredValuesIsDisplayed()
        {
            var actualForm = _formsPage.GetModalTableValues();
            actualForm.Should().BeEquivalentTo(_studentRegistrationForm);
        }
    }
}
