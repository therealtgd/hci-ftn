using System.Collections.Generic;

namespace isRail.Models
{
    public class RideBase
    {

        public int Id { get; }

        public Station From { get; }
        public Station To { get; }
        public List<Station> Stations { get; }

        public RideBase(int id, Station from, Station to, List<Station> stations)
        {
            Id = id;
            From = from;
            To = to;
            Stations = stations;
        }

        public override string ToString()
        {
            string rideStr = "[" + Id.ToString() + "] " + From.ToString();

            foreach (Station station in Stations)
                rideStr += " - " + station.ToString();

            rideStr += " - " + To.ToString();

            return rideStr;
        }
    }
}