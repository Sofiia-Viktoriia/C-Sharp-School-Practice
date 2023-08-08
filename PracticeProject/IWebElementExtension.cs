namespace PracticeProject
{
    public static class IWebElementExtension
    {
        private const string _scrollToElementScript = "arguments[0].scrollIntoView({ block: \"center\" });";

        public static void ScrollToElement(this IWebElement element, IJavaScriptExecutor javaScriptExecutor)
        {
            javaScriptExecutor.ExecuteScript(_scrollToElementScript, element);
        }
    }
}
