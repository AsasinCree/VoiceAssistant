using Microsoft.CognitiveServices.SpeechRecognition;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ROTK.VoiceAssistant.UI.ViewModel
{
    public class MainWindowsViewModel : BindableBase
    {
        IEventAggregator ea;

       public string Title { get; set; }

        #region Configuration Properties
        private string subscriptionKey;
        /// <summary>
        /// Gets or sets subscription key
        /// </summary>
        public string SubscriptionKey
        {
            get
            {
                return this.subscriptionKey;
            }

            set
            {
                this.subscriptionKey = value;

            }
        }

        /// <summary>
        /// Gets the LUIS application identifier.
        /// </summary>
        /// <value>
        /// The LUIS application identifier.
        /// </value>
        private string LuisAppId
        {
            get { return ConfigurationManager.AppSettings["luisAppID"]; }
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
        
        private readonly MicrophoneRecognitionClient micClient;

        public MainWindowsViewModel(IEventAggregator ea)
        {
            this.ea = ea;
            this.ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
            //this.micClient =
            //   SpeechRecognitionServiceFactory.CreateMicrophoneClientWithIntent(
            //   this.DefaultLocale,
            //   this.SubscriptionKey,
            //   this.LuisAppId,
            //   this.LuisSubscriptionID);
            //this.micClient.AuthenticationUri = this.AuthenticationUri;
        }


        private void MessageReceived(Message message)

        {

        }

        public ICommand StartVoiceCommand
        {
            get
            {
                return new DelegateCommand(
                  new Action(StartVoice)
                    );
            }
        }

        private void StartVoice()
        {

        }

    }
}
