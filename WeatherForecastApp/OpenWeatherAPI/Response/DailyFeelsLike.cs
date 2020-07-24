using Newtonsoft.Json;

namespace OpenWeatherAPI.Response
{
    public class DailyFeelsLike
    {
        [JsonProperty("day")]
        public float Day { get; set; }
        [JsonProperty("night")]
        public float Night { get; set; }
        [JsonProperty("eve")]
        public float Evening { get; set; }
        [JsonProperty("morn")]
        public float Morning { get; set; }
    }
}
