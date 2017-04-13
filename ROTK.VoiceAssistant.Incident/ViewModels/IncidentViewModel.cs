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
        private ObservableCollection<string> incidentTypes = new ObservableCollection<string>();
        private ObservableCollection<string> plateTypes = new ObservableCollection<string>();
        private ObservableCollection<string> states = new ObservableCollection<string>();

        [ImportingConstructor]
        public IncidentViewModel(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;

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

            incidentTypes.Add("Accident");
            incidentTypes.Add("Alarm");
            incidentTypes.Add("animal control");
            incidentTypes.Add("bar check");
            incidentTypes.Add("first alert");

            plateTypes.Add("AM");
            plateTypes.Add("AQ");
            plateTypes.Add("AR");
            plateTypes.Add("CI");
            plateTypes.Add("PC");

            states.Add("AK");
            states.Add("AL");
            states.Add("AZ");
            states.Add("CA");
            states.Add("CO");
            states.Add("CT");
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

        public ObservableCollection<string> IncidentTypes
        {
            get { return incidentTypes; }
            set
            {
                this.incidentTypes = value;
                RaisePropertyChanged("IncidentTypes");
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

        public ObservableCollection<string> PlateTypes
        {
            get { return plateTypes; }
            set
            {
                this.plateTypes = value;
                RaisePropertyChanged("PlateTypes");
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

        public ObservableCollection<string> States
        {
            get { return states; }
            set
            {
                this.states = value;
                RaisePropertyChanged("States");
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

        private void SelectCity(string city)
        {
            this.City = city.ToUpper();
        }

        private void SelectIncidentType(string incidentType)
        {
            this.IncidentType = IncidentType;
        }

        private void SelectPlateType(string plateType)
        {
            this.PlateType = plateType;
        }

        private void SelectState(string state)
        {
            this.State = state;
        }

        private void CreateIncident()
        {
            MessageBox.Show("Create incident successful");
        }
    }
}
