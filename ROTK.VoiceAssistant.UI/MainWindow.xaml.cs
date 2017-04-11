using MahApps.Metro.Controls;
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
            InitializeComponent();
        }

        public String SelectedView
        {
            get { return this.MainTabControl.SelectedValue.ToString(); }
        }

        private void Voice_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("../../Resources/voice_recorder_24px.ico", UriKind.Relative)));
            image.Stretch = Stretch.None;
            item.Background = image;
        }
    }
}
