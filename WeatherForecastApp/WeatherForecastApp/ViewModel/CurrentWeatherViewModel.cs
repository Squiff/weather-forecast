using OpenWeatherAPI.Response;
using System;

namespace WeatherForecastApp.ViewModel
{
    class CurrentWeatherViewModel : ViewModelBase
    {
        public WeatherViewModel Weather { get; set; }

        private CurrentWeather _currentWeather;
        private WeatherForecastOptions _options;

        public CurrentWeatherViewModel(CurrentWeather currentWeather, WeatherForecastOptions options)
        {
            _currentWeather = currentWeather;
            _options = options;
            Init();
        }

        private void Init()
        {
            Weather = new WeatherViewModel(_currentWeather.Weather[0]);
            // Sub to options property changed event
            _options.PropertyChanged += Options_PropertyChanged;
        }

        public DateTime Sunrise { get { return LocalTime(_currentWeather.Sunrise); } }
        public DateTime Sunset { get { return LocalTime(_currentWeather.Sunset); } }
        public float DisplayTemp { get { return TempConverter.FromKelvin(_currentWeather.Temp, _options.TempUnit); } } // Temp is provided in Kelvin
        public float DisplayFeelsLikeTemp { get { return TempConverter.FromKelvin(_currentWeather.TempFeelsLike, _options.TempUnit); } }

        /// <summary>
        /// Wind Speed in MPH
        /// </summary>
        public int WindSpeed 
        { 
            get { 
                    float mph = VelocityConverter.MetersSecondToMph(_currentWeather.WindSpeed);
                    return (int)Math.Round(mph);
                } 
        }

        /// <summary>
        /// Convert UTC to local time
        /// </summary>
        private DateTime LocalTime(DateTime dt)
        {
            return dt.AddSeconds(_options.TimeZoneOffSet);
        }

        /// <summary>
        /// Options property Changed event handler
        /// </summary>
        private void Options_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TempUnit")
                TempUnitFieldsChanged();
        }

        /// <summary>
        ///  Raise Property Changed events for fields that use the TempUnit for conversion
        /// </summary>
        private void TempUnitFieldsChanged()
        {
            OnProperyChanged("DisplayTemp");
            OnProperyChanged("DisplayFeelsLikeTemp");
        }
    }
}
