using System;
using System.Globalization;
using System.Windows.Data;

namespace WeatherForecastApp.View
{
    class NumericToDegrees : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (float)value;

            return $"{Math.Round(temp, 0).ToString()}°";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
