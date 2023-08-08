namespace PracticeProject
{
    [TestFixture]
    internal class SeleniumWebDriverTest
    {
        public const string URL = "https://practice.automationtesting.in/shop/";
        IWebDriver _webDriver;
        IJavaScriptExecutor _javaScriptExecutor;

        [SetUp]
        public void SetUp()
        {
            var chromeOptions = new ChromeOptions();
            _webDriver = new ChromeDriver(chromeOptions);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void SearchAndAddToBasketTest()
        {
            string thinkingInHTML = "Thinking in HTML";
            string html5WebAppDevelpment = "HTML5 WebApp Develpment";
            string html = "html";
            _javaScriptExecutor = (IJavaScriptExecutor)_webDriver;

            _webDriver.FindElement(By.Id(Locators.SearchInputId)).SendKeys(html + Keys.Enter);

            Assert.That(_webDriver.Title, Does.Contain(html), "Search results page is not displayed");
            string pageTitle = _webDriver.FindElement(By.XPath(Locators.PageTitle)).Text;
            Assert.That(pageTitle, Does.Contain(html).IgnoreCase, "Search results page title is not displayed");

            var productLinks = _webDriver.FindElements(By.XPath(Locators.ProductLinks));
            foreach (var link in productLinks)
            {
                string href = link.GetAttribute("href");
                Assert.Multiple(() =>
                {
                    Assert.That(href, Does.StartWith("https://"), "Product has invalid link");
                    Assert.That(link.Text, Does.Contain(html).IgnoreCase, "Product title does not contain 'html'");
                });
            }

            IWebElement thinkingInHtmlLink = _webDriver.FindElement(By.XPath(Locators.PostLinkByName(thinkingInHTML)));
            thinkingInHtmlLink.ScrollToElement(_javaScriptExecutor);
            thinkingInHtmlLink.Click();
            CloseAds();

            IWebElement saleMark = _webDriver.FindElement(By.CssSelector(Locators.OnSaleMark));
            IWebElement oldPrice = _webDriver.FindElement(By.XPath(Locators.OldPrice));
            IWebElement newPrice = _webDriver.FindElement(By.XPath(Locators.NewPrice));
            Assert.Multiple(() =>
            {
                Assert.That(saleMark.Displayed, Is.True, "SALE mark is not displayed");
                Assert.That(oldPrice.Displayed, Is.True, "Old price is not displayed");
                Assert.That(newPrice.Displayed, Is.True, "New price is not displayed");
            });

            IWebElement html5WebAppLink = _webDriver.FindElement(By.XPath(Locators.RelatedProductLinkByName(html5WebAppDevelpment)));
            html5WebAppLink.ScrollToElement(_javaScriptExecutor);
            html5WebAppLink.Click();
            CloseAds();
            string productTitle = _webDriver.FindElement(By.CssSelector(Locators.ProductTitle)).Text;
            double productPrice = double.Parse(_webDriver.FindElement(By.CssSelector(Locators.RegularPrice)).Text[1..]);
            _webDriver.FindElement(By.XPath(Locators.AddToBasketButton)).Click();

            IWebElement quantityInput = _webDriver.FindElement(By.XPath(Locators.ProductQuantityInput));
            quantityInput.Clear();
            quantityInput.SendKeys("2");
            _webDriver.FindElement(By.XPath(Locators.AddToBasketButton)).Click();
            _webDriver.FindElement(By.XPath(Locators.ViewBasketButton)).Click();

            IWebElement basketProductTitle = _webDriver.FindElement(By.XPath(Locators.ProductName(thinkingInHTML)));
            IWebElement basketProductPrice = _webDriver.FindElement(By.XPath(Locators.TotalCost));
            Assert.Multiple(() =>
            {
                Assert.That(basketProductTitle.Text, Is.EqualTo(productTitle), "Product name in the cart does not match");
                Assert.That(double.Parse(basketProductPrice.Text.Substring(1)), Is.EqualTo(productPrice * 3), "Product price in the cart does not match");
            });
        }

        public void CloseAds()
        {
            _webDriver.SwitchTo().Frame(Locators.FrameId);
            if (_webDriver.FindElements(By.XPath(Locators.DismissButton)).Count > 0)
            {
                _webDriver.FindElement(By.XPath(Locators.DismissButton)).Click();
            }
            _webDriver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
