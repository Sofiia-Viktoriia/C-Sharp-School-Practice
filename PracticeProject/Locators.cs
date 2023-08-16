namespace PracticeProject
{
    public class Locators
    {
        //Search page
        public const string ProductLinks = "//div[@id='content']//h2/a";
        public const string PageName = "//div[@id='content']//h1[@class='page-title']";
        public static string PostLinkByName(string postName) => $"//article//h2/a[text()='{postName}']";

        //Product page
        public const string ProductTitle = "div.summary .product_title";
        public const string OnSaleMark = "div.product span.onsale";
        public const string OldPrice = "//p[@class='price']/del/span";
        public const string NewPrice = "//p[@class='price']/ins/span";
        public const string RegularPrice = "p.price > span";
        public const string AddToBasketButton = "//form[@class='cart']//button[text()='Add to basket']";
        public const string ProductQuantityInput = "//form[@class='cart']//input[@name='quantity']";
        public const string ViewBasketButton = "//div[@class='woocommerce-message']//a[text() ='View Basket']";
        public static string RelatedProductLinkByName(string productName) => $"//div[@class='related products']//a[./h3[text()='{productName}']]";

        //Basket
        public const string TotalCost = "//table[contains(concat(' ', @class, ' '), ' cart ')]//td[@class='product-subtotal']/span";
        public static string ProductName(string productName) => "//table[contains(concat(' ', @class, ' '), ' cart ')]//td[@class='product-name']/a";

        //Ads
        public const string DismissButton = "//*[@id='dismiss-button']";
        public const string FrameId = "aswift_5";
        public const string InnerFrameId = "ad_iframe";

        //Header
        public const string SearchInputId = "s";
    }
}
