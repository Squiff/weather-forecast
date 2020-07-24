namespace WeatherForecastApp.ViewModel
{
    class WeatherForecastOptions : ViewModelBase
    {
        public int TimeZoneOffSet { get; set; }

        private TempUnit _tempUnit;

        public TempUnit TempUnit
        {
            get { return _tempUnit; }
            set
            {
                _tempUnit = value;
                OnProperyChanged("TempUnit");
            }
        }
    }
}
