using System;
using Newtonsoft.Json;

namespace OpenWeatherAPI.Response
{
    public class CurrentWeather
    {
        [JsonProperty("dt")]
        public DateTime DateTime { get; set; }
        [JsonProperty("sunrise")]
        public DateTime Sunrise { get; set; }
        [JsonProperty("sunset")]
        public DateTime Sunset { get; set; }
        [JsonProperty("temp")]
        public float Temp { get; set; }
        [JsonProperty("feels_like")]
        public float TempFeelsLike { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("clouds")]
        public int Clouds { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        [JsonProperty("wind_speed")]
        public float WindSpeed { get; set; }
        [JsonProperty("wind_deg")]
        public int WindDirection { get; set; }
        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }
    }
}
