using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Models
{
    public class Ride
    {

        public RideBase RideBase { get; }
        public string Train { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public double Price { get; }
        public double Earnings { get; set; }

        public Ride(RideBase rideBase, string train, DateTime startTime, DateTime endTime, double price)
        {
            RideBase = rideBase;
            Train = train;
            StartTime = startTime;
            EndTime = endTime;
            Price = price;
            Earnings = 0;
        }

        public void Buy()
        {
            Earnings += Price;
        }

        public int GetNumOfSales()
        {
            return Convert.ToInt32(Earnings / Price);
        }
    }
}
