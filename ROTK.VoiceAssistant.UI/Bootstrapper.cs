using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.UI
{
    public class Bootstrapper
    {
       public static readonly EventAggregator EventAggregatorInstant=new EventAggregator();
    }
}
