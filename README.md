# Weather Forecast
A simple weather forecast app showing current and daily weather forecasts for a specified location


The app is uses the OpenWeather REST API. More information can be found here: https://openweathermap.org/

## Setup
1. Get a (free of charge) API key from https://openweathermap.org/price
2. In the solution go to WeatherForecastApp -> WeatherForecastApp -> sample_appsecrets.json and rename **sample_appsecrets.json** to **appsecrets.json**
3. Update API key in appsecrets.json
``` json
{
    "appSecrets": {
        "ApiKey": "[[OPENWEATHER API KEY]]"
    }
}
```

*Note: Currently the Free OpenWeather API key has limitations of 60 calls per minute and one million calls per month*
