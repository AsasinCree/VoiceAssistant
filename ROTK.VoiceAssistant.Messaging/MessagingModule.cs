using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using ROTK.VoiceAssistant.Messaging.Views;
using System;
using System.ComponentModel.Composition;

namespace ROTK.VoiceAssistant.Messaging
{
    [ModuleExport(typeof(MessagingModule))]
    public class MessagingModule : IModule
    {

        [Import]
        public IRegionManager regionManager;


        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("MainContentRegion", typeof(MessagingView));
        }
    }
}