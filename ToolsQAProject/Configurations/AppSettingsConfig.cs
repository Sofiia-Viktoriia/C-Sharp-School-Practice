using BoDi;
using Microsoft.Extensions.Configuration;

namespace ToolsQAProject.Configurations
{
    public class AppSettingsConfig
    {
        private readonly IObjectContainer _objectContainer;
        private readonly IConfigurationRoot _configurationRoot;

        public AppSettingsConfig(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void SetApplicationConfiguration()
        {
            _objectContainer.RegisterInstanceAs(_configurationRoot.GetSection(AppSettingsOptions.AppSettings).Get<AppSettingsOptions>());
        }
    }
}
