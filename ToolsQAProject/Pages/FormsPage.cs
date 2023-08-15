using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Globalization;
using ToolsQAProject.Helpers;
using ToolsQAProject.StepDefinitions.Entities;

namespace ToolsQAProject.Pages
{
    public class FormsPage : BasePage
    {
        private const string FullNameModalLabel = "Student Name";
        private const string EmailModalLabel = "Student Email";
        private const string GenderModalLabel = "Gender";
        private const string MobilePhoneModalLabel = "Mobile";
        private const string DateOfBirthModalLabel = "Date of Birth";
        private const string SubjectsModalLabel = "Subjects";
        private const string HobbiesModalLabel = "Hobbies";
        private const string AddressModalLabel = "Address";
        private const string StateAndCityModalLabel = "State and City";
        private IWebElement FirstNameInput => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='firstName']"));
        private IWebElement LastNameInput => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='lastName']"));
        private IWebElement EmailInput => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='userEmail']"));
        private IWebElement GenderRadiobuttonByValue(string value) => WebDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[./input[@name='gender' and @value='{value}']]"));
        private IWebElement MobilePhoneInput => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='userNumber']"));
        private IWebElement DateOfBirthInput => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='dateOfBirthInput']"));
        private IWebElement DateOfBirthPickerYearDropdown => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@class='react-datepicker']//div[contains(concat(' ', @class, ' '), " +
            "' react-datepicker__year-dropdown-container ')]"));
        private IWebElement DateOfBirthPickerYearDropdownValueByText(string value) => WebDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@class='react-datepicker']" +
            $"//div[contains(concat(' ', @class, ' '), ' react-datepicker__year-dropdown-container ')]//option[text()='{value}']"));
        private IWebElement DateOfBirthPickerMonthDropdown => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@class='react-datepicker']//div[contains(concat(' ', @class, ' '), " +
            "' react-datepicker__month-dropdown-container ')]"));
        private IWebElement DateOfBirthPickerMonthDropdownValueByText(string value) => WebDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@class='react-datepicker']" +
            $"//div[contains(concat(' ', @class, ' '), ' react-datepicker__month-dropdown-container ')]//option[text()='{value}']"));
        private IWebElement DateOfBirthPickerDayByTextAndMonth(int day, string month) => WebDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@class='react-datepicker']//div[contains(concat(' ', @class, ' '), ' react-datepicker__day ') and text()='{day}' and contains(@aria-label, '{month}')]"));
        private IWebElement SubjectsInput => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//input[@id='subjectsInput']"));
        private IWebElement SubjectsSuggestionByValue(string value) => WebDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@id='subjectsContainer']//div[contains(concat(' ', @class, ' '), " +
            $"' subjects-auto-complete__option ') and text()='{value}']"));
        private IWebElement HobbiesCheckBoxByLabel(string label) => WebDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@id='hobbiesWrapper']//div[./label[text()='{label}']]"));
        private IWebElement CurrentAddressTextarea => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//textarea[@id='currentAddress']"));
        private IWebElement StateDropdown => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@id='state']"));
        private IWebElement StateSuggestionByValue(string value) => WebDriver.FindElement(By.XPath($"//div[@class='practice-form-wrapper']//div[@id='state']//div[contains(@class, 'option') and text()='{value}']"));
        private IWebElement CityDropdown => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//div[@id='city']//input"));
        private IWebElement SubmitButton => WebDriver.FindElement(By.XPath("//div[@class='practice-form-wrapper']//button[@id='submit']"));
        private ReadOnlyCollection<IWebElement> AdsIframe => WebDriver.FindElements(By.XPath("//div[@id='adplus-anchor']//iframe"));
        private IWebElement ModalTableValueByLabel (string label) => WebDriver.FindElement(By.XPath($"//div[@class='modal-content']/div[@class='modal-body']//td[text()='{label}']/following-sibling::td"));

        public FormsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void FillStudentRegistrationForm(StudentRegistrationForm form)
        {
            while (AdsIframe.Count > 0)
            {
                WebDriver.Navigate().Refresh();
            }

            FillFirstName(form.FirstName);
            FillLastName(form.LastName);
            FillEmail(form.Email);
            SelectGender(form.Gender);
            FillPhone(form.MobilePhone);
            FillDateOfBirth(form.DateOfBirth);
            AddSubjects(form.Subjects);
            SelectHobbies(form.Hobbies);
            FillCurrentAddress(form.CurrentAddress);
            SelectState(form.State);
            SelectCity(form.City);
        }

        public void FillFirstName(string firstName)
        {
            FirstNameInput.ScrollToElement().SendKeys(firstName);
        }

        public void FillLastName(string lastName)
        {
            LastNameInput.ScrollToElement().SendKeys(lastName);
        }

        public void FillEmail(string email)
        {
            EmailInput.ScrollToElement().SendKeys(email);
        }

        public void SelectGender(string value)
        {
            GenderRadiobuttonByValue(value).ScrollToElement().Click();
        }

        public void FillPhone(string phone)
        {
            MobilePhoneInput.ScrollToElement().SendKeys(phone);
        }

        public void FillDateOfBirth(string dateOfBirth)
        {
            var date = dateOfBirth.Split(" ");
            DateOfBirthInput.Click();
            SelectYearInDatePicker(date[2]);
            SelectMonthInDatePicker(date[1]);
            SelectDayInDatePicker(int.Parse(date[0]), date[1]);
        }

        public void SelectYearInDatePicker(string year)
        {
            DateOfBirthPickerYearDropdown.Click();
            DateOfBirthPickerYearDropdownValueByText(year).Click();
        }

        public void SelectMonthInDatePicker(string month)
        {
            DateOfBirthPickerMonthDropdown.Click();
            DateOfBirthPickerMonthDropdownValueByText(month).Click();
        }

        public void SelectDayInDatePicker(int day, string month)
        {
            DateOfBirthPickerDayByTextAndMonth(day, month).Click();
        }

        public void AddSubjects(List<string> subjects)
        {
            foreach (string subject in subjects)
            {
                SubjectsInput.ScrollToElement().SendKeys(subject);
                SubjectsSuggestionByValue(subject).Click();
            }
        }

        public void SelectHobbies(List<string> hobbies)
        {
            foreach (string hobby in hobbies)
            {
                HobbiesCheckBoxByLabel(hobby).ScrollToElement().Click();
            }
        }

        public void FillCurrentAddress(string  currentAddress)
        {
            CurrentAddressTextarea.ScrollToElement().SendKeys(currentAddress);
        }

        public void SelectState(string state)
        {
            StateDropdown.ScrollToElement().Click();
            StateSuggestionByValue(state).Click();
        }

        public void SelectCity(string city)
        {
            CityDropdown.ScrollToElement().SendKeys(city + Keys.Enter);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.ScriptClick();
        }

        public StudentRegistrationForm GetModalTableValues()
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

            return form;
        }
    }
}
