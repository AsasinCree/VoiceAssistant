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
        public static EventAggregator Aggregator;

        // 0.65 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0.65, Name = Constant.OpenScreenActivityIntent)]
        public static void OpenScreenActivity(LuisResult result, object context)
        {
            if (result.TopScoringIntent.Name.Equals(Constant.OpenScreenActivityIntent, StringComparison.CurrentCultureIgnoreCase))
            {
                List<Entity> entitis = result.GetAllEntities();

                if (entitis != null && entitis.Count > 0)
                {
                    foreach (Entity entity in entitis)
                    {
                        if (entity.Name.Equals(Constant.OperationTypeEntity, StringComparison.CurrentCultureIgnoreCase))
                        {
                            Aggregator.GetEvent<UIOperationEvent>().Publish(entity.Value);
                            break;
                        }
                    }
                }
            }
        }

        [IntentHandler(0.7, Name = Constant.NoneIntent)]
        public static void None(LuisResult result, object context)
        {
            // Nothing to do.
        }
    }
}
