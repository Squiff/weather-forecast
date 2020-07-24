using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherForecastApp.ViewModel;
using WeatherForecastApp.Settings;

namespace WeatherForecastApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(AppSecrets appSecrets, Location location)
        {
            InitializeComponent();
            DataContext = new WeatherForecastViewModel(appSecrets, location);
        }

        /// <summary>
        /// Make API call when window loads
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var VM = (WeatherForecastViewModel)DataContext;

            if (VM.GetForecastCommand.CanExecute(null))
                VM.GetForecastCommand.Execute(null);
        }

        /// <summary>
        /// enable horizontal scrolling on scrollviewer
        /// </summary>
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = (ScrollViewer)sender;
            if (e.Delta > 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
            e.Handled = true;
        }

        /// <summary>
        /// Make window draggable
        /// </summary>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

    }
}
