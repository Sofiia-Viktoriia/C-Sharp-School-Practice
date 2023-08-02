namespace SeleniumProject
{
    [TestFixture]
    internal class SeleniumWebDriverTest
    {
        public const string ThinkingInHTML = "Thinking in HTML";
        public const string HTML5WebAppDevelpment = "HTML5 WebApp Develpment";
        public const string HTML = "html";
        public const string Href = "href";
        public const string HTTPS = "https://";
        public const string ScrollToElementScript = "arguments[0].scrollIntoView({ block: \"center\" });";
        IWebDriver webDriver;
        IJavaScriptExecutor javaScriptExecutor;

        [SetUp]
        public void SetUp()
        {
            var chromeOptions = new ChromeOptions();
            webDriver = new ChromeDriver(chromeOptions);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");
            javaScriptExecutor = (IJavaScriptExecutor)webDriver;
        }

        [Test]
        public void SearchAndAddToBasketTest()
        {
            webDriver.FindElement(By.Id("s")).SendKeys(HTML + Keys.Enter);

            Assert.That(webDriver.Title, Does.Contain(HTML), "Search results page is not displayed");

            var productLinks = webDriver.FindElements(By.XPath(Locators.ProductLinks));
            foreach (var link in productLinks)
            {
                string href = link.GetAttribute(Href);
                Assert.That(href, Does.StartWith(HTTPS), "Product has invalid link");
                Assert.That(link.Text.ToLower(), Does.Contain(HTML), "Product title does not contain 'html'");
            }

            IWebElement thinkingInHtmlLink = webDriver.FindElement(By.LinkText(ThinkingInHTML));
            javaScriptExecutor.ExecuteScript(ScrollToElementScript, thinkingInHtmlLink);
            thinkingInHtmlLink.Click();
            CloseAds();

            IWebElement saleMark = webDriver.FindElement(By.CssSelector(Locators.OnSaleMark));
            IWebElement oldPrice = webDriver.FindElement(By.XPath(Locators.OldPrice));
            IWebElement newPrice = webDriver.FindElement(By.XPath(Locators.NewPrice));
            Assert.IsTrue(saleMark.Displayed, "SALE mark is not displayed");
            Assert.IsTrue(oldPrice.Displayed, "Old price is not displayed");
            Assert.IsTrue(newPrice.Displayed, "New price is not displayed");

            IWebElement html5WebAppLink = webDriver.FindElement(By.XPath(Locators.RelatedProductLink(HTML5WebAppDevelpment)));
            javaScriptExecutor.ExecuteScript(ScrollToElementScript, html5WebAppLink);
            html5WebAppLink.Click();
            CloseAds();
            string productTitle = webDriver.FindElement(By.CssSelector(Locators.ProductTitle)).Text;
            double productPrice = double.Parse(webDriver.FindElement(By.CssSelector(Locators.RegularPrice)).Text.Substring(1));
            webDriver.FindElement(By.XPath(Locators.AddToBasketButton)).Click();

            IWebElement quantityInput = webDriver.FindElement(By.XPath(Locators.ProductQuantityInput));
            quantityInput.Clear();
            quantityInput.SendKeys("2");
            webDriver.FindElement(By.XPath(Locators.AddToBasketButton)).Click();
            webDriver.FindElement(By.XPath(Locators.ViewBasketButton)).Click();

            IWebElement basketProductTitle = webDriver.FindElement(By.XPath(Locators.ProductName(ThinkingInHTML)));
            IWebElement basketProductPrice = webDriver.FindElement(By.XPath(Locators.TotalCost));
            Assert.That(basketProductTitle.Text, Is.EqualTo(productTitle), "Product name in the cart does not match");
            Assert.That(double.Parse(basketProductPrice.Text.Substring(1)), Is.EqualTo(productPrice * 3), "Product price in the cart does not match");
        }

        public void CloseAds()
        {
            if (webDriver.FindElements(By.Id("aswift_5")).Count > 0)
            {
                webDriver.SwitchTo().Frame("aswift_5");
                if (webDriver.FindElements(By.XPath(Locators.DismissButton)).Count > 0)
                {
                    webDriver.FindElement(By.XPath(Locators.DismissButton)).Click();
                }
                webDriver.SwitchTo().DefaultContent();
            }
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
        }
    }
}
