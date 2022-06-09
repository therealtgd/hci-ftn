using System.Collections.Generic;

namespace isRail.Models
{
    public class RideBase
    {

        public string From { get; }
        public string To { get; }
        public List<string> Stations { get; }

        public RideBase(string from, string to, List<string> stations)
        {
            From = from;
            To = to;
            Stations = stations;
        }
    }
}