using isRail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class RideBaseViewModel : ViewModelBase
    {
        public readonly RideBase _rideBase;

        public Station From => _rideBase.From;
        public Station To => _rideBase.To;
        public List<Station> Stations => _rideBase.Stations;

        public Models.App App { get; }

        public RideBaseViewModel(RideBase rideBase, Models.App app)
        {
            App = app;
            _rideBase = rideBase;
        }

        public override string ToString()
        {
            string result = From.ToString();
            foreach (Station station in Stations)
            {
                result += "-" + station.ToString();
            }
            result += "-"+To.ToString();
            return result;
        }
    }
}
