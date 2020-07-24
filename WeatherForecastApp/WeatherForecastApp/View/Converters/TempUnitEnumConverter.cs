using System;
using System.Globalization;
using System.Windows.Data;
using WeatherForecastApp.ViewModel;

namespace WeatherForecastApp.View
{
    class TempUnitEnumConverter : IValueConverter
    {
        /// <summary>
        /// Convert from Enum TempUnit to Bool depending on parameter string
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tempUnit = (TempUnit)value;
            var param = (string)parameter;

            string enumName = Enum.GetName(typeof(TempUnit), tempUnit);

            if (enumName == param)
                return true;
            else
                return false;
        }

        // convert string to enum
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = (string)parameter;

            return  Enum.Parse(typeof(TempUnit), param);
        }

    }
}
