using isRail.Commands;
using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class ClientPurchasedTicketsViewModel : ViewModelBase
    {
        public Models.App App { get; }

        private ObservableCollection<RideViewModel> _tickets => RefreshTicketsBought();
        public ICollectionView BoughtTicketsCollectionView { get; }
        public ICommand SwapFromToCommand { get; }

        private string _fromFilter = string.Empty;
        public string FromFilter
        {
            get
            { return _fromFilter; }
            set
            {
                _fromFilter = value;
                OnPropertyChanged(nameof(FromFilter));
                BoughtTicketsCollectionView.Refresh();
            }
        }

        private string _toFilter = string.Empty;
        public string ToFilter
        {
            get
            { return _toFilter; }
            set
            {
                _toFilter = value;
                OnPropertyChanged(nameof(ToFilter));
                BoughtTicketsCollectionView.Refresh();
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
                BoughtTicketsCollectionView.Refresh();
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
                BoughtTicketsCollectionView.Refresh();
            }
        }

        public ClientPurchasedTicketsViewModel(Models.App app)
        {
            App = app;
            BoughtTicketsCollectionView = CollectionViewSource.GetDefaultView(_tickets);
            BoughtTicketsCollectionView.Filter = FilterRides;
            SwapFromToCommand = new SwapFromToCommandPurchasedTicketsView(this);
            
        }

        private bool FilterRides(object o)
        {
            if (o is RideViewModel rideView)
            {
                return rideView.FromCity.Contains(FromFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    rideView.ToCity.Contains(ToFilter, StringComparison.InvariantCultureIgnoreCase) &&
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

        private ObservableCollection<RideViewModel> RefreshTicketsBought()
        {
            ObservableCollection<RideViewModel> tmp = new ObservableCollection<RideViewModel>();
            foreach (Ride r in App.Client.BoughtTickets)
                tmp.Add(new RideViewModel(r, App));
            return tmp;
        }
    }
}
