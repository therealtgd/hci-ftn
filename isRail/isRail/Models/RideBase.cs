using System.Collections.Generic;

namespace isRail.Models
{
    public class RideBase
    {

        public int Id { get; }

        public string From { get; }
        public string To { get; }
        public List<string> Stations { get; }

        public RideBase(int id, string from, string to, List<string> stations)
        {
            Id = id;
            From = from;
            To = to;
            Stations = stations;
        }
    }
}