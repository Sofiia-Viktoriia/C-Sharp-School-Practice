using TechTalk.SpecFlow;
using ToolsQAProject.Entities;
using ToolsQAProject.Pages;

namespace ToolsQAProject.StepDefinitions.Categories
{
    [Binding]
    public class FormsPageStepDefinitions
    {
        private readonly FormsPage _formsPage;
        private StudentRegistrationForm _studentRegistrationForm;

        public FormsPageStepDefinitions(FormsPage formsPage, StudentRegistrationForm form)
        {
            _formsPage = formsPage;
            _studentRegistrationForm = form;
        }

        [When(@"user submits the form with values")]
        public void WhenUserSubmitsTheFormWithValues(StudentRegistrationForm form)
        {
            _studentRegistrationForm = form;
            _formsPage.FillStudentRegistrationForm(_studentRegistrationForm)
                .ClickSubmitButton();
        }

        [Then(@"the sent form overview is populated with entered values")]
        public void ThenTheSentFormOverviewIsPopulatedWithEnteredValues()
        {
            _formsPage.VerifyModalTableValues(_studentRegistrationForm);
        }
    }
}
