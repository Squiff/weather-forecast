using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenWeatherAPI.Converter
{
    /// <summary>
    /// Convert from unix timestamp to DateTime
    /// </summary>
    class UnixDateTimeConverter : DateTimeConverterBase
    {
        static DateTime epoch = new DateTime(1970, 1, 1);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long value = (long)reader.Value;
            return epoch.AddSeconds(value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime DteValue = (DateTime)value;
            TimeSpan Delta = DteValue - epoch;
            writer.WriteValue(Delta.TotalSeconds);
        }

    }
}
