using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Models
{
    public class Station
    {
        public String Name { get; set; }
        public SimpleWaypoint Waypoint { get; set; }

        public Station(String name, SimpleWaypoint waypoint)
        {
            Name = name;
            Waypoint = waypoint;
        }

        public Station(string name)
        {
            Name = name;
        }

        public Station(string name, double latitude, double longitude)
        {
            Name = name;
            Waypoint = new SimpleWaypoint(latitude, longitude);
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
