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
using System.Windows;
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

        private void NavigationTo(string to, NavigationParameters parameters= null)
        {
            aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "Navigation", Content = string.Format("Enter in {0}", to)});

            this.regionManager.RequestNavigate("MainContentRegion", new Uri(to+parameters.ToString(), UriKind.Relative));

            if (to.Equals("\\MainNavigationView"))
                VisibleFlag = Visibility.Collapsed;
            else
                VisibleFlag = Visibility.Visible;
        }

        private void NavigationTo(string to)
        {
            aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "Navigation", Content = string.Format("Enter in {0}", to) });

            this.regionManager.RequestNavigate("MainContentRegion", new Uri(to, UriKind.Relative));

            if (to.Equals("\\MainNavigationView"))
                VisibleFlag = Visibility.Collapsed;
            else
                VisibleFlag = Visibility.Visible;
        }


        private void OperationUI(KeyValuePair<string,List<Entity>> keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue.Key))
            {
                var parameters = new NavigationParameters();
                foreach(var entity in keyValue.Value)
                {
                    parameters.Add(entity.Name, entity.Value);
                }
                NavigationTo(keyValue.Key, parameters);
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
            aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "VoiceButton", Content = "Voice Button Clicked" });
            var micClient = voiceServiceFactory.CreateSevice(currentView.Replace("/", "").Replace("\\", ""));
            micClient.StartMicAndRecognition();
        }


        private bool isVoiceButtonEnabled = true;
        public bool IsVoiceButtonEnabled
        {
            get { return isVoiceButtonEnabled; }
            set
            {
                this.isVoiceButtonEnabled = value;
                RaisePropertyChanged("IsVoiceButtonEnable");
            }
        }

        private Visibility visibleFlag = Visibility.Collapsed;
        public Visibility VisibleFlag
        {
            get { return visibleFlag; }
            set
            {
                this.visibleFlag = value;
                RaisePropertyChanged("VisibleFlag");
            }
        }

        public ICommand BackCommand
        {
            get { return this.backCommand; }
        }
    }
}
