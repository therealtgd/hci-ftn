using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Models
{
    public class Ride
    {

        public string Train { get; }
        public string From { get; }
        public string To { get; }
        public List<string> Stations { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public double Price { get; }

        public Ride(string train, string from, string to, List<string> stations, DateTime startTime, DateTime endTime, double price)
        {
            Train = train;
            From = from;
            To = to;
            Stations = stations;
            StartTime = startTime;
            EndTime = endTime;
            Price = price;
        }

    }
}
