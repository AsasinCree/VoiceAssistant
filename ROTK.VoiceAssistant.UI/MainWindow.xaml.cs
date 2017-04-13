using MahApps.Metro.Controls;
using Prism.Modularity;
using Prism.Regions;
using ROTK.VoiceAssistant.UI.ViewModel;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ROTK.VoiceAssistant.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export]
    public partial class MainWindow : MetroWindow, IPartImportsSatisfiedNotification
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
            Button item = sender as Button;
            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("../../Resources/voice1_48px.ico", UriKind.Relative)));
            image.Stretch = Stretch.None;
            item.Background = image;
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
    }
}
