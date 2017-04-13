using Microsoft.CognitiveServices.SpeechRecognition;
using Newtonsoft.Json.Linq;
using Prism.Events;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.IntentHandler;
using ROTK.VoiceAssistant.LUISClientLibrary;
using ROTK.VoiceAssistant.Model;
using ROTK.VoiceAssistant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.UI.Services
{
    public class VoiceService<T> : IVoiceService
    {
        private IEventAggregator aggregator;

        private MicrophoneRecognitionClient micClient;

        public MicrophoneRecognitionClient VoiceClient
        {
            get
            {
                return micClient;
            }
        }
        
        public VoiceService(string DefaultLocale, string SpeechKey, string UIOperationLuisAppId, string LuisSubscriptionID, IEventAggregator aggregator)
        {
            this.micClient =
              SpeechRecognitionServiceFactory.CreateMicrophoneClientWithIntent(
              DefaultLocale,
              SpeechKey,
              UIOperationLuisAppId,
              LuisSubscriptionID);

            this.micClient.OnIntent += this.OnIntentHandler;
            this.micClient.OnConversationError += VoiceClient_OnConversationError;
            this.micClient.OnResponseReceived += VoiceClient_OnResponseReceived;
            this.micClient.OnMicrophoneStatus += VoiceClient_OnMicrophoneStatus;
            this.aggregator = aggregator;
        }

        private void VoiceClient_OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {
            aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "VoiceClient", Content = string.Format("Voice Client Recording is {0}", e.Recording) });
        }

        private void VoiceClient_OnResponseReceived(object sender, SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.Results.Count() > 0)
            {
                aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "VoiceClient", Content = e.PhraseResponse.Results.First().DisplayText });
            }

            micClient.EndMicAndRecognition();
        }

        private void VoiceClient_OnConversationError(object sender, SpeechErrorEventArgs e)
        {
            aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "VoiceClient", Content = string.Format("Enter in {0}", e.SpeechErrorText) });

        }

        private void OnIntentHandler(object sender, SpeechIntentEventArgs e)
        {
            using (IntentRouter router = IntentRouter.Setup<T>())
            {
                LuisResult result = new LuisResult(JToken.Parse(e.Payload));

                router.Route(result, this);
            }
        }

        public void StartMicAndRecognition()
        {
            micClient.StartMicAndRecognition();
        }
    }
}
