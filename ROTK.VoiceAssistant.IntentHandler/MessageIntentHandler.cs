﻿using ROTK.VoiceAssistant.LUISClientLibrary;

namespace ROTK.VoiceAssistant.IntentHandler
{
    public class MessageIntentHandler
    {
        // 0.65 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0.65, Name = "SendMessageActivity")]
        public static void SendMessageActivity(LuisResult result, object context)
        {
        }

        [IntentHandler(0.65, Name = "CreateIncidentActivity")]
        public static void CreateIncidentActivity(LuisResult result, object context)
        {

        }

        [IntentHandler(0.65, Name = "ViewIncidentActivity")]
        public static void ViewIncidentActivity(LuisResult result, object context)
        {

        }

        [IntentHandler(0.7, Name = "None")]
        public static void None(LuisResult result, object context)
        {

        }
    }
}