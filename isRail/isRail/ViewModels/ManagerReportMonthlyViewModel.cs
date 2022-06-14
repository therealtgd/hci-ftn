using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace isRail.ViewModels
{
    public class ManagerReportMonthlyViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        private DateTime? _monthFilter;
        public DateTime? MonthFilter { get { return _monthFilter; } set { _monthFilter = value; LoadReport(); OnPropertyChanged(nameof(MonthFilter)); } }

        private int _ticketsSoldFilter;
        public int TicketsSoldFilter { get { return _ticketsSoldFilter; } set { _ticketsSoldFilter = value; OnPropertyChanged(nameof(TicketsSoldFilter)); } }

        private double _earningsFilter;
        public double EarningsFilter { get { return _earningsFilter; } set { _earningsFilter = value; OnPropertyChanged(nameof(EarningsFilter)); } }

        private ObservableCollection<MonthlyReportViewModel> monthlyReportViews; 

        public ICollectionView MonthlyReportsView { get; }

        public ManagerReportMonthlyViewModel(Models.App app)
        {
            App = app;
            monthlyReportViews = new ObservableCollection<MonthlyReportViewModel>();
            MonthlyReportsView = CollectionViewSource.GetDefaultView(monthlyReportViews);
            MonthlyReportsView.Filter = Filter;
            MonthFilter = DateTime.Now;
        }

        private bool Filter(object obj)
        {
            if (obj is MonthlyReportViewModel report)
            {
                return report.TicketsSold > TicketsSoldFilter && report.Earnings > _earningsFilter;
            }
            return false;
        }
        
        private void LoadReport()
        {
            monthlyReportViews.Clear();
            if (MonthFilter.HasValue)
            {
                foreach(RideBase rideBase in App.RidesMap.Keys)
                {
                    int ticketsSold = 0;
                    double earnings = 0;
                    foreach(Ride ride in App.Tickets.Keys.Where(x => x.RideBase == rideBase))
                    {
                        foreach(TicketDetails ticket in App.Tickets[ride])
                        {
                            if (ticket.DateTimeBought > MonthFilter.Value && ticket.DateTimeBought < MonthFilter.Value.AddMonths(1))
                            {
                                ticketsSold++;
                                earnings += ride.Price;
                            }
                        }
                    }
                    monthlyReportViews.Add(new MonthlyReportViewModel(rideBase, ticketsSold, earnings));
                }
            }
            MonthlyReportsView.Refresh();
        }
    }
}
