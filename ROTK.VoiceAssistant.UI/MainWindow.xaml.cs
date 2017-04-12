using MahApps.Metro.Controls;
using ROTK.VoiceAssistant.UI.ViewModel;
using ROTK.VoiceAssistant.UI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using Prism.Regions;
using Prism.Modularity;
using Prism.Mvvm;

namespace ROTK.VoiceAssistant.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export]
    public partial class MainWindow : MetroWindow,IPartImportsSatisfiedNotification
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import]
        MainWindowsViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
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
            //this.Back.Visibility = Visibility.Collapsed;
            //this.SpecificWorkArea.Children.Clear();
            //this.TileArea.Visibility = Visibility.Visible;
            //DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.5)));
            //this.TileArea.BeginAnimation(ScrollViewer.OpacityProperty, widthAnimation);
        }

        private static Uri MainNavigationViewUri = new Uri("/MainNavigationView", UriKind.Relative);
        public void OnImportsSatisfied()
        {
            this.ModuleManager.LoadModuleCompleted +=
               (s, e) =>
               {

                    if (e.ModuleInfo.ModuleName == "NavigationModule")
                   {
                       this.RegionManager.RequestNavigate(
                           RegionNames.MainContentRegion,
                           MainNavigationViewUri);
                   }
               };
        }

        //private void MessageTileClick(object sender, RoutedEventArgs e)
        //{
        //    this.Back.Visibility = Visibility.Visible;
        //    this.TileArea.Visibility = Visibility.Collapsed;
        //    MessagingView messagingView = new MessagingView();
        //    DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.5)));
        //    messagingView.BeginAnimation(MessagingView.OpacityProperty, widthAnimation);
        //    this.SpecificWorkArea.Children.Add(messagingView);
        //}

        //private void QueryTileClick(object sender, RoutedEventArgs e)
        //{
        //    this.Back.Visibility = Visibility.Visible;
        //    this.TileArea.Visibility = Visibility.Collapsed;
        //    QueryView queryView = new QueryView();
        //    DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.5)));
        //    queryView.BeginAnimation(MessagingView.OpacityProperty, widthAnimation);
        //    this.SpecificWorkArea.Children.Add(queryView);
        //}


    }
}
