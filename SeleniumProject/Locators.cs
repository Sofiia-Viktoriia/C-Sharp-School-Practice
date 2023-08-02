namespace SeleniumProject
{
    public class Locators
    {
        //Search page
        public const string ProductLinks = "//h2/a";

        //Product page
        public const string ProductTitle = ".product_title";
        public const string OnSaleMark = "span.onsale";
        public const string OldPrice = "//del/span";
        public const string NewPrice = "//ins/span";
        public const string RegularPrice = "p.price > span";
        public const string AddToBasketButton = "//button[text()='Add to basket']";
        public const string ProductQuantityInput = "//input[@name='quantity']";
        public const string ViewBasketButton = "//a[text() ='View Basket']";
        public static string RelatedProductLink(string productName) => $"//a[./h3[text()='{productName}']]";

        //Basket
        public const string TotalCost = "//td[@class='product-subtotal']/span";
        public static string ProductName(string productName) => "//td[@class='product-name']/a";

        //Ads
        public const string DismissButton = "//*[@id='dismiss-button']";
    }
}
