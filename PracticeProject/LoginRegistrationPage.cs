namespace PageObjectProject
{
    public class LoginRegistrationPage
    {
        IWebDriver _webDriver;
        private IWebElement _formTitle(string title) => _webDriver.FindElement(By.XPath($"//h2[text()='{title}']"));
        private IWebElement _loginFormUsernameOrEmailInput => _webDriver.FindElement(By.XPath("//input[@id = 'username']"));
        private IWebElement _loginFormUsernameOrEmailLabel => _webDriver.FindElement(By.XPath("//label[@for='username']"));
        private IWebElement _loginFormPasswordInput => _webDriver.FindElement(By.XPath("//input[@id = 'password']"));
        private IWebElement _loginFormPasswordLabel => _webDriver.FindElement(By.XPath("//label[@for='password']"));
        private IWebElement _loginButton => _webDriver.FindElement(By.XPath("//input[@name = 'login']"));
        private IWebElement _rememberMeCheckbox => _webDriver.FindElement(By.XPath("//input[@id = 'rememberme']"));
        private IWebElement _rememberMeLabel => _webDriver.FindElement(By.XPath("//label[@for='rememberme']"));
        private IWebElement _lostPasswordLink => _webDriver.FindElement(By.XPath("//p[contains(concat(' ', @class, ' '), ' lost_password ')]/a"));
        private IWebElement _registerFormEmailInput => _webDriver.FindElement(By.XPath("//input[@id = 'reg_email']"));
        private IWebElement _registerFormEmailLabel => _webDriver.FindElement(By.XPath("//label[@for='reg_email']"));
        private IWebElement _registerFormPasswordInput => _webDriver.FindElement(By.XPath("//input[@id = 'reg_password']"));
        private IWebElement _registerFormPasswordLabel => _webDriver.FindElement(By.XPath("//label[@for='reg_password']"));
        private IWebElement _registerButton => _webDriver.FindElement(By.XPath("//input[@name = 'register']"));
        private IWebElement _errorMessage => _webDriver.FindElement(By.XPath("//li[./strong[text()='Error:']]"));

        public LoginRegistrationPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        public LoginRegistrationPage EnterEmailAndPasswordAndClickLoginButton(string email, string password)
        {
            _loginFormUsernameOrEmailInput.SendKeys(email);
            _loginFormPasswordInput.SendKeys(password);
            _loginButton.Click();
            return this;
        }

        public string GetLostPasswordLinkValue()
        {
            return _lostPasswordLink.Text;
        }

        public string GetRememberMeLabelValue()
        {
            return _rememberMeLabel.Text;
        }

        public string GetRegisterButtonValue()
        {
            return _registerButton.GetAttribute("value");
        }

        public bool IsErrorMessageDisplayed()
        {
            return _errorMessage.Displayed;
        }
    }
}
