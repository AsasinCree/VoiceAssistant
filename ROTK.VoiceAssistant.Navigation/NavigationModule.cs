using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using ROTK.VoiceAssistant.Navigation.Views;
using System;
using System.ComponentModel.Composition;

namespace ROTK.VoiceAssistant.Navigation
{
    [ModuleExport(typeof(NavigationModule))]
    public class NavigationModule : IModule
    {
        [Import]
        public IRegionManager regionManager;

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("MainContentRegion", typeof(MainNavigationView));
        }
    }
}