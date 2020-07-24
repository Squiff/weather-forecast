using System;
using System.Globalization;
using System.Windows.Data;

namespace WeatherForecastApp.View
{
    // Convert DateTime to Time String - 24 hour format
    class DateTimeToTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.ToString("H:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
