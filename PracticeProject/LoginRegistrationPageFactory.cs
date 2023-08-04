using SeleniumExtras.PageObjects;

namespace PracticeProject
{
    public class LoginRegistrationPageFactory
    {
        private IWebDriver _webDriver;

        public LoginRegistrationPageFactory(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(_webDriver, this);
        }

        public IWebElement FormTitle(string title) => _webDriver.FindElement(By.XPath($"//h2[text()='{title}']"));

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//input[@id = 'username']")]
        public IWebElement LoginFormUsernameOrEmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//label[@for='username']")]
        public IWebElement LoginFormUsernameOrEmailLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//input[@id = 'password']")]
        public IWebElement LoginFormPasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//label[@for='password']")]
        public IWebElement LoginFormPasswordLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//input[@name = 'login']")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//input[@id = 'rememberme']")]
        public IWebElement RememberMeCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//label[@for='rememberme']")]
        public IWebElement RememberMeLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column1 col-1']//p[contains(concat(' ', @class, ' '), ' lost_password ')]/a")]
        public IWebElement LostPasswordLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column2 col-2']//input[@id = 'reg_email']")]
        public IWebElement RegisterFormEmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column2 col-2']//label[@for='reg_email']")]
        public IWebElement RegisterFormEmailLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column2 col-2']//input[@id = 'reg_password']")]
        public IWebElement RegisterFormPasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column2 col-2']//label[@for='reg_password']")]
        public IWebElement RegisterFormPasswordLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='u-column2 col-2']//input[@name = 'register']")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='woocommerce-error']//li[./strong[text()='Error:']]")]
        public IWebElement ErrorMessage { get; set; }
    }
}
