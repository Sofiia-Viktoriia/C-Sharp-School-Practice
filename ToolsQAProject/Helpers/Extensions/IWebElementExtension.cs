using OpenQA.Selenium;

namespace ToolsQAProject.Helpers.Extensions
{
    public static class IWebElementExtension
    {
        private const string _scrollToElementScript = "arguments[0].scrollIntoView({ block: \"center\" });";
        private const string _makeElementHiddenScript = "arguments[0].hidden = true;";

        public static IWebElement ScrollToElement(this IWebElement element)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            javaScriptExecutor.ExecuteScript(_scrollToElementScript, element);
            return element;
        }

        public static IWebElement MakeHidden(this IWebElement element)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            javaScriptExecutor.ExecuteScript(_makeElementHiddenScript, element);
            return element;
        }
    }
}
