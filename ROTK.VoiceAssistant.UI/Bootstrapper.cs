using Prism.Events;
using Prism.Mef;
using Prism.Modularity;
using Prism.Regions;
using ROTK.VoiceAssistant.IntentHandler;
using ROTK.VoiceAssistant.UI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ROTK.VoiceAssistant.UI
{
    public class Bootstrapper: MefBootstrapper
    {

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(this.GetType().Assembly));
 

        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (MainWindow)this.Shell;
            Application.Current.MainWindow.Show();

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }



        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }

    }
}
