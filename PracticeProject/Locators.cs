namespace PracticeProject
{
    internal class Locators
    {
        public string SearchIconXPath = "//header//input[@id='s']";
        public string SearchIconCSS = "header input#s";

        public string FilterButtonXPath = "//div[contains(concat(' ', @class, ' '), ' widget_price_filter ')]//button[@class='button']";
        public string FilterButtonCSS = "div.widget_price_filter button.button";

        public string MenuOptionTestCasesXPath = "//nav[@id='main-nav-wrap']//li[@id='menu-item-224']/a";
        public string MenuOptionByNameXPath(string optionName) => $"//nav[@id='main-nav-wrap']//li/a[text()='{optionName}']";
        public string MenuOptionTestCaseCSS = "nav#main-nav-wrap li#menu-item-224>a";

        public string ExpanderXPath = "//header//a[@class='pull-down']";
        public string ExpanderCSS = "header a.pull-down";

        public string CategoryJavaScriptXPath = "//div[@id='woocommerce_product_categories-2']//li[contains(concat(' ', @class, ' '), ' cat-item-21 ')]";
        public string CategoryByNameXPath(string categoryName) => $"//div[@id='woocommerce_product_categories-2']//li[./a[text()='{categoryName}']]";
        public string CategoryJavaScriptCSS = "div#woocommerce_product_categories-2 li.cat-item-21";

        public string AndroidQuickStartGuidePostXPath = "//ul[contains(concat(' ', @class, ' '), ' products ')]/li[contains(concat(' ', @class,' '), ' post-169 ')]";
        public string PostByTitleXPath(string postTitle) => $"//ul[contains(concat(' ', @class, ' '), ' products ')]/li[.//h3[text()='{postTitle}']]";
        public string AndroidQuickStartGuidePostCSS = "ul.products>li.post-169";

        public string SortingOptionByNewnessXPath = "//select[@class='orderby']/option[@value='date']";
        public string SortingOptionByValueXPath(string value) => $"//select[@class='orderby']/option[@value='{value}']";
        public string SortingOptionByTextXPath(string textValue) => $"//select[@class='orderby']/option[text()='{textValue}']";
        public string SortingOptionByNewnessCSS = "select.orderby>option[value='date']";

        public string HTML5FormsPriceXPath = "//ul[contains(concat(' ', @class, ' '), ' products ')]/li[contains(concat(' ', @class, ' '), ' post-181 ')]//span[@class='price']";
        public string PriceByPostTitleXPath(string postTitle) => $"//ul[contains(concat(' ', @class, ' '), ' products ')]/li[.//h3[text()='{postTitle}']]//span[@class='price']";
        public string HTML5FormsCSS = "ul.products>li.post-181 span.price";

        public string EmailInputXPath = "//div[@id='mc4wp_form_widget-2']//input[@name='EMAIL']";
        public string EmailInputCSS = "div#mc4wp_form_widget-2 input[name='EMAIL']";

        public string CopyrightYearXPath = "//div[contains(concat(' ', @class, ' '), ' footer-text ')]//div[@class='one']/text()[last()]";
        public string CopyrightCSS = "div.footer-text div.one";
    }
}
