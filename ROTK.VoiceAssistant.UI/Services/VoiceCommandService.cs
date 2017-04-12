using Microsoft.CognitiveServices.SpeechRecognition;
using Newtonsoft.Json.Linq;
using ROTK.VoiceAssistant.IntentHandler;
using ROTK.VoiceAssistant.LUISClientLibrary;
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
        private MicrophoneRecognitionClient micClient;

        public VoiceService(string DefaultLocale, string SpeechKey, string UIOperationLuisAppId, string LuisSubscriptionID)
        {
            this.micClient =
              SpeechRecognitionServiceFactory.CreateMicrophoneClientWithIntent(
              DefaultLocale,
              SpeechKey,
              UIOperationLuisAppId,
              LuisSubscriptionID);

            this.micClient.OnIntent += this.OnIntentHandler;
            this.micClient.OnResponseReceived += this.OnMicShortPhraseResponseReceivedHandler;
        }

        private void OnMicShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            micClient.EndMicAndRecognition();
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
