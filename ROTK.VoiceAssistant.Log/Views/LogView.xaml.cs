using ROTK.VoiceAssistant.Log.ViewModels;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ROTK.VoiceAssistant.Log.Views
{
    /// <summary>
    /// LogView.xaml 的交互逻辑
    /// </summary>
    [Export]
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
        }

        [Import]
        LogViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.8)));
            this.BeginAnimation(LogView.OpacityProperty, widthAnimation);
        }
    }
}
