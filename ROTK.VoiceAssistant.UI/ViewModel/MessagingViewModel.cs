using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ROTK.VoiceAssistant.UI.ViewModel
{
    public class MessagingViewModel: BindableBase
    {
        public string Title { get; set; }

        public string To { get; set; }


        public ICommand SendMessage
        {
            get { return new DelegateCommand(() => this.Title = "Test"); }
        }
    }
}
