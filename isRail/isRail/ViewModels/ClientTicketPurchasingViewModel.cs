using isRail.Commands;
using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class ClientTicketPurchasingViewModel : ViewModelBase
    {

        public Models.App App { get; }

        private readonly ObservableCollection<RideViewModel> _rides;

        public IEnumerable<RideViewModel> Rides => _rides;
        public ICollectionView RidesCollectionView { get; }
        public ICommand SwapFromToCommand { get; }

        private string _fromFilter = string.Empty;
        public string FromFilter { 
            get 
            { return _fromFilter; } 
            set 
            { 
                _fromFilter = value;
                OnPropertyChanged(nameof(FromFilter));
                RidesCollectionView.Refresh();
            } 
        }

        private string _toFilter = string.Empty;
        public string ToFilter {
            get 
            { return _toFilter; } 
            set
            { 
                _toFilter = value;
                OnPropertyChanged(nameof(ToFilter));
                RidesCollectionView.Refresh();
            } 
        }

        private DateTime? _startDateFilter = DateTime.Today;
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

        private DateTime? _startTimeFilter = DateTime.Now;
        public DateTime? StartTimeFilter
        {
            get
            { return _startTimeFilter; }
            set
            {
                _startTimeFilter = value;
                OnPropertyChanged(nameof(StartTimeFilter));
                RidesCollectionView.Refresh();
            }
        }


        public ClientTicketPurchasingViewModel(Models.App app)
        {
            this.App = app;
            _rides = new ObservableCollection<RideViewModel>();
            {
                foreach (List<Ride> rL in App.RidesMap.Values)
                    foreach(Ride r in rL)
                        _rides.Add(new RideViewModel(r, app));
            }
            RidesCollectionView = CollectionViewSource.GetDefaultView(_rides);
            RidesCollectionView.Filter = FilterRides;
            SwapFromToCommand = new SwapFromToCommand(this);

        }

        private bool FilterRides(object o)
        {
            if (o is RideViewModel rideView)
            {
                return rideView.From.ToString().Contains(FromFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    rideView.To.ToString().Contains(ToFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    (StartDateFilter == null || rideView.StartTime >= StartDateFilter) &&
                    DateTimeFilter(rideView);
            }
            return false;
        }

        private bool DateTimeFilter(RideViewModel rideView)
        {
            if (StartTimeFilter == null)
                return true;
            if (StartDateFilter == null)
                return rideView.StartTime.TimeOfDay >= StartTimeFilter.GetValueOrDefault().TimeOfDay;
            DateTime tmpDate;
            tmpDate = StartDateFilter.Value.AddHours(StartTimeFilter.GetValueOrDefault().Hour);
            tmpDate = tmpDate.AddMinutes(StartTimeFilter.GetValueOrDefault().Minute);
            return rideView.StartTime >= tmpDate;
        }
    }
}
