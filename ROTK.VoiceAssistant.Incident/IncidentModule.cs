using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using ROTK.VoiceAssistant.Incident.Views;
using System;
using System.ComponentModel.Composition;

namespace ROTK.VoiceAssistant.Incident
{
    [ModuleExport(typeof(IncidentModule))]
    public class IncidentModule : IModule
    {
        [Import]
        public IRegionManager regionManager;

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("MainContentRegion", typeof(IncidentView));
        }
    }
}