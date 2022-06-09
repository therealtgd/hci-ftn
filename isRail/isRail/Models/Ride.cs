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

        public string Train { get; }
        public string From { get; }
        public SimpleWaypoint FromWaypoint { get; }
        public string To { get; }
        public SimpleWaypoint ToWaypoint { get; }
        public List<string> Stations { get; }
        public List<SimpleWaypoint> StationWaypoints { get; }
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
