using ROTK.VoiceAssistant.Navigation.ViewModels;
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

namespace ROTK.VoiceAssistant.Navigation.Views
{
    /// <summary>
    /// MainNavigationView.xaml 的交互逻辑
    /// </summary>
    /// 
    [Export]
    public partial class MainNavigationView : UserControl
    {
        public MainNavigationView()
        {
            InitializeComponent();
        }

        [Import]
        MainNavigationViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void Tile_Loaded(object sender, RoutedEventArgs e)
        {
            //DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.8)));
            //this.BeginAnimation(MainNavigationView.MarginProperty, widthAnimation);
        }
    }
}
