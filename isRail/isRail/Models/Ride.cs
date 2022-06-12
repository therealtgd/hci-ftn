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
        public string Train { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
        public double Earnings { get; set; }
        public int numOfSales = 0;

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
            numOfSales++;
        }

        public int GetNumOfSales()
        {
            return numOfSales;
        }
        
        public string GetStartTime()
        {
            return StartTime.ToString("dd.MM.yyyy. HH:mm");
        }
    }
}
