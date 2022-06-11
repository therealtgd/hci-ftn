using isRail.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace isRail.ViewModels
{
    public class ManagerEditRidesViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        private ObservableCollection<RideViewModel> _rides;
        public ICollectionView RidesCollectionView { get; }

        private ObservableCollection<RideBaseViewModel> _rideBases;
        public ICollectionView RideBasesCollectionView { get; }

        private DateTime? _startDateFilter = null;
        public DateTime? StartDateFilter
        {
            get
            { return _startDateFilter; }
            set
            {
                _startDateFilter = value;
                OnPropertyChanged(nameof(StartDateFilter));
            }
        }

        private DateTime? _startTimeFilter = null;
        public DateTime? StartTimeFilter
        {
            get
            { return _startTimeFilter; }
            set
            {
                _startTimeFilter = value;
                OnPropertyChanged(nameof(StartTimeFilter));
            }
        }

        private int _priceFilter = 0;
        public int PriceFilter { get { return _priceFilter; } set { _priceFilter = value; OnPropertyChanged(nameof(PriceFilter)); } }

        private string _trainFilter = string.Empty;
        public string TrainFilter { get { return _trainFilter; } set { _trainFilter = value; OnPropertyChanged(nameof(TrainFilter)); } }

        private RideBaseViewModel _selectedRideBase;
        public RideBaseViewModel SelectedRideBase { get { return _selectedRideBase; } set { _selectedRideBase = value; LoadRides(); OnPropertyChanged(nameof(SelectedRideBase)); } }

        public ManagerEditRidesViewModel(Models.App app)
        {
            App = app;

            _rides = new ObservableCollection<RideViewModel>();
            _rideBases = new ObservableCollection<RideBaseViewModel>();

            foreach (RideBase rideBase in App.RidesMap.Keys)
            {
                _rideBases.Add(new RideBaseViewModel(rideBase, App));
            }

            RidesCollectionView = CollectionViewSource.GetDefaultView(_rides);
            RideBasesCollectionView = CollectionViewSource.GetDefaultView(_rideBases);
        }

        private void LoadRides()
        {
            _rides.Clear();
            foreach(Ride ride in App.RidesMap[SelectedRideBase._rideBase])
            {
                _rides.Add(new RideViewModel(ride, App));
            }
        }
    }
}