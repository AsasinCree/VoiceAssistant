using Prism.Events;
using ROTK.VoiceAssistant.UI.ViewModel;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ROTK.VoiceAssistant.UI.View
{
    /// <summary>
    /// MessagingView.xaml 的交互逻辑
    /// </summary>
    public partial class MessagingView : Page
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
    }
}
