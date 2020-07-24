namespace WeatherForecastApp.ViewModel
{
    class VelocityConverter
    {
        public static float MetersSecondToMph(float metersSecond)
        {
            return (float)(metersSecond * 2.237);
        }
    }
}
