using BingMapsRESTToolkit;
using isRail.Commands;
using isRail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class RideViewModel
    {
        private readonly Ride _ride;

        public Ride Ride { get { return _ride; } }

        public string Train => _ride.Train;
        public Station From => _ride.RideBase.From;
        public Station To => _ride.RideBase.To;
        public List<Station> Stations => _ride.RideBase.Stations;
        public DateTime StartTime => _ride.StartTime;
        public DateTime EndTime => _ride.EndTime.ToLocalTime();
        public string Price => _ride.Price.ToString() + " RSD";

        public Models.App App { get; }

        public ICommand BuyTicketCommand { get; }
        public ICommand ReserveTicketCommand { get; }


        public RideViewModel(Ride ride, Models.App app)
        {
            App = app;
            BuyTicketCommand = new BuyTicketCommand(App, ride);
            ReserveTicketCommand = new ReserveTicketCommand(App, ride);
            _ride = ride;
        }
    }
}