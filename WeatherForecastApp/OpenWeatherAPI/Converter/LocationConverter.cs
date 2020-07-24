using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using OpenWeatherAPI.Response;
namespace OpenWeatherAPI.Converter
{
    /// <summary>
    /// Converter for JSON to Location
    /// </summary>
    class LocationConverter : JsonConverter<Location>
    {
        public override Location ReadJson(JsonReader reader, Type objectType, Location existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            var coord = new Coordinate()
            {
                Lat = (float)jsonObject["coord"]["lat"],
                Lon = (float)jsonObject["coord"]["lon"]
            };

            var Location = new Location()
            {
                Id = (int)jsonObject["id"],
                Name = (string)jsonObject["name"],
                Country = (string)jsonObject["sys"]["country"],
                Coordinate = coord
            };

            return Location;
        }

        public override void WriteJson(JsonWriter writer, Location value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
