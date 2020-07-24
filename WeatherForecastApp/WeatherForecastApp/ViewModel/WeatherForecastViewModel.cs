using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OpenWeatherAPI;
using OpenWeatherAPI.Response;
using WeatherForecastApp.Settings;
using WeatherForecastApp.ViewModel.Base;

namespace WeatherForecastApp.ViewModel
{
    class WeatherForecastViewModel : ViewModelBase
    {

        // Properties
        public OpenWeather OpenWeather { get; private set; }
        public ObservableCollection<DailyWeatherViewModel> DailyForecast { get; } = new ObservableCollection<DailyWeatherViewModel>() { };
        public WeatherForecastOptions Options { get; } = new WeatherForecastOptions();
        public ICommand GetForecastCommand { get; set; }
        public ICommand LocationSearchCommand { get; set; }
        public OneCallResponse OneCallResponse { get; set; }
        public LocationSearch LocationSearch { get; }
        public ObservableCollection<ErrorMessage> DisplayErrors { get; } = new ObservableCollection<ErrorMessage>() { };

        // private fields
        private CurrentWeatherViewModel _currentWeather;
        private Location _location;
        
        public WeatherForecastViewModel(AppSecrets appSecrets, Location location)
        {
            OpenWeather = new OpenWeather(appSecrets.ApiKey); // use the Logger event
            LocationSearch = new LocationSearch(OpenWeather);
            Location = location;
            InitCommands();
        }

        /// <summary>
        /// Initiate command used in UI
        /// </summary>
        private void InitCommands()
        {
            GetForecastCommand = new RelayCommand(GetForecast);
            LocationSearchCommand = new RelayCommand(SetLocation);
        }

        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnProperyChanged("Location");
            }
        }

        public CurrentWeatherViewModel CurrentWeather
        {
            get { return _currentWeather; }
            set
            {
                _currentWeather = value;
                OnProperyChanged("CurrentWeather");
            }
        }

        /// <summary>
        /// Make OpenWeather API Call to get location coordinates from search string
        /// </summary>
        public async void SetLocation()
        {
            try
            {
                await LocationSearch.SearchLocations();
            }
            catch (Exception)
            {
                var E = new ErrorMessage("An error occurred whilst searching for location");
                DisplayErrors.Add(E);
            }

            if (LocationSearch.SearchResults.Count == 0)
            {
                var E = new ErrorMessage($"Could not find a Match for {LocationSearch.SearchText}");
                DisplayErrors.Clear();
                DisplayErrors.Add(E);
            }
            else
            {   // results found
                DisplayErrors.Clear();
                Location = LocationSearch.SearchResults[0];
                GetForecast();
            }
        }

        /// <summary>
        /// Make OpenWeather API Call to get weather information
        /// </summary>
        public async void GetForecast()
        {
            try
            {
                var excludePeriod = new PeriodOptions[] { PeriodOptions.Minutely, PeriodOptions.Hourly };
                OneCallResponse = await OpenWeather.OneCall(Location.Lat, Location.Lon, excludePeriod);
                SetForecast();
            }
            catch (Exception)
            {
                var E = new ErrorMessage("An error occurred whilst getting weather forecast");
                DisplayErrors.Add(E);
            }
        }

        /// <summary>
        /// Set the Daily and Current forecast
        /// </summary>
        protected void SetForecast()
        {
            Options.TimeZoneOffSet = OneCallResponse.TimeZoneOffset;
            CurrentWeather = new CurrentWeatherViewModel(OneCallResponse.CurrentWeather, Options);
            SetDailyForecast();
        }

        /// <summary>
        /// Set the Daily forecast for the next week
        /// </summary>
        private void SetDailyForecast()
        {
            DailyForecast.Clear();

            for (int i = 0; i < 7; i++)
            {
                var dailyWeather = new DailyWeatherViewModel(OneCallResponse.DailyWeather[i], Options);
                DailyForecast.Add(dailyWeather);
            }
                
            OnProperyChanged("DailyForecast");
        }

    }
}
