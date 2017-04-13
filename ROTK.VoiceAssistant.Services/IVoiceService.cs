using Microsoft.CognitiveServices.SpeechRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.Services
{
    public interface IVoiceService
    {
        MicrophoneRecognitionClient VoiceClient { get; }
        void StartMicAndRecognition();
    }
}
