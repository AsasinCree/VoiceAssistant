using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ROTK.VoiceAssistant.UI.ViewModel
{
    [Export]
    public class IncidentViewModel: BindableBase
    {
        
        private IEventAggregator aggregator;

        [ImportingConstructor]
        public IncidentViewModel(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;

            //this.aggregator.GetEvent<MessageSentEvent>().Subscribe(SendMessageOperation);
            //this.aggregator.GetEvent<FillMessageFieldEvent>().Subscribe(FillMessageFieldOperation);
        }
    }
}
