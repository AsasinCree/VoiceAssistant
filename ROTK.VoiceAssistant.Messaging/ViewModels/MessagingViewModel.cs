﻿using Microsoft.CognitiveServices.SpeechRecognition;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.IntentHandler;
using ROTK.VoiceAssistant.LUISClientLibrary;
using ROTK.VoiceAssistant.Services;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Input;

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

            this.aggregator.GetEvent<FillToFieldEvent>().Subscribe(FillToField, ThreadOption.UIThread);
            this.aggregator.GetEvent<MessageSentEvent>().Subscribe(SendMessage, ThreadOption.UIThread);
        }

        private void SendMessage()
        {
            
        }

        private void FillToField(string content)
        {
            To = content;
        }

        #region ModelView

        private string to;
        public string To
        {
            get { return to; }
            set
            {
                this.to = value;
                RaisePropertyChanged("To");
            }
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

        private bool toIsFocused;
        public bool ToIsFocused
        {
            get { return toIsFocused; }
            set
            {
                this.toIsFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool subjectIsFocused;
        public bool SubjectIsFocused
        {
            get { return subjectIsFocused; }
            set
            {
                this.subjectIsFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool contentIsFocused;
        public bool ContentIsFocused
        {
            get { return contentIsFocused; }
            set
            {
                this.contentIsFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }
        #endregion

        public ICommand Send
        {
            get { return new DelegateCommand(() => this.Title = "Test"); }
        }
    }
}
