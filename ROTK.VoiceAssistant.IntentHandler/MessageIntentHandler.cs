using Prism.Events;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.LUISClientLibrary;
using ROTK.VoiceAssistant.Model;
using System.Collections.Generic;

namespace ROTK.VoiceAssistant.IntentHandler
{
    public class MessageIntentHandler
    {
        public static IEventAggregator Aggregator;

        // 0 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0, Name = Constant.SendMessageActivityIntent)]
        public static void SendMessageActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<MessageSentEvent>().Publish();
        }

        // 0 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0, Name = Constant.BackToHomeActivity)]
        public static void BackToHomeActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<BackToHomeEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FillToActivityActivityIntent)]
        public static void FillToActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();

            if (entitis != null && entitis.Count > 0)
            {
                foreach (Entity entity in entitis)
                {
                    if (entity.Name.Contains(Constant.GeographyEntity) || entity.Name.Equals(Constant.NameEntity, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        Aggregator.GetEvent<FillToFieldEvent>().Publish(entity.Value);
                    }
                }
            }
        }

        [IntentHandler(0.1, Name = Constant.NoneIntent)]
        public static void None(LuisResult result, object context)
        {
            Aggregator.GetEvent<NoneEvent>().Publish(result.OriginalQuery);
        }
    }
}
