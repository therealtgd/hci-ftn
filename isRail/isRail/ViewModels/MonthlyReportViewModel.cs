using isRail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class MonthlyReportViewModel : ViewModelBase
    {
        public RideBase RideBase { get; set; }
        public int TicketsSold { get; set; }
        public double Earnings { get; set; }

        public MonthlyReportViewModel(RideBase rideBase, int ticketsSold, double earnings)
        {
            RideBase = rideBase;
            TicketsSold = ticketsSold;
            Earnings = earnings;
        }
    }
}
