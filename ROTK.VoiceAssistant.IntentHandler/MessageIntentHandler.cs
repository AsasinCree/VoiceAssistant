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

        // 0.65 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0.65, Name = Constant.SendMessageActivityIntent)]
        public static void SendMessageActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<MessageSentEvent>().Publish();
        }

        [IntentHandler(0.65, Name = Constant.FocusContentActivityIntent)]
        public static void FocusContentActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FillMessageFieldEvent>().Publish(Constant.ContentField);
        }

        [IntentHandler(0.65, Name = Constant.FocusSubjectActivityIntent)]
        public static void FocusSubjectActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FillMessageFieldEvent>().Publish(Constant.SubjectField);
        }

        [IntentHandler(0.65, Name = Constant.FocusAddressActivityIntent)]
        public static void FocusToActivity(LuisResult result, object context)
        {
            Aggregator.GetEvent<FillMessageFieldEvent>().Publish(Constant.AddressField);
        }

        [IntentHandler(0.7, Name = Constant.NoneIntent)]
        public static void None(LuisResult result, object context)
        {
            // Nothing to do.
        }
    }
}
