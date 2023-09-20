using FluentAssertions;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using ToolsQAProject.Helpers;
using ToolsQAProject.StepDefinitions.Entities;

namespace ToolsQAProject.Pages
{
    public class FormsPage
    {
        private IWebDriver _webDriver;
        private const string FullNameModalLabel = "Student Name";
        private const string EmailModalLabel = "Student Email";
        private const string GenderModalLabel = "Gender";
        private const string MobilePhoneModalLabel = "Mobile";
        private const string DateOfBirthModalLabel = "Date of Birth";
        private const string SubjectsModalLabel = "Subjects";
        private const string HobbiesModalLabel = "Hobbies";
        private const string AddressModalLabel = "Address";
        private const string StateAndCityModalLabel = "State and City";
        private IWebElement FirstNameInput => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='firstName']"));
        private IWebElement LastNameInput => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='lastName']"));
        private IWebElement EmailInput => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='userEmail']"));
        private IWebElement GenderRadiobuttonByValue(string value) => _webDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[./input[@name='gender' and @value='{value}']]"));
        private IWebElement MobilePhoneInput => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='userNumber']"));
        private IWebElement DateOfBirthInput => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='dateOfBirthInput']"));
        private IWebElement DateOfBirthPickerYearDropdown => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@class='react-datepicker']//div[contains(concat(' ', @class, ' '), " +
            "' react-datepicker__year-dropdown-container ')]"));
        private IWebElement DateOfBirthPickerYearDropdownValueByText(string value) => _webDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@class='react-datepicker']" +
            $"//div[contains(concat(' ', @class, ' '), ' react-datepicker__year-dropdown-container ')]//option[text()='{value}']"));
        private IWebElement DateOfBirthPickerMonthDropdown => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@class='react-datepicker']//div[contains(concat(' ', @class, ' '), " +
            "' react-datepicker__month-dropdown-container ')]"));
        private IWebElement DateOfBirthPickerMonthDropdownValueByText(string value) => _webDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@class='react-datepicker']" +
            $"//div[contains(concat(' ', @class, ' '), ' react-datepicker__month-dropdown-container ')]//option[text()='{value}']"));
        private IWebElement DateOfBirthPickerDayByTextAndMonth(int day, string month) => _webDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@class='react-datepicker']//div[contains(concat(' ', @class, ' '), ' react-datepicker__day ') and text()='{day}' and contains(@aria-label, '{month}')]"));
        private IWebElement SubjectsInput => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='subjectsInput']"));
        private IWebElement SubjectsSuggestionByValue(string value) => _webDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@id='subjectsContainer']//div[contains(concat(' ', @class, ' '), " +
            $"' subjects-auto-complete__option ') and text()='{value}']"));
        private IWebElement HobbiesCheckBoxByLabel(string label) => _webDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@id='hobbiesWrapper']//div[./label[text()='{label}']]"));
        private IWebElement CurrentAddressTextarea => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//textarea[@id='currentAddress']"));
        private IWebElement StateDropdown => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@id='state']"));
        private IWebElement StateSuggestionByValue(string value) => _webDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@id='state']//div[contains(@class, 'option') and text()='{value}']"));
        private IWebElement CityDropdown => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@id='city']//input"));
        private IWebElement SubmitButton => _webDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//button[@id='submit']"));
        private ReadOnlyCollection<IWebElement> AdsIframe => _webDriver.FindElements(By.XPath("//div[@id='adplus-anchor']//iframe"));
        private IWebElement ModalTableValueByLabel(string label) => _webDriver.FindElement(By.XPath($"//div[@class='modal-content']/div[@class='modal-body']//td[text()='{label}']/following-sibling::td"));

        public FormsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public FormsPage FillStudentRegistrationForm(StudentRegistrationForm form)
        {
            while (AdsIframe.Count > 0)
            {
                _webDriver.Navigate().Refresh();
            }

            return FillFirstName(form.FirstName)
                .FillLastName(form.LastName)
                .FillEmail(form.Email)
                .SelectGender(form.Gender)
                .FillPhone(form.MobilePhone)
                .FillDateOfBirth(form.DateOfBirth)
                .AddSubjects(form.Subjects)
                .SelectHobbies(form.Hobbies)
                .FillCurrentAddress(form.CurrentAddress)
                .SelectState(form.State)
                .SelectCity(form.City);
        }

        public FormsPage FillFirstName(string firstName)
        {
            FirstNameInput.ScrollToElement().SendKeys(firstName);
            return this;
        }

        public FormsPage FillLastName(string lastName)
        {
            LastNameInput.ScrollToElement().SendKeys(lastName);
            return this;
        }

        public FormsPage FillEmail(string email)
        {
            EmailInput.ScrollToElement().SendKeys(email);
            return this;
        }

        public FormsPage SelectGender(string value)
        {
            GenderRadiobuttonByValue(value).ScrollToElement().Click();
            return this;
        }

        public FormsPage FillPhone(string phone)
        {
            MobilePhoneInput.ScrollToElement().SendKeys(phone);
            return this;
        }

        public FormsPage FillDateOfBirth(string dateOfBirth)
        {
            var date = dateOfBirth.Split(" ");
            DateOfBirthInput.Click();
            SelectYearInDatePicker(date[2]);
            SelectMonthInDatePicker(date[1]);
            SelectDayInDatePicker(int.Parse(date[0]), date[1]);
            return this;
        }

        public FormsPage SelectYearInDatePicker(string year)
        {
            DateOfBirthPickerYearDropdown.Click();
            DateOfBirthPickerYearDropdownValueByText(year).Click();
            return this;
        }

        public FormsPage SelectMonthInDatePicker(string month)
        {
            DateOfBirthPickerMonthDropdown.Click();
            DateOfBirthPickerMonthDropdownValueByText(month).Click();
            return this;
        }

        public FormsPage SelectDayInDatePicker(int day, string month)
        {
            DateOfBirthPickerDayByTextAndMonth(day, month).Click();
            return this;
        }

        public FormsPage AddSubjects(List<string> subjects)
        {
            foreach (string subject in subjects)
            {
                SubjectsInput.ScrollToElement().SendKeys(subject);
                SubjectsSuggestionByValue(subject).Click();
            }
            return this;
        }

        public FormsPage SelectHobbies(List<string> hobbies)
        {
            foreach (string hobby in hobbies)
            {
                HobbiesCheckBoxByLabel(hobby).ScrollToElement().Click();
            }
            return this;
        }

        public FormsPage FillCurrentAddress(string currentAddress)
        {
            CurrentAddressTextarea.ScrollToElement().SendKeys(currentAddress);
            return this;
        }

        public FormsPage SelectState(string state)
        {
            StateDropdown.ScrollToElement().Click();
            StateSuggestionByValue(state).Click();
            return this;
        }

        public FormsPage SelectCity(string city)
        {
            CityDropdown.ScrollToElement().SendKeys(city + Keys.Enter);
            return this;
        }

        public FormsPage ClickSubmitButton()
        {
            SubmitButton.ScriptClick();
            return this;
        }

        public FormsPage VerifyModalTableValues(StudentRegistrationForm expectedValues)
        {
            StudentRegistrationForm form = new StudentRegistrationForm();
            var fullName = ModalTableValueByLabel(FullNameModalLabel).Text.Split(" ");
            form.FirstName = fullName[0];
            form.LastName = fullName[1];
            form.Email = ModalTableValueByLabel(EmailModalLabel).Text;
            form.Gender = ModalTableValueByLabel(GenderModalLabel).Text;
            form.MobilePhone = ModalTableValueByLabel(MobilePhoneModalLabel).Text;
            form.DateOfBirth = ModalTableValueByLabel(DateOfBirthModalLabel).Text.Replace(',', ' ');
            form.Subjects = ModalTableValueByLabel(SubjectsModalLabel).Text.Split(", ").ToList();
            form.Hobbies = ModalTableValueByLabel(HobbiesModalLabel).Text.Split(", ").ToList();
            form.CurrentAddress = ModalTableValueByLabel(AddressModalLabel).Text;
            var stateAndCity = ModalTableValueByLabel(StateAndCityModalLabel).Text;
            var lastSpaceIndex = stateAndCity.LastIndexOf(' ');
            form.State = stateAndCity[..lastSpaceIndex];
            form.City = stateAndCity[(lastSpaceIndex + 1)..];

            form.Should().BeEquivalentTo(expectedValues);
            return this;
        }
    }
}
