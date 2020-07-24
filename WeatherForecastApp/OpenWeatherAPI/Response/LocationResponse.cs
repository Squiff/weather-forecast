using Newtonsoft.Json;

namespace OpenWeatherAPI.Response
{
    public class LocationResponse : IJsonResponse
    {
        public string Json { get; set; }

        [JsonProperty("list")]
        public Location[] Locations;
    }
}
