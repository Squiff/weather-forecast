using OpenWeatherAPI.Response;

namespace WeatherForecastApp.ViewModel
{
    class WeatherViewModel
    {
        private Weather _weather;

        public WeatherViewModel(Weather weather)
        {
            _weather = weather;
        }

        public string Description
        {
            get { return _weather.LongDescription; }
        }

        public string IconURI
        {
            get { return $"http://openweathermap.org/img/wn/{_weather.Icon}@4x.png"; }
        }
    }
}
