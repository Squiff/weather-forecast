using System;
using OpenWeatherAPI.Response;

namespace WeatherForecastApp.ViewModel
{
    class DailyWeatherViewModel : ViewModelBase
    {
        public WeatherViewModel Weather { get; private set; }
        private DailyWeather DailyWeather { get; }
        private WeatherForecastOptions _options;
        
        public DailyWeatherViewModel(DailyWeather dailyWeather, WeatherForecastOptions options)
        {
            DailyWeather = dailyWeather;
            _options = options;
            Init();
        }

        private void Init()
        {
            Weather = new WeatherViewModel(DailyWeather.Weather[0]);
            _options.PropertyChanged += Options_PropertyChanged;
        }

        /// <summary>
        /// Convert UTC to local time
        /// </summary>
        private DateTime LocalTime(DateTime dt)
        {
            return dt.AddSeconds(_options.TimeZoneOffSet);
        }

        public DateTime Date { get { return LocalTime(DailyWeather.DateTime); } }
        public float MinTemp { get { return DailyWeather.Temp.Min; } }
        public float MaxTemp { get { return DailyWeather.Temp.Max; } }

        public float DisplayMinTemp
        {
            get { return TempConverter.FromKelvin(MinTemp, _options.TempUnit); }
        }

        public float DisplayMaxTemp
        {
            get { return TempConverter.FromKelvin(MaxTemp, _options.TempUnit); }
        }

        private void Options_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TempUnit")
                TempUnitFieldsChanged();
        }

        // Raise Property Changed events for fields that use the TempUnit for conversion
        private void TempUnitFieldsChanged()
        {
            OnProperyChanged("DisplayMinTemp");
            OnProperyChanged("DisplayMaxTemp");
        }


    }
}
