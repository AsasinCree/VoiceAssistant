using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
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
        private readonly IRegionManager regionManager;

        private ICommand navigationCommand;
        [ImportingConstructor]
        public MainNavigationViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            this.navigationCommand = new DelegateCommand<string>(this.NavigationTo);
        }

        private void NavigationTo(string to)
        {
            this.regionManager.RequestNavigate("MainContentRegion", new Uri(to, UriKind.Relative));
        }

        public ICommand NavigationCommand
        {
            get { return this.navigationCommand; }
        }
    }
}
