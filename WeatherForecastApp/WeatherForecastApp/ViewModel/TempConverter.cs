namespace WeatherForecastApp.ViewModel
{

    static class TempConverter
    {

        public static float FromKelvin(float kelvin, TempUnit tempUnit)
        {
            switch (tempUnit)
            {
                case TempUnit.Celsius:
                    return TempConverter.KelvinToCelsius(kelvin);
                case TempUnit.Fahrenheit:
                    return TempConverter.KelvinToFahrenheit(kelvin);
                default:
                    return default;
            }
        }

        public static float KelvinToCelsius(double kelvin)
        {
            return (float)(kelvin - 273.15);
        }

        public static float KelvinToFahrenheit(double kelvin)
        {
            double celsius = KelvinToCelsius(kelvin);
            return (float)(((celsius * 9) / 5) + 32);
        }
    }
}
