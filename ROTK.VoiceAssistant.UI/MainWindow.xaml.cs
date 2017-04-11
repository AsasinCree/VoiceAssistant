using MahApps.Metro.Controls;
using ROTK.VoiceAssistant.UI.ViewModel;
using ROTK.VoiceAssistant.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ROTK.VoiceAssistant.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowsViewModel(Bootstrapper.EventAggregatorInstant);
            InitializeComponent();

        }

        public String SelectedView
        {
            get { return this.SpecificWorkArea.Children.GetType().ToString(); }
        }

        private void Voice_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("../../Resources/voice_recorder_24px.ico", UriKind.Relative)));
            image.Stretch = Stretch.None;
            item.Background = image;
        }
         
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Back.Visibility = Visibility.Collapsed;
            this.SpecificWorkArea.Children.Clear();
            this.TileArea.Visibility = Visibility.Visible;
            DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.5)));
            this.TileArea.BeginAnimation(ScrollViewer.OpacityProperty, widthAnimation);
        }

        private void MessageTileClick(object sender, RoutedEventArgs e)
        {
            this.Back.Visibility = Visibility.Visible;
            this.TileArea.Visibility = Visibility.Collapsed;
            MessagingView messagingView = new MessagingView();
            DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.5)));
            messagingView.BeginAnimation(MessagingView.OpacityProperty, widthAnimation);
            this.SpecificWorkArea.Children.Add(messagingView);
        }

        private void QueryTileClick(object sender, RoutedEventArgs e)
        {
            this.Back.Visibility = Visibility.Visible;
            this.TileArea.Visibility = Visibility.Collapsed;
            QueryView queryView = new QueryView();
            DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.5)));
            queryView.BeginAnimation(MessagingView.OpacityProperty, widthAnimation);
            this.SpecificWorkArea.Children.Add(queryView);
        }
    }
}
