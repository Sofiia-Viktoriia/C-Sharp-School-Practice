using Microsoft.Extensions.Configuration;

namespace ToolsQAProject.Configurations
{
    public static class AppSettingsConfig
    {

        private static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static AppSettingsOptions? GetApplicationConfiguration()
        {
            var iConfig = GetIConfigurationRoot();
            return iConfig.GetSection(AppSettingsOptions.AppSettings).Get<AppSettingsOptions>();
        }
    }
}
