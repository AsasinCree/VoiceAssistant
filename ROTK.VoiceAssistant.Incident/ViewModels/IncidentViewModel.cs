using Prism.Events;
using Prism.Mvvm;
using System.ComponentModel.Composition;

namespace ROTK.VoiceAssistant.Incident.ViewModels
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
