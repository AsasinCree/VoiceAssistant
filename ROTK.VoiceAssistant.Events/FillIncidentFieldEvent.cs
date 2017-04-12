using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.Events
{
    public class FillIncidentTypeEvent:PubSubEvent<string>
    {

    }

    public class FillCityEvent : PubSubEvent<string>
    {

    }

    public class FillPlateTypeEvent : PubSubEvent<string>
    {

    }

    public class FillStateEvent : PubSubEvent<string>
    {

    }
}
