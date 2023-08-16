namespace PracticeProject
{
    public class LoginRegistrationPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement FormTitleByText(string title) => _webDriver.FindElement(By.XPath($"//h2[text()='{title}']"));
        private IWebElement LoginFormUsernameOrEmailInput => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//input[@id = 'username']"));
        private IWebElement LoginFormUsernameOrEmailLabel => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//label[@for='username']"));
        private IWebElement LoginFormPasswordInput => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//input[@id = 'password']"));
        private IWebElement LoginFormPasswordLabel => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//label[@for='password']"));
        private IWebElement LoginButton => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//input[@name = 'login']"));
        private IWebElement RememberMeCheckbox => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//input[@id = 'rememberme']"));
        private IWebElement RememberMeLabel => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//label[@for='rememberme']"));
        private IWebElement LostPasswordLink => _webDriver.FindElement(By.XPath("//div[@class='u-column1 col-1']//p[contains(concat(' ', @class, ' '), ' lost_password ')]/a"));
        private IWebElement RegisterFormEmailInput => _webDriver.FindElement(By.XPath("//div[@class='u-column2 col-2']//input[@id = 'reg_email']"));
        private IWebElement RegisterFormEmailLabel => _webDriver.FindElement(By.XPath("//div[@class='u-column2 col-2']//label[@for='reg_email']"));
        private IWebElement RegisterFormPasswordInput => _webDriver.FindElement(By.XPath("//div[@class='u-column2 col-2']//input[@id = 'reg_password']"));
        private IWebElement RegisterFormPasswordLabel => _webDriver.FindElement(By.XPath("//div[@class='u-column2 col-2']//label[@for='reg_password']"));
        private IWebElement RegisterButton => _webDriver.FindElement(By.XPath("//div[@class='u-column2 col-2']//input[@name = 'register']"));
        private IWebElement ErrorMessage => _webDriver.FindElement(By.XPath("//ul[@class='woocommerce-error']/li[./strong[text()='Error:']]"));

        public LoginRegistrationPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public LoginRegistrationPage Login(string email, string password)
        {
            LoginFormUsernameOrEmailInput.SendKeys(email);
            LoginFormPasswordInput.SendKeys(password);
            LoginButton.Click();
            return this;
        }

        public string GetLostPasswordLinkValue()
        {
            return LostPasswordLink.Text;
        }

        public string GetRememberMeLabelValue()
        {
            return RememberMeLabel.Text;
        }

        public string GetRegisterButtonValue()
        {
            return RegisterButton.GetAttribute("value");
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                return ErrorMessage.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
