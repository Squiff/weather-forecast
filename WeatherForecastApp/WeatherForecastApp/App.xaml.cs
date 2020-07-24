using Microsoft.Extensions.Configuration;
using System.Windows;
using WeatherForecastApp.Settings;
using WeatherForecastApp.ViewModel;

namespace WeatherForecastApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IConfiguration _appConfig;
        private IConfiguration _userConfig;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SetAppConfig();
            SetUserConfig();

            AppSecrets secrets = _appConfig.GetSection("AppSecrets").Get<AppSecrets>();
            Location location = _userConfig.GetSection("location").Get<Location>();

            var window = new MainWindow(secrets, location);
            window.Show();
        }

        /// <summary>
        /// Load settings from appsettings.json
        /// </summary>
        private void SetAppConfig()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json");

            _appConfig = builder.Build();
        }

        /// <summary>
        /// Get the user config. Usually this would be stored in the users profile or in a DB, but using JSON for this demo to be less intrusive
        /// </summary>
        private void SetUserConfig()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("UserSettings.json");

            _userConfig = builder.Build();
        }
    }
}
