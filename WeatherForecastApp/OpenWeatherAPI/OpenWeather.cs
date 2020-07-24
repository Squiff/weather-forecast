using System;
using System.Collections.Generic;
using System.Net.Http;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OpenWeatherAPI.Response;
using Newtonsoft.Json;
using OpenWeatherAPI.Logging;
using System.Linq;

namespace OpenWeatherAPI
{
    public class OpenWeather
    {

        // Instance fields
        private string _apiKey;

        //Static fields
        private static HttpClient Client;
        private static JsonConverter[] JsonConverters;

        public event EventHandler<LogArgs> Logger;

        /// <summary>
        /// Initialize static properties
        /// </summary>
        static OpenWeather()
        {
            InitializeClient();
            JsonConverters = SerializerSettings.RegisteredConverters.ToArray();
        }

        public OpenWeather(string apiKey)
        {
            _apiKey = apiKey;
        }

        private static void InitializeClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
        }

        /// <summary>
        /// Raise a Logger event with the specified message
        /// </summary>
        private void Log(string message)
        {
            var logArgs = new LogArgs(message);
            Logger?.Invoke(this, logArgs);
        }

        /// <summary>
        /// Make a call to the OpenWeather One Call API
        /// </summary>
        /// <param name="lat">latitude of location</param>
        /// <param name="lon">longitude of location</param>
        /// <param name="exclude">periods to exclude from response</param>
        /// <returns>OneCallResponse containing current/weekly/hourly weather information</returns>
        public async Task<OneCallResponse> OneCall(float lat, float lon, IEnumerable<PeriodOptions> exclude)
        {
            string query = $"onecall?lat={lat}&lon={lon}";

            // convert enum to text
            var excludeText = exclude.Select(x => Enum.GetName(typeof(PeriodOptions), x));

            string exludeQuery = string.Join(",", excludeText);

            if (string.IsNullOrEmpty(exludeQuery) == false)
                query += $"&exclude={exludeQuery}";

            // make API call
            var response = await GetRequest<OneCallResponse>(query);

            return response;
        }

        /// <summary>
        /// search for loaction based on test string
        /// </summary>
        /// <returns>LocationResponse containing matching locations</returns>
        public async Task<LocationResponse> LocationSearch(string searchText)
        {
            string query = $"find?q={searchText}";

            LocationResponse response = await GetRequest<LocationResponse>(query);

            return response;
        }

        /// <summary>
        /// Send GET request and deserialize JSON response to type T
        /// </summary>
        private async Task<T> GetRequest<T>(string query) where T : IJsonResponse
        {
            // get uri for logging (before adding API key)
            string requestUri = $"{Client.BaseAddress}{query}"; 

            query = AddKeyQuery(query);

            try
            {
                Log($"Making Call to {requestUri}");
                string responseJson = await Client.GetStringAsync(query);

                Log($"Deserializing JSON Response from {requestUri}");
                T response = DeserializeJson<T>(responseJson);

                Log($"JSON Deserialized Successfully");
                return response;
            }
            catch (Exception E)
            {
                Log($"Error: {E.Message}");
                throw E;
            }

        }

        /// <summary>
        /// Append API Key to query
        /// </summary>
        private string AddKeyQuery(string query)
        {
            return $"{query}&appid={_apiKey}";
        }

        /// <summary>
        /// Deserialize json string to type T
        /// </summary>
        public T DeserializeJson<T>(string json) where T  : IJsonResponse
        {
            T deserialized = JsonConvert.DeserializeObject<T>(json, JsonConverters);

            // store raw json
            deserialized.Json = json;

            return deserialized;
        }
    }
}
