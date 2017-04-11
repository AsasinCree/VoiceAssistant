using ROTK.VoiceAssistant.LUISClientLibrary;
using System.Collections.Generic;
using System;
using Prism.Events;
using ROTK.VoiceAssistant.Events;

namespace ROTK.VoiceAssistant.IntentHandler
{
    public class UIOperationIntentHandler
    {
        public static EventAggregator Aggregator;

        // 0.65 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0.65, Name = "OpenScreenActivity")]
        public static void OpenScreenActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();
            
            if (entitis != null && entitis.Count > 0)
            {
                Entity entity = entitis[0];
                Aggregator.GetEvent<UIOperationEvent>().Publish(entity.Value);
            }
        }

        [IntentHandler(0.7, Name = "None")]
        public static void None(LuisResult result, object context)
        {

        }
    }
}
