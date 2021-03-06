using isRail.Commands;
using isRail.Models;
using isRail.Utils;
using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace isRail.Views
{
    /// <summary>
    /// Interaction logic for DepartureDetails.xaml
    /// </summary>
    public partial class DepartureDetailsView : Window
    {
        public ICommand BuyTicketCommand { get; }
        public ICommand ReserveTicketCommand { get; }

        public DepartureDetailsView(RideViewModel ride, Models.App app)
        {
            InitializeComponent();
            DataContext = this;
            Title = Title + ride.From + " - " + ride.To;
            From.Text = From.Text + ride.From;
            if (ride.Stations.Count > 0)
            {
                if (ride.Stations.Count == 1)
                    StationsLabel.Text = "Međustanica: ";
                else
                    StationsLabel.Text = "Međustanice: ";
                Stations.ItemsSource = ride.Stations;
            }
            To.Text = To.Text + ride.To;
            StartTime.Text = StartTime.Text + ride.StartTime.ToShortDateString() + ride.StartTime.ToShortTimeString();
            EndTime.Text = EndTime.Text + ride.EndTime.ToShortDateString() + ride.EndTime.ToShortTimeString();
            Price.Text = Price.Text + ride.Price;
            Train.Text = Train.Text + ride.Train;

            BuyTicketCommand = new BuyTicketCommand(app, ride.Ride);
            ReserveTicketCommand = new ReserveTicketCommand(app, ride.Ride);

            ShowRideLineOnMap(ride);
            ResizeMode = ResizeMode.NoResize;

            LogoutCommand.LogoutEvent += Close;
        }

        private void ShowRideLineOnMap(RideViewModel ride)
        {
            RideMap.Children.Clear();
            List<BingMapsRESTToolkit.SimpleWaypoint> waypoints = new List<BingMapsRESTToolkit.SimpleWaypoint>();
            waypoints.Add(ride.From.Waypoint);
            foreach (Station s in ride.Stations)
            {
                waypoints.Add(s.Waypoint);
            }
            waypoints.Add(ride.To.Waypoint);
            BingMapsRESTService.SendRequest(RideMap, waypoints);
        }
    }
}
