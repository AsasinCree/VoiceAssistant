using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.Model
{
    public class LogModel
    {
        public LogModel()
        { }

        public string Content
        {
            get; set;
        }

        public string Level
        {
            get; set;
        }

        public DateTime Time
        {
            get; set;
        }
    }
}
