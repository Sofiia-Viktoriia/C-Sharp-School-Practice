namespace ToolsQAProject.Configurations
{
    public enum Browser
    {
        Chrome,
        Firefox,
        Edge
    }

    public class AppSettingsOptions
    {
        public const string AppSettings = "AppSettings";

        public Browser BrowserName { get; set; }
        public string URL { get; set; }
    }
}
