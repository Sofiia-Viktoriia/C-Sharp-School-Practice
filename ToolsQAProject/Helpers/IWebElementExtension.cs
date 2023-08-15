using OpenQA.Selenium;

namespace ToolsQAProject.Helpers
{
    public static class IWebElementExtension
    {
        private const string _scrollToElementScript = "arguments[0].scrollIntoView({ block: \"center\" });";

        public static IWebElement ScrollToElement(this IWebElement element)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            javaScriptExecutor.ExecuteScript(_scrollToElementScript, element);
            return element;
        }

        public static IWebElement ScriptClick(this IWebElement element)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            javaScriptExecutor.ExecuteScript("arguments[0].click();", element);

            return element;
        }
    }
}
