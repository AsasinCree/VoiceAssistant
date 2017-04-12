using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ROTK.VoiceAssistant.Messaging.ViewModel
{
    [Export]
    public class MessagingViewModel: BindableBase
    { 
        private IEventAggregator aggregator;

        [ImportingConstructor]
        public MessagingViewModel(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;

            this.aggregator.GetEvent<MessageUIOperationEvent>().Subscribe(OperateMessageView);
            this.aggregator.GetEvent<FillMessageFieldEvent>().Subscribe(FillMessageField);
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                this.title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string To { get; set; }

        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                this.content = value;
                RaisePropertyChanged("Content");
            }
        }

        private bool isFocused;
        public bool IsFocused
        {
            get { return isFocused; }
            set
            {
                this.isFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }


        public ICommand SendMessage
        {
            get { return new DelegateCommand(() => this.Title = "Test"); }
        }

        public void OperateMessageView()
        {
         
        }

        public void FillMessageField(string fieldContent)
        {

        }
    }
}
