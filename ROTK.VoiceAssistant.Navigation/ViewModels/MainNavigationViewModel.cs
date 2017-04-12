using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using ROTK.VoiceAssistant.Events;
using ROTK.VoiceAssistant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ROTK.VoiceAssistant.Navigation.ViewModels
{
    [Export]
    public class MainNavigationViewModel : BindableBase
    {
        IEventAggregator aggregator;
        private readonly IRegionManager regionManager;

        private ICommand navigationCommand;
        [ImportingConstructor]
        public MainNavigationViewModel(IEventAggregator aggregator, IRegionManager regionManager)
        {
            this.aggregator = aggregator;
            this.regionManager = regionManager;

            this.navigationCommand = new DelegateCommand<string>(this.NavigationTo);
        }

        private void NavigationTo(string to)
        {
            //aggregator.GetEvent<LogSentEvent>().Publish(new LogModel() { Time = DateTime.Now, Level = "Info", Content = "Enter in " + to.Substring(1, to.Length) });
            this.regionManager.RequestNavigate("MainContentRegion", new Uri(to, UriKind.Relative));
        }

        public ICommand NavigationCommand
        {
            get { return this.navigationCommand; }
        }
    }
}
