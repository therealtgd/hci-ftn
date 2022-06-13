using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using isRail.Commands;

namespace isRail.ViewModels
{
    public class ManagerEditRideBasesViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        public ObservableCollection<RideBase> RideBases { get; set; }
        public ObservableCollection<Station> Stations { get; set; }

        public ICollectionView RideBasesCollectionView { get; set; }

        public ICollectionView StationCollectionView { get; set; }

        private RideBaseViewModel selectedRideBase;

        private RideBase _comboBoxSelect;
        public RideBase ComboBoxSelect
        {
            get { return _comboBoxSelect; }
            set
            { 
                _comboBoxSelect = value;
                SelectedRideBase = new RideBaseViewModel(value, App);
            }
        }

        public RideBaseViewModel SelectedRideBase
        {
            get { return selectedRideBase; }
            set 
            {
                selectedRideBase = value;
                OnPropertyChanged(nameof(selectedRideBase));
                UpdateGrid();
            }
        }


        public SaveRideBaseChangesCommand SaveRideBaseChanges { get; set; }
        public DiscardRideBaseChangesCommand DiscardRideBaseChanges { get; set; }
        public AddRideBaseCommand AddRideBase { get; set; }

        public ManagerEditRideBasesViewModel(Models.App app)
        {
            App = app;
            RideBases = new ObservableCollection<RideBase>();
            Stations = new ObservableCollection<Station>();

            foreach (RideBase rideBase in app.RidesMap.Keys)
                RideBases.Add(new RideBase(rideBase.Id, rideBase.To, rideBase.From, rideBase.Stations));

            RideBasesCollectionView = CollectionViewSource.GetDefaultView(RideBases);

            //SaveRideBaseChanges = new SaveRideBaseChangesCommand(this);
            //DiscardRideBasesChangesCommand = new DiscardRideBaseChangesCommand(this);
            //AddRideBaseCommand = new AddRideBaseCommand(this);

            //DiscardTrainChangesCommand.DiscardChangesEvent += OnDiscardChanges;
            //AddTrainCommand.AddedTrainEvent += OnDiscardChanges;

        }

        //private void selectedRideBaseChanged()
        //{
        //    StationCollectionView = CollectionViewSource.GetDefaultView(SelectedRideBase.RideBase.Stations);
        //}

        private void UpdateGrid()
        {
            foreach (Station s in selectedRideBase.RideBase.Stations)
                Stations.Add(new Station(s));
            StationCollectionView = CollectionViewSource.GetDefaultView(Stations);
        }
    }
}
