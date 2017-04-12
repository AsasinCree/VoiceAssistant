using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using ROTK.VoiceAssistant.Log.Views;
using System;
using System.ComponentModel.Composition;

namespace ROTK.VoiceAssistant.Log
{
    [ModuleExport(typeof(LogModule))]
    public class LogModule : IModule
    {
        [Import]
        IRegionManager regionManager;
        
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("MainContentRegion", typeof(LogView));
        }
    }
}