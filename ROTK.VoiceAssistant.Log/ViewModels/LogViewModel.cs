using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.Log.ViewModels
{
    [Export]
    public class LogViewModel : BindableBase
    {
        private IEventAggregator aggregator;

        [ImportingConstructor]
        public LogViewModel(IEventAggregator aggregator)
        {
            logList = new ObservableCollection<LogModel>();
            this.aggregator = aggregator;
            this.aggregator.GetEvent<LogSentEvent>().Subscribe(BindingLog);

            //aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "Info", Content = "Enter in Log View!" });
        }

        private void BindingLog(LogModel log)
        {
            LogList.Add(log);
        }

        private ObservableCollection<LogModel> logList;
        public ObservableCollection<LogModel> LogList
        {
            get { return logList; }
            set
            {
                this.logList = value;
                RaisePropertyChanged("LogList");
            }
        }

    }
}
