namespace PracticeProject
{
    [TestFixture]
    internal class LoginRegistrationTest
    {
        private IWebDriver _webDriver;
        private LoginRegistrationPage _loginRegistrationPage;
        private LoginRegistrationPageFactory _loginRegistrationPageFactory;
        private const string Address = "https://practice.automationtesting.in/my-account/";

        [SetUp]
        public void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _loginRegistrationPage = new LoginRegistrationPage(_webDriver);
            _loginRegistrationPageFactory = new LoginRegistrationPageFactory(_webDriver);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(Address);
        }

        [Test]
        public void CheckLostPasswordLinkValue()
        {
            string expectedValue = "Lost your password?";
            Assert.That(_loginRegistrationPage.GetLostPasswordLinkValue(), Is.EqualTo(expectedValue),
                "The value of lost password link is not equal the expected one");
        }

        [Test]
        public void CheckLostPasswordLinkValueUsingPageFactory()
        {
            string expectedValue = "Lost your password?";
            Assert.That(_loginRegistrationPageFactory.LostPasswordLink.Text, Is.EqualTo(expectedValue),
                "The value of lost password link is not equal the expected one");
        }

        [Test]
        public void CheckRememberMeLabelValue()
        {
            string expectedValue = "Remember me";
            Assert.That(_loginRegistrationPage.GetRememberMeLabelValue(), Is.EqualTo(expectedValue),
                "The value of remember me label is not equal the expected one");
        }

        [Test]
        public void CheckRememberMeLabelValueUsingPageFactory()
        {
            string expectedValue = "Remember me";
            Assert.That(_loginRegistrationPageFactory.RememberMeLabel.Text, Is.EqualTo(expectedValue),
                "The value of remember me label is not equal the expected one");
        }

        [Test]
        public void CheckRegisterButtonValue()
        {
            string expectedValue = "Register";
            Assert.That(_loginRegistrationPage.GetRegisterButtonValue(), Is.EqualTo(expectedValue),
                "The value of register button is not equal the expected one");
        }

        [Test]
        public void CheckRegisterButtonValueUsingPageFactory()
        {
            string expectedValue = "Register";
            string actualValue = _loginRegistrationPageFactory.RegisterButton.GetAttribute("value");
            Assert.That(actualValue, Is.EqualTo(expectedValue),
                "The value of register button is not equal the expected one");
        }

        [Test]
        public void IsErrorMessageDisplayedAfterLoginWithInvalidEmail()
        {
            string email = "aksbd@jks.sd";
            string password = "12345";
            _loginRegistrationPage.Login(email, password);
            Assert.That(_loginRegistrationPage.IsErrorMessageDisplayed(), Is.True, "Error message is not displayed");
        }

        [Test]
        public void IsErrorMessageDisplayedAfterLoginWithInvalidEmailUsingPageFactory()
        {
            string email = "aksbd@jks.sd";
            string password = "12345";
            _loginRegistrationPageFactory.LoginFormUsernameOrEmailInput.SendKeys(email);
            _loginRegistrationPageFactory.LoginFormPasswordInput.SendKeys(password);
            _loginRegistrationPageFactory.LoginButton.Click();
            Assert.That(_loginRegistrationPageFactory.ErrorMessage.Displayed, Is.True, "Error message is not displayed");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Close();
        }
    }
}
