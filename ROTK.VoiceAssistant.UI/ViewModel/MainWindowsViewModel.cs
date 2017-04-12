using Microsoft.CognitiveServices.SpeechRecognition;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
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
    public class MainWindowsViewModel : BindableBase, IPartImportsSatisfiedNotification
    {
    
        IEventAggregator aggregator;

        IVoiceServiceFactory voiceServiceFactory;
        private readonly IRegionManager regionManager;
        private readonly IModuleManager moduleManager;
        private ICommand backCommand;
        private string currentView = Constant.MainNavigationViewUrl;

        [ImportingConstructor]
        public MainWindowsViewModel(IEventAggregator aggregator, IRegionManager regionManager, IVoiceServiceFactory voiceServiceFactory, IModuleManager moduleManager)
        {
            this.aggregator = aggregator;
            this.regionManager = regionManager;
            this.aggregator.GetEvent<UIOperationEvent>().Subscribe(OperationUI, ThreadOption.UIThread);
            this.backCommand = new DelegateCommand<string>(this.NavigationTo);
            this.voiceServiceFactory = voiceServiceFactory;
            this.moduleManager = moduleManager;
            var micClient = voiceServiceFactory.CreateSevice(currentView.Replace("/", "").Replace("\\", ""));
            micClient.VoiceClient.OnMicrophoneStatus += VoiceClient_OnMicrophoneStatus;
        }

        private void VoiceClient_OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {
            this.IsVoiceButtonEnabled = !e.Recording;
        }

        public void OnImportsSatisfied()
        {
            this.moduleManager.LoadModuleCompleted +=
               (s, e) =>
               {
                   if (e.ModuleInfo.ModuleName == "NavigationModule")
                   {
                       this.regionManager.Regions["MainContentRegion"].NavigationService.Navigated += NavigationService_Navigated;
                   }
               };
        }

        private void NavigationService_Navigated(object sender, RegionNavigationEventArgs e)
        {
            currentView = e.Uri.ToString();
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
            var micClient = voiceServiceFactory.CreateSevice(currentView.Replace("/", "").Replace("\\", ""));
            micClient.StartMicAndRecognition();
        }


        private bool isVoiceButtonEnabled=true;
        public bool IsVoiceButtonEnabled
        {
            get { return isVoiceButtonEnabled; }
            set
            {
                this.isVoiceButtonEnabled = value;
                RaisePropertyChanged("IsVoiceButtonEnable");
            }
        }

        public ICommand BackCommand
        {
            get { return this.backCommand; }
        }
    }
}
