namespace OpenWeatherAPI.Response
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }
        public string Country { get; set; }
    }
}
