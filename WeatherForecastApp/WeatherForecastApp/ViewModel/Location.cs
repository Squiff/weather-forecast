namespace WeatherForecastApp.ViewModel
{
    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }

        public string DisplayText { get { return $"{Name}, {Country}"; } }
     }

}
