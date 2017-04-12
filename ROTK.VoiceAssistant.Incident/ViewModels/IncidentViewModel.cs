using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using System.ComponentModel.Composition;
using System;

namespace ROTK.VoiceAssistant.Incident.ViewModels
{
    [Export]
    public class IncidentViewModel: BindableBase
    { 
        private IEventAggregator aggregator;

        [ImportingConstructor]
        public IncidentViewModel(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;

            this.aggregator.GetEvent<FocusOnLocationEvent>().Subscribe(() => this.LocationFocused = true);
            this.aggregator.GetEvent<FocusOnCityEvent>().Subscribe(() => this.CityFocused = true);
            this.aggregator.GetEvent<FocusOnBuildingEvent>().Subscribe(() => this.BuildingFocused = true);
            this.aggregator.GetEvent<FocusOnIncidentTypeEvent>().Subscribe(() => this.IncidentTypeFocused = true);
            this.aggregator.GetEvent<FocusOnLicensePlateEvent>().Subscribe(() => this.LicensePlateFocused = true);
            this.aggregator.GetEvent<FocusOnStateEvent>().Subscribe(() => this.StateFocused = true);
            this.aggregator.GetEvent<FocusOnPlateTypeEvent>().Subscribe(() => this.PlateTypeFocused = true);
            this.aggregator.GetEvent<FocusOnPlateYearEvent>().Subscribe(() => this.PlateYearFocused = true);

            this.aggregator.GetEvent<FillIncidentTypeEvent>().Subscribe(SelectIncidentType);
            this.aggregator.GetEvent<FillCityEvent>().Subscribe(SelectCity);
            this.aggregator.GetEvent<FillPlateTypeEvent>().Subscribe(SelectPlateType);
            this.aggregator.GetEvent<FillStateEvent>().Subscribe(SelectState);

            this.aggregator.GetEvent<CreateIncidentEvent>().Subscribe(CreateIncident);
        }

        private string location;
        public string Location
        {
            get { return location; }
            set
            {
                this.location = value;
                RaisePropertyChanged("Location");
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                this.city = value;
                RaisePropertyChanged("City");
            }
        }

        private string building;
        public string Building
        {
            get { return building; }
            set
            {
                this.building = value;
                RaisePropertyChanged("Building");
            }
        }

        private string incidentType;
        public string IncidentType
        {
            get { return incidentType; }
            set
            {
                this.incidentType = value;
                RaisePropertyChanged("IncidentType");
            }
        }

        private string licensePlate;
        public string LicensePlate
        {
            get { return licensePlate; }
            set
            {
                this.licensePlate = value;
                RaisePropertyChanged("LicensePlate");
            }
        }

        private string state;
        public string State
        {
            get { return state; }
            set
            {
                this.state = value;
                RaisePropertyChanged("State");
            }
        }

        private string plateType;
        public string PlateType
        {
            get { return plateType; }
            set
            {
                this.plateType = value;
                RaisePropertyChanged("PlateType");
            }
        }

        private string plateYear;
        public string PlateYear
        {
            get { return plateYear; }
            set
            {
                this.plateYear = value;
                RaisePropertyChanged("PlateYear");
            }
        }

        private string create;
        public string Create
        {
            get { return create; }
            set
            {
                this.create = value;
                RaisePropertyChanged("Create");
            }
        }


        private bool locationFocused;
        public bool LocationFocused
        {
            get { return locationFocused; }
            set
            {
                this.locationFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool cityFocused;
        public bool CityFocused
        {
            get { return cityFocused; }
            set
            {
                this.cityFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool buildingFocused;
        public bool BuildingFocused
        {
            get { return buildingFocused; }
            set
            {
                this.buildingFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool incidentTypeFocused;
        public bool IncidentTypeFocused
        {
            get { return incidentTypeFocused; }
            set
            {
                this.incidentTypeFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool licensePlateFocused;
        public bool LicensePlateFocused
        {
            get { return licensePlateFocused; }
            set
            {
                this.licensePlateFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool stateFocused;
        public bool StateFocused
        {
            get { return stateFocused; }
            set
            {
                this.stateFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool plateTypeFocused;
        public bool PlateTypeFocused
        {
            get { return plateTypeFocused; }
            set
            {
                this.plateTypeFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private bool plateYearFocused;
        public bool PlateYearFocused
        {
            get { return plateYearFocused; }
            set
            {
                this.plateYearFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }

        private void SelectCity(string city)
        {
            this.City = city;
        }

        private void SelectIncidentType(string incidentType)
        {

        }

        private void SelectPlateType(string plateType)
        {

        }

        private void SelectState(string state)
        {

        }

        private void CreateIncident()
        {
            
        }
    }
}
