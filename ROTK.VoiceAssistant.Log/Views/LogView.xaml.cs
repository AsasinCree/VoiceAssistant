using ROTK.VoiceAssistant.Log.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;

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
    }
}
