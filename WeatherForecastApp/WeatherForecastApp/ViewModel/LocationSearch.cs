using System.Collections.ObjectModel;
using OpenWeatherAPI;
using OpenWeatherAPI.Response;
using System.Threading.Tasks;

namespace WeatherForecastApp.ViewModel
{
    class LocationSearch : ViewModelBase
    {
        public ObservableCollection<Location> SearchResults = new ObservableCollection<Location>();
        private string _searchText;
        private OpenWeather OpenWeather;


        public LocationSearch(OpenWeather openWeather)
        {
            OpenWeather = openWeather;
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnProperyChanged("SearchText");
            }
        }

        /// <summary>
        /// Make Open Weather API Call to get location coordinates
        /// </summary>
        public async Task SearchLocations()
        {
            LocationResponse LR = await OpenWeather.LocationSearch(SearchText);

            SearchResults.Clear();

            foreach (var L in LR.Locations)
            {
                var LocationVM = new Location()
                {
                    Name = L.Name,
                    Country = L.Country,
                    Lon = L.Coordinate.Lon,
                    Lat = L.Coordinate.Lat
                };

                SearchResults.Add(LocationVM);
            }
        }

    }
}
