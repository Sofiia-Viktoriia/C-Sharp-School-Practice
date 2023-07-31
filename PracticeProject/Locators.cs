namespace PracticeProject
{
    internal class Locators
    {
        public string SearchIconXPath = "//input[@id='s']";
        public string SearchIconCSS = "input#s";

        public string FilterButtonXPath = "//button[@class='button']";
        public string FilterButtonCSS = "button.button";

        public string MenuOptionTestCasesXPath = "//li[@id='menu-item-224']/a";
        public string MenuOptionXPath(string optionName) => $"//li/a[text()='{optionName}']";
        public string MenuOptionTestCaseCSS = "li#menu-item-224>a";

        public string ExpanderXPath = "//a[@class='pull-down']";
        public string ExpanderCSS = "a.pull-down";

        public string CategoryJavaScriptXPath = "//li[contains(@class, 'cat-item-21')]/a";
        public string CategoryXPath(string categoryName) => $"//li/a[text()='{categoryName}']";
        public string CategoryJavaScriptCSS = "li.cat-item-21>a";

        public string PostXPath = "//li[contains(@class,'post-169')]";
        public string PostCSS = "li.post-169";

        public string SortingOptionByNewnessXPath = "//option[@value='date']";
        public string SortingOptionXPath(string value) => $"//select/option[@value='{value}']";
        public string SortingOptionTextValueXPath(string textValue) => $"//select/option[text()='{textValue}']";
        public string SortingOptionByNewnessCSS = "option[value='date']";

        public string HTML5FormsPriceXPath = "//li[contains(@class,'post-181')]//span[@class='price']";
        public string PriceXPath(string postId) => $"//li[contains(@class,{postId}')]//span[@class='price']";
        public string HTML5FormsCSS = "li.post-181 span.price";

        public string EmailInputXPath = "//input[@name='EMAIL']";
        public string EmailInputCSS = "input[name='EMAIL']";

        public string CopyrightYearXPath = "//div[@class='one']/text()[2]";
        public string CopyrightCSS = "div.one";
    }
}
