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

        public ObservableCollection<RideBaseViewModel> RideBases { get; set; }
        public ObservableCollection<Station> Stations { get; set; }

        public ICollectionView RideBasesCollectionView { get; set; }

        public ICollectionView StationCollectionView { get; set; }

        public SaveRideBaseChangesCommand SaveRideBaseChangesCommand { get; set; }
        public DiscardRideBaseChangesCommand DiscardRideBaseChangesCommand { get; set; }
        public AddTrainCommand AddTrainCommand { get; set; }
        public static event Action FinishedDiscardingChangesEvent;

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
            RideBases = new ObservableCollection<RideBaseViewModel>();
            Stations = new ObservableCollection<Station>();

            foreach (RideBase rideBase in app.RidesMap.Keys)
                RideBases.Add(new RideBaseViewModel(rideBase, app));

            RideBasesCollectionView = CollectionViewSource.GetDefaultView(RideBases);

            SaveRideBaseChanges = new SaveRideBaseChangesCommand(this);
            DiscardRideBaseChangesCommand = new DiscardRideBaseChangesCommand(this);
            AddRideBase = new AddRideBaseCommand(this);

            DiscardTrainChangesCommand.DiscardChangesEvent += OnDiscardChanges;
            AddTrainCommand.AddedTrainEvent += OnDiscardChanges;
        }

        private void UpdateGrid()
        {
            foreach (Station s in selectedRideBase.RideBase.Stations)
                Stations.Add(new Station(s));
            StationCollectionView = CollectionViewSource.GetDefaultView(Stations);
        }

        private void OnDiscardChanges()
        {
            RideBases.Clear();
            foreach (RideBase rB in App.RidesMap.Keys)
                RideBases.Add(new RideBaseViewModel(rB, App));
            FinishedDiscardingChangesEvent?.Invoke();
        }
    }
}
