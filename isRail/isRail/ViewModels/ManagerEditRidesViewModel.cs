using isRail.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace isRail.ViewModels
{
    public class ManagerEditRidesViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        public ObservableCollection<EditRideViewModel> _rides { get; set; }
        public ICollectionView RidesCollectionView { get; set; }

        public ObservableCollection<RideBaseViewModel> _rideBases { get; set; }
        public ICollectionView RideBasesCollectionView { get; set; }

        private DateTime? _startDateFilter = null;
        public DateTime? StartDateFilter
        {
            get
            { return _startDateFilter; }
            set
            {
                _startDateFilter = value;
                OnPropertyChanged(nameof(StartDateFilter));
                RidesCollectionView.Refresh();
            }
        }

        private int _priceFilter = 0;
        public int PriceFilter { get { return _priceFilter; } set { _priceFilter = value; OnPropertyChanged(nameof(PriceFilter)); RidesCollectionView.Refresh(); } }

        private string _trainFilter = string.Empty;
        public string TrainFilter { get { return _trainFilter; } set { _trainFilter = value; OnPropertyChanged(nameof(TrainFilter)); RidesCollectionView.Refresh(); } }

        private RideBaseViewModel _selectedRideBase;
        public RideBaseViewModel SelectedRideBase { get { return _selectedRideBase; } set { _selectedRideBase = value; LoadRides(); OnPropertyChanged(nameof(SelectedRideBase)); } }

        public ManagerEditRidesViewModel(Models.App app)
        {
            App = app;

            _rides = new ObservableCollection<EditRideViewModel>();
            _rideBases = new ObservableCollection<RideBaseViewModel>();

            foreach (RideBase rideBase in App.RidesMap.Keys)
            {
                _rideBases.Add(new RideBaseViewModel(rideBase, App));
            }

            RideBasesCollectionView = CollectionViewSource.GetDefaultView(_rideBases);
            RidesCollectionView = CollectionViewSource.GetDefaultView(_rides);
            RidesCollectionView.Filter = FilterRides;
        }

        private void LoadRides()
        {
            _rides.Clear();
            foreach(Ride ride in App.RidesMap[SelectedRideBase._rideBase])
            {
                if(ride.StartTime > DateTime.Now)
                    _rides.Add(new EditRideViewModel(ride, App));
            }
        }

        private bool FilterRides(object obj)
        {
            if (obj is EditRideViewModel rideViewModel)
            {
                return rideViewModel.Train.ToString().Contains(TrainFilter, StringComparison.InvariantCultureIgnoreCase)
                    && (StartDateFilter == null || rideViewModel._ride.StartTime >= StartDateFilter)
                    && rideViewModel._ride.Price >= PriceFilter;
            }
            return false;
        }
    }
}