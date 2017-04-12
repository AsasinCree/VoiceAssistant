using Prism.Modularity;
using Prism.Regions;
using System;

namespace ROTK.VoiceAssistant.Incident
{
    public class IncidentModule : IModule
    {
        IRegionManager _regionManager;

        public IncidentModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}