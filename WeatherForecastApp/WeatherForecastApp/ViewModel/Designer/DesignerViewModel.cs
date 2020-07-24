using OpenWeatherAPI;
using OpenWeatherAPI.Response;
using System;
using System.IO;
using WeatherForecastApp.Settings;

namespace WeatherForecastApp.ViewModel.Designer
{
    /// <summary>
    /// Provider class for design time data
    /// </summary>
    class DesignerViewModel : WeatherForecastViewModel
    {
        // location of design time JSON
        private string _designJsonPath = @"ViewModel\Designer\OneCallSample.json";

        // objects to inject into WeatherForecastViewModel
        private static AppSecrets _designSecret = new Settings.AppSecrets() { ApiKey = "" }; // used to call base WeatherForecastViewModel
        private static Location _designLocation = new Location() { Name = "London", Country = "GB" };

        public DesignerViewModel() : base(_designSecret, _designLocation)
        {
            OneCallResponse = OneCallDesignData();
            SetForecast();
        }

        private OneCallResponse OneCallDesignData()
        {
            string sampleLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _designJsonPath);
            string sampleJson = File.ReadAllText(sampleLocation);           

            // deserialize and return the resulting object
            return OpenWeather.DeserializeJson<OneCallResponse>(sampleJson);
        }


    }
}
