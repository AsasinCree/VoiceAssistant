using ROTK.VoiceAssistant.LUISClientLibrary;
using System.Collections.Generic;
using System;
using Prism.Events;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;

namespace ROTK.VoiceAssistant.IntentHandler
{
    public class UIOperationIntentHandler
    {
        public static IEventAggregator Aggregator;

        // 0.65 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0.3, Name = Constant.OpenMessageActivity)]
        public static void OpenMessageActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();

            Aggregator.GetEvent<UIOperationEvent>().Publish(new KeyValuePair<string, List<Entity>>(Constant.MessageScreenUrl, entitis));

        }

        [IntentHandler(0.3, Name = Constant.OpenIncidentActivity)]
        public static void OpenIncidentActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();

            Aggregator.GetEvent<UIOperationEvent>().Publish(new KeyValuePair<string, List<Entity>>(Constant.IncidentScreenUrl, entitis));
        }

        [IntentHandler(0.1, Name = Constant.NoneIntent)]
        public static void None(LuisResult result, object context)
        {
            Aggregator.GetEvent<NoneEvent>().Publish(result.OriginalQuery);
        }
    }
}
