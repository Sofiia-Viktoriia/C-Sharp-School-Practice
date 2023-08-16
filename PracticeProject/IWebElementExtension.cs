namespace PracticeProject
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
    }
}
