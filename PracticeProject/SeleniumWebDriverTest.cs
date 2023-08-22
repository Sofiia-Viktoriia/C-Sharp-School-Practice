namespace PracticeProject
{
    [TestFixture]
    internal class SeleniumWebDriverTest
    {
        public const string URL = "https://practice.automationtesting.in/shop/";
        IWebDriver _webDriver;

        [SetUp]
        public void SetUp()
        {
            var chromeOptions = new ChromeOptions();
            _webDriver = new ChromeDriver(chromeOptions);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void SearchAndAddToBasketTest()
        {
            string thinkingInHTML = "Thinking in HTML";
            string html5WebAppDevelpment = "HTML5 WebApp Develpment";
            string html = "html";

            _webDriver.FindElement(By.Id(Locators.SearchInputId)).SendKeys(html + Keys.Enter);

            Assert.Multiple(() =>
            {
                Assert.That(_webDriver.Title, Does.Contain(html), $"Page title does not contain {html}");
                string pageName = _webDriver.FindElement(By.XPath(Locators.PageName)).Text;
                Assert.That(pageName, Does.Contain(html).IgnoreCase, $"Page name does not contain {html}");
            });

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
            thinkingInHtmlLink.ScrollToElement().Click();
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
            html5WebAppLink.ScrollToElement().Click();
            CloseAds();
            string productTitle = _webDriver.FindElement(By.CssSelector(Locators.ProductTitle)).Text;
            double productPrice = double.Parse(_webDriver.FindElement(By.CssSelector(Locators.RegularPrice)).Text[1..]);
            _webDriver.FindElement(By.XPath(Locators.AddToBasketButton)).Click();

            IWebElement quantityInput = _webDriver.FindElement(By.XPath(Locators.ProductQuantityInput));
            quantityInput.ScrollToElement().Clear();
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

        private void CloseAds()
        {
            if (IsElementVisible(By.XPath(Locators.AdsFrame), out IWebElement? frame))
            {
                _webDriver.SwitchTo().Frame(frame);
                if (!IsElementVisible(By.XPath(Locators.DismissButton), out IWebElement? element) &&
                    IsElementVisible(By.XPath(Locators.InnerFrame), out IWebElement? innerFrame))
                {
                    _webDriver.SwitchTo().Frame(innerFrame);
                    _webDriver.FindElement(By.XPath(Locators.DismissButton)).Click();
                    _webDriver.SwitchTo().DefaultContent();
                    return;
                }
                element.Click();
                _webDriver.SwitchTo().DefaultContent();
            }
        }

        private bool IsElementVisible(By locator, out IWebElement? element)
        {
            try
            {
                element = _webDriver.FindElement(locator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                element = null;
                return false;
            }
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
