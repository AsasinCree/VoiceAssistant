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

        #region Configuration Properties

        /// <summary>
        /// Gets or sets subscription key
        /// </summary>
        public string SpeechKey
        {
            get { return ConfigurationManager.AppSettings["SpeechKey"]; }
        }

        /// <summary>
        /// Gets the LUIS subscription identifier.
        /// </summary>
        /// <value>
        /// The LUIS subscription identifier.
        /// </value>
        private string LuisSubscriptionID
        {
            get { return ConfigurationManager.AppSettings["luisSubscriptionID"]; }
        }

        /// <summary>
        /// Gets the LUIS application identifier.
        /// </summary>
        /// <value>
        /// The LUIS application identifier.
        /// </value>
        private string UIOperationLuisAppId
        {
            get { return ConfigurationManager.AppSettings["UIOperationLuisAppID"]; }
        }

        /// <summary>
        /// Gets the default locale.
        /// </summary>
        /// <value>
        /// The default locale.
        /// </value>
        private string DefaultLocale
        {
            get { return "en-US"; }
        }

        /// <summary>
        /// Gets the Cognitive Service Authentication Uri.
        /// </summary>
        /// <value>
        /// The Cognitive Service Authentication Uri.  Empty if the global default is to be used.
        /// </value>
        private string AuthenticationUri
        {
            get
            {
                return ConfigurationManager.AppSettings["AuthenticationUri"];
            }
        }

        #endregion

        private MicrophoneRecognitionClient micClient;
        
        private readonly IRegionManager regionManager;
        private ICommand backCommand;


        [ImportingConstructor]
        public MainWindowsViewModel(IEventAggregator aggregator, IRegionManager regionManager)
        {
            this.aggregator = aggregator;
            this.regionManager = regionManager;
            this.aggregator.GetEvent<UIOperationEvent>().Subscribe(OperationUI, ThreadOption.UIThread);
        }

        private void NavigationTo(string to)
        {
            this.regionManager.RequestNavigate("MainContentRegion", new Uri(to, UriKind.Relative));
        }


        private void OperationUI(string operationType)
        {
            if(!string.IsNullOrEmpty(operationType))
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
            CreateMicrophoneRecoClientWithIntent();

            micClient.StartMicAndRecognition();
        }

        private void CreateMicrophoneRecoClientWithIntent()
        {
            this.micClient =
                SpeechRecognitionServiceFactory.CreateMicrophoneClientWithIntent(
                this.DefaultLocale,
                this.SpeechKey,
                this.UIOperationLuisAppId,
                this.LuisSubscriptionID);
            this.micClient.AuthenticationUri = this.AuthenticationUri;
            this.micClient.OnIntent += this.OnIntentHandler;

            // Event handlers for speech recognition results
            this.micClient.OnMicrophoneStatus += this.OnMicrophoneStatus;
            this.micClient.OnPartialResponseReceived += this.OnPartialResponseReceivedHandler;
            this.micClient.OnResponseReceived += this.OnMicShortPhraseResponseReceivedHandler;
            this.micClient.OnConversationError += this.OnConversationErrorHandler;
        }


        private void OnIntentHandler(object sender, SpeechIntentEventArgs e)
        {
            UIOperationIntentHandler.Aggregator = this.aggregator;
            using (IntentRouter router = IntentRouter.Setup<UIOperationIntentHandler>())
            {
                LuisResult result = new LuisResult(JToken.Parse(e.Payload));

                router.Route(result, this);
            }
        }

        private void OnConversationErrorHandler(object sender, SpeechErrorEventArgs e)
        {

        }

        private void OnMicShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {

        }

        private void OnPartialResponseReceivedHandler(object sender, PartialSpeechResponseEventArgs e)
        {

        }

        private void OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {

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
        
        private void NavigationTo(string to)
        {
            this.regionManager.RequestNavigate("MainContentRegion", new Uri(to, UriKind.Relative));
        }

        public ICommand BackCommand
        {
            get { return this.backCommand; }
        }
    }
}
