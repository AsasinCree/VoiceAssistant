using ROTK.VoiceAssistant.LUISClientLibrary;
using System.Collections.Generic;
using System;

namespace ROTK.VoiceAssistant.IntentHandler
{
    public class UIOperationIntentHandler
    {
        // 0.65 is the confidence score required by this intent in order to be activated
        // Only picks out a single entity value
        [IntentHandler(0.65, Name = "OpenScreenActivity")]
        public static void OpenScreenActivity(LuisResult result, object context)
        {
            List<Entity> entitis = result.GetAllEntities();
            
            if (entitis != null && entitis.Count > 0)
            {
                Entity entity = entitis[0];
                if(entity.Name.Equals("OperationType", StringComparison.OrdinalIgnoreCase))
                { 
                    switch (entity.Value)
                    {
                        case OperationType.Message:
                            System.Console.WriteLine("");
                            break;

                        case OperationType.Incident:
                            System.Console.WriteLine("");
                            break;

                        case OperationType.Bolo:
                            System.Console.WriteLine("");
                            break;

                        case OperationType.Query:
                            System.Console.WriteLine("");
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        [IntentHandler(0.7, Name = "None")]
        public static void None(LuisResult result, object context)
        {

        }
    }
}
