using Prism.Events;
using ROTK.VoiceAssistant.IntentHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.UI
{
    public class Bootstrapper
    {
        public static readonly EventAggregator EventAggregatorInstant = new EventAggregator();

        static Bootstrapper()
        {
            UIOperationIntentHandler.Aggregator = EventAggregatorInstant;
        }
    }
}
