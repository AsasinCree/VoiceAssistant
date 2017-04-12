using Prism.Events;
using ROTK.VoiceAssistant.IntentHandler;
using ROTK.VoiceAssistant.Model;
using ROTK.VoiceAssistant.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.UI.Services
{
    [Export(typeof(IVoiceServiceFactory)), PartCreationPolicy(CreationPolicy.Shared)]
    public class VoiceServiceFactory : IVoiceServiceFactory
    {
        private readonly Dictionary<string, IVoiceService> serviceCache = new Dictionary<string, IVoiceService>();

        #region Configuration Properties

        /// <summary>
        /// Gets or sets subscription key
        /// </summary>
        public string SpeechKey
        {
            get { return ConfigurationManager.AppSettings["SpeechKey"]; }
        }

        /// <summary>
        /// Gets the LUIS subscription identifier.
        /// </summary>
        /// <value>
        /// The LUIS subscription identifier.
        /// </value>
        private string LuisSubscriptionID
        {
            get { return ConfigurationManager.AppSettings["luisSubscriptionID"]; }
        }

        /// <summary>
        /// Gets the LUIS application identifier.
        /// </summary>
        /// <value>
        /// The LUIS application identifier.
        /// </value>
        private string UIOperationLuisAppId
        {
            get { return ConfigurationManager.AppSettings["UIOperationLuisAppID"]; }
        }

        private string MessageApplicationLuisAppID
        {
            get { return ConfigurationManager.AppSettings["MessageApplicationLuisAppID"]; }
        }

        private string IncidentApplicationLuisAppID
        {
            get { return ConfigurationManager.AppSettings["IncidentApplicationLuisAppID"]; }
        }

        /// <summary>
        /// Gets the default locale.
        /// </summary>
        /// <value>
        /// The default locale.
        /// </value>
        private string DefaultLocale
        {
            get { return "en-US"; }
        }

        /// <summary>
        /// Gets the Cognitive Service Authentication Uri.
        /// </summary>
        /// <value>
        /// The Cognitive Service Authentication Uri.  Empty if the global default is to be used.
        /// </value>
        private string AuthenticationUri
        {
            get
            {
                return ConfigurationManager.AppSettings["AuthenticationUri"];
            }
        }

        #endregion

        IEventAggregator aggregator;

        [ImportingConstructor]
        public VoiceServiceFactory(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;
            UIOperationIntentHandler.Aggregator = aggregator;
            MessageIntentHandler.Aggregator = aggregator;
            IncidentIntentHandler.Aggregator = aggregator;
        }

        public IVoiceService CreateSevice(string serviceName)
        {
            if(serviceCache.ContainsKey(serviceName))
            {
                return serviceCache[serviceName];
            }
            else
            {
                IVoiceService service;
                switch (serviceName)
                {
                    case Constant.MessageScreen:
                     service = new VoiceService<MessageIntentHandler>(this.DefaultLocale, this.SpeechKey, this.MessageApplicationLuisAppID, this.LuisSubscriptionID, aggregator);
                        break;
                    case Constant.IncidentScreen:
                        service = new VoiceService<IncidentIntentHandler>(this.DefaultLocale, this.SpeechKey, this.IncidentApplicationLuisAppID, this.LuisSubscriptionID, aggregator);
                        break;
                    case Constant.MainNavigationView:
                    default:
                     service = new VoiceService<UIOperationIntentHandler>(this.DefaultLocale, this.SpeechKey, this.UIOperationLuisAppId, this.LuisSubscriptionID, aggregator);
                        break;

                }
                serviceCache.Add(serviceName, service);
                return service;

            }
        }
    }
}
