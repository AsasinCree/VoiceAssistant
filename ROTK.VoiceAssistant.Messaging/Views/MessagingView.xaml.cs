using Prism.Events;
using ROTK.VoiceAssistant.Messaging.ViewModel;
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

namespace ROTK.VoiceAssistant.Messaging.Views
{
    /// <summary>
    /// Interaction logic for MessagingView1.xaml
    /// </summary>
    [Export]
    public partial class MessagingView : UserControl
    {
        public MessagingView()
        {
            InitializeComponent();
        }



        [Import]
        MessagingViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.8)));
            this.BeginAnimation(MessagingView.OpacityProperty, widthAnimation);
        }        
    }
}
