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

        public Ride(RideBase rideBase, string train, DateTime startTime, DateTime endTime, double price)
        {
            RideBase = rideBase;
            Train = train;
            StartTime = startTime;
            EndTime = endTime;
            Price = price;
        }

        public Ride(string train,
                    string from, 
                    string to, 
                    List<string> stations, 
                    DateTime startTime, 
                    DateTime endTime, 
                    double price,
                    SimpleWaypoint fromWaypoint,
                    SimpleWaypoint toWaypoint,
                    List<SimpleWaypoint> stationWaypoints)
        {
            Train = train;
            From = from;
            To = to;
            Stations = stations;
            StartTime = startTime;
            EndTime = endTime;
            Price = price;
            FromWaypoint = fromWaypoint;
            ToWaypoint = toWaypoint;
            StationWaypoints = stationWaypoints;
        }

    }
}
