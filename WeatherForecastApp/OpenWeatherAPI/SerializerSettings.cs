using System.Collections.Generic;
using Newtonsoft.Json;
using OpenWeatherAPI.Converter;

namespace OpenWeatherAPI
{
    /// <summary>
    /// Container for storing converters that should be used for deserializing JSON responses from the OpenWeather API
    /// </summary>
    class SerializerSettings
    {
        public static List<JsonConverter> RegisteredConverters { get; private set; }

        static SerializerSettings()
        {
            RegisterConverters();
        }

        private static void RegisterConverters()
        {
            RegisteredConverters = new List<JsonConverter>();
            RegisteredConverters.Add(new UnixDateTimeConverter());
            RegisteredConverters.Add(new LocationConverter());
            
        }
    }

}
