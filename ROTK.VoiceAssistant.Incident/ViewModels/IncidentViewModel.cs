using Prism.Events;
using Prism.Mvvm;
using ROTK.VoiceAssistant.Events;
using System.ComponentModel.Composition;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;

namespace ROTK.VoiceAssistant.Incident.ViewModels
{
    [Export]
    public class IncidentViewModel: BindableBase
    { 
        private IEventAggregator aggregator;

        private ObservableCollection<string> cities = new ObservableCollection<string>();

        [ImportingConstructor]
        public IncidentViewModel(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;

            this.aggregator.GetEvent<FocusOnLocationEvent>().Subscribe(() => this.LocationFocused = true, ThreadOption.UIThread);
            this.aggregator.GetEvent<FocusOnCityEvent>().Subscribe(() => this.CityFocused = true, ThreadOption.UIThread);
            this.aggregator.GetEvent<FocusOnBuildingEvent>().Subscribe(() => this.BuildingFocused = true, ThreadOption.UIThread);
            this.aggregator.GetEvent<FocusOnIncidentTypeEvent>().Subscribe(() => this.IncidentTypeFocused = true, ThreadOption.UIThread);
            this.aggregator.GetEvent<FocusOnLicensePlateEvent>().Subscribe(() => this.LicensePlateFocused = true, ThreadOption.UIThread);
            this.aggregator.GetEvent<FocusOnStateEvent>().Subscribe(() => this.StateFocused = true, ThreadOption.UIThread);
            this.aggregator.GetEvent<FocusOnPlateTypeEvent>().Subscribe(() => this.PlateTypeFocused = true, ThreadOption.UIThread);
            this.aggregator.GetEvent<FocusOnPlateYearEvent>().Subscribe(() => this.PlateYearFocused = true, ThreadOption.UIThread);

            this.aggregator.GetEvent<FillIncidentTypeEvent>().Subscribe(SelectIncidentType, ThreadOption.UIThread);
            this.aggregator.GetEvent<FillCityEvent>().Subscribe(SelectCity, ThreadOption.UIThread);
            this.aggregator.GetEvent<FillPlateTypeEvent>().Subscribe(SelectPlateType, ThreadOption.UIThread);
            this.aggregator.GetEvent<FillStateEvent>().Subscribe(SelectState, ThreadOption.UIThread);

            this.aggregator.GetEvent<CreateIncidentEvent>().Subscribe(CreateIncident, ThreadOption.UIThread);

            InitalData();
        }

        private void InitalData()
        {
            cities.Add("New York".ToUpper());
            cities.Add("Los Angeles".ToUpper());
            cities.Add("Washington".ToUpper());
            cities.Add("Chicago".ToUpper());
            cities.Add("Boston".ToUpper());
            cities.Add("Philadelphia".ToUpper());
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

        public ObservableCollection<string> Cities
        {
            get { return cities; }
            set
            {
                this.cities = value;
                RaisePropertyChanged("Cities");
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
            this.City = city.ToUpper();
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
            MessageBox.Show("Create incident successful");
        }
    }
}
