using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;
using System;
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

            //aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "Info", Content = "Enter in Incident View!" });
            //this.aggregator.GetEvent<MessageSentEvent>().Subscribe(SendMessageOperation);
            //this.aggregator.GetEvent<FillMessageFieldEvent>().Subscribe(FillMessageFieldOperation);
        }
    }
}
