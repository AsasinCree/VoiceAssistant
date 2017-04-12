using Microsoft.CognitiveServices.SpeechRecognition;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.IntentHandler;
using ROTK.VoiceAssistant.LUISClientLibrary;
using ROTK.VoiceAssistant.Model;
using ROTK.VoiceAssistant.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ROTK.VoiceAssistant.UI.ViewModel
{
    [Export]
    public class MainWindowsViewModel : BindableBase
    {
        IEventAggregator aggregator;

        IVoiceServiceFactory voiceServiceFactory;
        private readonly IRegionManager regionManager;
        private ICommand backCommand;


        [ImportingConstructor]
        public MainWindowsViewModel(IEventAggregator aggregator, IRegionManager regionManager, IVoiceServiceFactory voiceServiceFactory)
        {
            this.aggregator = aggregator;
            this.regionManager = regionManager;
            this.aggregator.GetEvent<UIOperationEvent>().Subscribe(OperationUI, ThreadOption.UIThread);
            this.backCommand = new DelegateCommand<string>(this.NavigationTo);
            this.voiceServiceFactory = voiceServiceFactory;
        }

        private void NavigationTo(string to)
        {
            this.regionManager.RequestNavigate("MainContentRegion", new Uri(to, UriKind.Relative));
        }


        private void OperationUI(string operationType)
        {
            if (!string.IsNullOrEmpty(operationType))
            {
                switch (operationType)
                {
                    case Constant.MessageScreenName:
                        NavigationTo(Constant.MessageScreenUrl);
                        break;
                    case Constant.IncidentScreenName:
                        NavigationTo(Constant.IncidentScreenUrl);
                        break;
                    case Constant.BoloScreenName:
                        NavigationTo(Constant.BoloScreenUrl);
                        break;
                    case Constant.QueryScreenName:
                        NavigationTo(Constant.QueryScreenUrl);
                        break;
                    default:
                        break;

                }
            }

        }

        public ICommand StartVoiceCommand
        {
            get
            {
                return new DelegateCommand(
                  new System.Action(StartVoice)
                    );
            }
        }

        private void StartVoice()
        {
            aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "Info", Content = "Info Start listening!" });
            var micClient = voiceServiceFactory.CreateSevice("");
            micClient.StartMicAndRecognition();
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

        private BindableBase selectedViewModel;
        public BindableBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                this.selectedViewModel = value;
                RaisePropertyChanged("SelectedViewModel");
            }
        }

        public ICommand BackCommand
        {
            get { return this.backCommand; }
        }
    }
}
