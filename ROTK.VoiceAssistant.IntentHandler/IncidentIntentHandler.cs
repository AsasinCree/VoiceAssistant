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

        // 0 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0, Name = Constant.FocusOnLocationActivityIntent)]
        public static void FocusOnLocationActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnLocationEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FocusOnCityActivityIntent)]
        public static void FocusOnCityActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnCityEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FocusOnBuildingActivityIntent)]
        public static void FocusOnBuildingActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnBuildingEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FocusOnIncidentTypeActivityIntent)]
        public static void FocusOnIncidentTypeActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnIncidentTypeEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FocusOnLicensePlateActivityIntent)]
        public static void FocusOnLicensePlateActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnLicensePlateEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FocusOnStateActivityIntent)]
        public static void FocusOnStateActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnStateEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FocusOnPlateTypeActivityIntent)]
        public static void FocusOnPlateTypeActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnPlateTypeEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.FocusOnPlateYearActivityIntent)]
        public static void FocusOnPlateYearActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FocusOnPlateYearEvent>().Publish();
        }

        [IntentHandler(0, Name = Constant.CreateIncidentActivityIntent)]
        public static void CreateIncidentActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<CreateIncidentEvent>().Publish();
        }

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

        [IntentHandler(0, Name = Constant.NoneIntent)]
        public static void None(LuisResult result, object context)
        {
            // Nothing to do.
        }
    }
}
