using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Microsoft.CognitiveServices.SpeechRecognition;
using ROTK.VoiceAssistant.LUISClientLibrary;
using ROTK.VoiceAssistant.IntentHandler;
using Newtonsoft.Json.Linq;

namespace ROTK.VoiceAssistant.Messaging.ViewModel
{
    [Export]
    public class MessagingViewModel: BindableBase
    {
        
        private IEventAggregator aggregator;

        private MicrophoneRecognitionClient micClient;

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
        public MessagingViewModel(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;

            this.aggregator.GetEvent<MessageSentEvent>().Subscribe(SendMessageOperation, ThreadOption.UIThread);
            this.aggregator.GetEvent<FillMessageFieldEvent>().Subscribe(FillMessageFieldOperation, ThreadOption.UIThread);
            this.aggregator.GetEvent<MessageMisClientEvent>().Subscribe(ReceiveMicClient);
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
            if(!IsRegistered)
            { 
                this.micClient = client;
                this.micClient.OnIntent += this.OnIntentHandler;
                // Event handlers for speech recognition results
                this.micClient.OnMicrophoneStatus += this.OnMicrophoneStatus;
                this.micClient.OnPartialResponseReceived += this.OnPartialResponseReceivedHandler;
                this.micClient.OnResponseReceived += this.OnMicShortPhraseResponseReceivedHandler;
                this.micClient.OnConversationError += this.OnConversationErrorHandler;
                IsRegistered = true;
            }
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

        private void OnIntentHandler(object sender, SpeechIntentEventArgs e)
        {
            if (!JudgeFocus())
            {
                MessageIntentHandler.Aggregator = aggregator;
                using (IntentRouter router = IntentRouter.Setup<MessageIntentHandler>())
                {
                    LuisResult result = new LuisResult(JToken.Parse(e.Payload));

                    router.Route(result, this);
                }
            }
            //micClient.StartMicAndRecognition();
        }

        private void OnConversationErrorHandler(object sender, SpeechErrorEventArgs e)
        {

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
                ClearFocus();
                //micClient.StartMicAndRecognition();
            }
        }

        private void OnPartialResponseReceivedHandler(object sender, PartialSpeechResponseEventArgs e)
        {

        }

        private void OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {
            
        }
    }
}
