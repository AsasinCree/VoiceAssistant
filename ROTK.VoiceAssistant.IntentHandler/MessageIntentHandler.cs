using Prism.Events;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.LUISClientLibrary;
using ROTK.VoiceAssistant.Model;
using System.Collections.Generic;

namespace ROTK.VoiceAssistant.IntentHandler
{
    public class MessageIntentHandler
    {
        public static EventAggregator Aggregator;

        // 0.65 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0.65, Name = Constant.SendMessageActivityIntent)]
        public static void SendMessageActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<MessageSentEvent>().Publish();
        }

        [IntentHandler(0.65, Name = Constant.FillMessageFieldActivityIntent)]
        public static void FillMessageFieldActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();
            if (entitis != null && entitis.Count > 0)
            {
                Entity entity = entitis[0];
                Aggregator.GetEvent<FillMessageFieldEvent>().Publish(entity.Value);
            }       
        }

        [IntentHandler(0.7, Name = Constant.NoneIntent)]
        public static void None(LuisResult result, object context)
        {
            // Nothing to do.
        }
    }
}
