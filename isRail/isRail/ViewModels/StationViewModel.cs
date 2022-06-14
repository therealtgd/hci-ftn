using BingMapsRESTToolkit;
using isRail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class StationViewModel : ViewModelBase
    {
        public Station _station { get; set; }

        public string Name => _station.Name;
        public SimpleWaypoint Waypoint => _station.Waypoint;
        public Models.App App { get; }

        public Station Station
        {
            get
            {
                return _station;
            }
            set
            {
                _station = value;
                OnPropertyChanged(nameof(Station));
            }
        }

        public StationViewModel(Station st, Models.App app)
        {
            _station = st;
            App = app;
        }
    }
}
