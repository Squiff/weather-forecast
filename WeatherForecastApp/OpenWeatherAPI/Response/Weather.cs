using Newtonsoft.Json;

namespace OpenWeatherAPI.Response
{
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string ShortDescription { get; set; }
        [JsonProperty("description")]
        public string LongDescription { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
