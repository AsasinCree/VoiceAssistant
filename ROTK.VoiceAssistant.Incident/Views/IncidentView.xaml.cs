using ROTK.VoiceAssistant.Incident.ViewModels;
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

namespace ROTK.VoiceAssistant.Incident.Views
{
    /// <summary>
    /// IncidentView.xaml 的交互逻辑
    /// </summary>
    [Export]
    public partial class IncidentView : UserControl
    {

        public IncidentView()
        {
            InitializeComponent();
        }

        [Import]
        IncidentViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.8)));
            this.BeginAnimation(IncidentView.OpacityProperty, widthAnimation);
        }
    }
}
