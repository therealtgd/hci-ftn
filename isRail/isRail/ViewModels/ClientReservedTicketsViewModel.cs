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
    public class ClientReservedTicketsViewModel : ViewModelBase
    {
        public Models.App App { get; }

        private readonly ObservableCollection<RideViewModel> _tickets;
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

        public ClientReservedTicketsViewModel(Models.App app)
        {
            App = app;
            _tickets = new ObservableCollection<RideViewModel>();
            OnReservedTicket();

            BoughtTicketsCollectionView = CollectionViewSource.GetDefaultView(_tickets);
            BoughtTicketsCollectionView.Filter = FilterRides;
            SwapFromToCommand = new SwapFromToCommandReservedTicketsView(this);
            ReserveTicketCommand.TicketReservedEvent += OnReservedTicket;
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

        private void OnReservedTicket()
        {
            _tickets.Clear();
            foreach (Ride r in App.Client.ReservedTickets)
                if (r.EndTime > DateTime.Now)
                    _tickets.Add(new RideViewModel(r, App));
        }
    }
}
