using Prism.Events;
using Prism.Mef;
using ROTK.VoiceAssistant.IntentHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ROTK.VoiceAssistant.UI
{
    public class Bootstrapper: MefBootstrapper
    {
        //public static readonly EventAggregator EventAggregatorInstant = new EventAggregator();

        //static Bootstrapper()
        //{
        //    UIOperationIntentHandler.Aggregator = EventAggregatorInstant;
        //}

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

        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }
    }
}
