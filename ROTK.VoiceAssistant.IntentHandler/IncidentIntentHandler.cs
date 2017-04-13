using Prism.Events;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.LUISClientLibrary;
using ROTK.VoiceAssistant.Model;
using System;
using System.Collections.Generic;

namespace ROTK.VoiceAssistant.IntentHandler
{
    public class IncidentIntentHandler
    {
        public static IEventAggregator Aggregator;

        [IntentHandler(0, Name = Constant.FillCityActivityIntent)]
        public static void FillCityActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();

            if (entitis != null && entitis.Count > 0)
            {
                foreach (Entity entity in entitis)
                {
                    if (entity.Name.Contains(Constant.GeographyEntity))
                    {
                        Aggregator.GetEvent<FillCityEvent>().Publish(entity.Value);
                    }
                }
            }
        }

        [IntentHandler(0, Name = Constant.FillIncidentTypeActivityIntent)]
        public static void FillIncidentTypeActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();

            if (entitis != null && entitis.Count > 0)
            {
                foreach (Entity entity in entitis)
                {
                    if (entity.Name.Equals(Constant.IncidentTypeEntity, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Aggregator.GetEvent<FillIncidentTypeEvent>().Publish(entity.Value);
                    }
                }
            }
        }

        [IntentHandler(0, Name = Constant.FillPlateTypeActivityIntent)]
        public static void FillPlateTypeActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();

            if (entitis != null && entitis.Count > 0)
            {
                foreach (Entity entity in entitis)
                {
                    if (entity.Name.Equals(Constant.PlateTypeEntity, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Aggregator.GetEvent<FillPlateTypeEvent>().Publish(entity.Value);
                    }
                }
            }
        }

        [IntentHandler(0, Name = Constant.FillStateActivityIntent)]
        public static void FillStateActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();

            if (entitis != null && entitis.Count > 0)
            {
                foreach (Entity entity in entitis)
                {
                    if (entity.Name.Equals(Constant.StateEntity, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Aggregator.GetEvent<FillStateEvent>().Publish(entity.Value);
                    }
                }
            }
        }

        [IntentHandler(0, Name = Constant.CreateIncidentActivityIntent)]
        public static void CreateIncidentActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<CreateIncidentEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.BackToHomeActivity)]
        public static void BackToHomeActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<BackToHomeEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.NoneIntent)]
        public static void None(LuisResult result, object context)
        {
            // Nothing to do.
        }
    }
}
