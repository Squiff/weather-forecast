using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WeatherForecastApp.ViewModel;

namespace WeatherForecastApp.View
{
    /// <summary>
    /// Interaction logic for ErrorCard.xaml
    /// </summary>
    public partial class ErrorCard : UserControl
    {
        Storyboard AnimateFadeOut;
        Storyboard AnimateFadeIn;

        public ErrorCard()
        {
            InitializeComponent();
            InitStoryboards();
        }

        private void InitStoryboards()
        {
            AnimateFadeOut = (Storyboard)Resources["FadeOut"];
            AnimateFadeIn = (Storyboard)Resources["FadeIn"];

            Storyboard.SetTarget(AnimateFadeOut, this);
            Storyboard.SetTarget(AnimateFadeIn, this);
        }

        /// <summary>
        /// Fade out the control
        /// </summary>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            AnimateFadeOut.Begin();
        }

        /// <summary>
        /// After fade out, remove from parent collection
        /// </summary>
        private void FadeOut_Complete(object sender, EventArgs e)
        {
            var errorMessage = (ErrorMessage)DataContext;
            var x = ParentItemSource.Remove(errorMessage);
            Console.WriteLine(x);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AnimateFadeIn.Begin();
        }

        /// <summary>
        /// Bindable property to allow element to remove itself from collection
        /// </summary>
        public ObservableCollection<ErrorMessage> ParentItemSource
        {
            get { return (ObservableCollection<ErrorMessage>)GetValue(ParentItemSourceProperty); }
            set { SetValue(ParentItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentItemSourceProperty =
            DependencyProperty.Register("ParentItemSource", typeof(ObservableCollection<ErrorMessage>), typeof(ErrorCard), new PropertyMetadata(null));

        
    }
}
