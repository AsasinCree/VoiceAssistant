using Microsoft.CognitiveServices.SpeechRecognition;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ROTK.VoiceAssistant.Events
{

    public class MessageSentEvent : PubSubEvent
    {
        public void Subscribe(ICommand sendMessage, ThreadOption uIThread)
        {
            throw new NotImplementedException();
        }
    }

}
