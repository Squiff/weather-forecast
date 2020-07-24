using Newtonsoft.Json;

namespace OpenWeatherAPI.Response
{
    public class OneCallResponse : IJsonResponse
    {
        public string Json { get; set; }

        [JsonProperty("lat")]
        public float Lat { get; set; }
        [JsonProperty("lon")]
        public float Lon { get; set; }
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
        [JsonProperty("timezone_offset")]
        public int TimeZoneOffset { get; set; }
        [JsonProperty("current")]
        public CurrentWeather CurrentWeather { get; set; }
        [JsonProperty("hourly")]
        public HourlyWeather[] HourlyWeather { get; set; }
        [JsonProperty("daily")]
        public DailyWeather[] DailyWeather { get; set; }
        
    }
}
