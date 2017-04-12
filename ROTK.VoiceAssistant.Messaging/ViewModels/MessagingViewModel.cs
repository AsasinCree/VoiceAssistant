using Microsoft.CognitiveServices.SpeechRecognition;
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

        private IVoiceService micClient;
        private IVoiceServiceFactory voiceServiceFactory;
        private MicrophoneRecognitionClient voiceClient;

        private bool IsRegistered = false;

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
        private string MessageApplicationLuisAppID
        {
            get { return ConfigurationManager.AppSettings["MessageApplicationLuisAppID"]; }
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

        [ImportingConstructor]
        public MessagingViewModel(IEventAggregator aggregator, IVoiceServiceFactory voiceServiceFactory)
        {
            this.aggregator = aggregator;
            this.voiceServiceFactory = voiceServiceFactory;
            this.aggregator.GetEvent<MessageSentEvent>().Subscribe(SendMessageOperation, ThreadOption.UIThread);
            this.aggregator.GetEvent<FillMessageFieldEvent>().Subscribe(FillMessageFieldOperation, ThreadOption.UIThread);
            this.aggregator.GetEvent<MessageMisClientEvent>().Subscribe(ReceiveMicClient);
            micClient = voiceServiceFactory.CreateSevice(ROTK.VoiceAssistant.Model.Constant.MessageScreen);
            micClient.StartMicAndRecognition();
            voiceClient = micClient.VoiceClient;
            // Event handlers for speech recognition results
            voiceClient.OnMicrophoneStatus += this.OnMicrophoneStatus;
            voiceClient.OnResponseReceived += this.OnMicShortPhraseResponseReceivedHandler;
        }

        #region MocelView

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

        public ICommand SendMessage
        {
            get { return new DelegateCommand(() => this.Title = "Test"); }
        }

        public void ReceiveMicClient(MicrophoneRecognitionClient client)
        {
          
            micClient.StartMicAndRecognition();
        }


        public void SendMessageOperation()
        {
            MessageBox.Show("To:\t" + To + "\n"
                          + "Subject:\t" + Title + "\n"
                          + "Content:\t" + content + "\n"
                          + "\n\n\n" + "Send message successful");
        }

        public void FillMessageFieldOperation(string fieldType)
        {
            if (fieldType.Equals(Constant.MessageConstant.AddressField) || fieldType.Equals(Constant.MessageConstant.ToField))
            {
                ToIsFocused = true;
            }
            else if (fieldType.Equals(Constant.MessageConstant.TitleField) || fieldType.Equals(Constant.MessageConstant.SubjectField))
            {
                SubjectIsFocused = true;
            }
            else if (fieldType.Equals(Constant.MessageConstant.ContentField))
            {
                ContentIsFocused = true;
            }
            else
            {

            }
            if(JudgeFocus())
            {
                micClient.EnableIntent = false;
            }
        }

        private bool JudgeFocus()
        {
            if (ToIsFocused || SubjectIsFocused || ContentIsFocused)
            {
                return true;
            }
            return false;
        }

        private void ClearFocus()
        {
            ToIsFocused = false;
            SubjectIsFocused = false;
            ContentIsFocused = false;
        }

        private void OnMicShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            RecognitionResult result = e.PhraseResponse;
            if (JudgeFocus())
            {
                if (ToIsFocused)
                {
                    StringBuilder toBuilder = new StringBuilder();
                    for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                    {
                        toBuilder.Append(e.PhraseResponse.Results[i].DisplayText);

                    }
                    To = To + toBuilder.ToString();
                }
                else if (SubjectIsFocused)
                {
                    StringBuilder subjectBuilder = new StringBuilder();
                    for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                    {
                        subjectBuilder.Append(e.PhraseResponse.Results[i].DisplayText);

                    }
                    Title = Title + subjectBuilder.ToString();
                }
                else if (ContentIsFocused)
                {
                    StringBuilder contentBuilder = new StringBuilder();
                    for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                    {
                        contentBuilder.Append(e.PhraseResponse.Results[i].DisplayText);

                    }
                    Content = Content + contentBuilder.ToString();
                }
                else
                {

                }
            }
            ClearFocus();
            micClient.EnableIntent = true;
        }

        private void OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {
            if(e.Recording)
            {
                return;
            }
            else
            {
                micClient.StartMicAndRecognition();
            }
        }
    }
}
