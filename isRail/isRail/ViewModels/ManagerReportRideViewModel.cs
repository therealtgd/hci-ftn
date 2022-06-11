using isRail.Commands;
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
    public class ManagerReportRideViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        private readonly ObservableCollection<TicketViewModel> _tickets;
        public ICollectionView TicketsCollectionView { get; }
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
                TicketsCollectionView.Refresh();
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
                TicketsCollectionView.Refresh();
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
                TicketsCollectionView.Refresh();
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
                TicketsCollectionView.Refresh();
            }
        }

        private int _numOfSalesFilter = 0;
        public int NumOfSalesFilter
        {
            get
            { return _numOfSalesFilter; }
            set
            {
                if (value == null)
                    _numOfSalesFilter = 0;
                else
                    _numOfSalesFilter = value;
                _numOfSalesFilter = value;
                OnPropertyChanged(nameof(NumOfSalesFilter));
                TicketsCollectionView.Refresh();
            }
        }

        private double _earningsFilter = 0;
        public double EarningsFilter
        {
            get
            { return _earningsFilter; }
            set
            {
                _earningsFilter = value;
                OnPropertyChanged(nameof(EarningsFilter));
                TicketsCollectionView.Refresh();
            }
        }

        public ManagerReportRideViewModel(Models.App app)
        {
            App = app;
            _tickets = new ObservableCollection<TicketViewModel>();
            foreach (var keyValuePair in app.Tickets)
                _tickets.Add(new TicketViewModel(app, keyValuePair.Key, keyValuePair.Value));
            TicketsCollectionView = CollectionViewSource.GetDefaultView(_tickets);
            TicketsCollectionView.Filter = FilterTickets;
            SwapFromToCommand = new SwapFromToCommandRideReport(this);
        }

        private bool FilterTickets(object obj)
        {
            if (obj is TicketViewModel ticket)
            {
                return ticket.RideViewModel.From.ToString().Contains(FromFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    ticket.RideViewModel.To.ToString().Contains(ToFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    (StartDateFilter == null || ticket.RideViewModel.StartTime >= StartDateFilter) &&
                    DateTimeFilter(ticket.RideViewModel) &&
                    ticket.RideViewModel.Ride.GetNumOfSales() >= NumOfSalesFilter &&
                    ticket.RideViewModel.Ride.Earnings >= EarningsFilter;
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
