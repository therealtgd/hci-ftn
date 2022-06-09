using BingMapsRESTToolkit;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace isRail.Views
{
    /// <summary>
    /// Interaction logic for ClientMapView.xaml
    /// </summary>
    public partial class ClientMapView : UserControl
    {
        public ClientMapView()
        {
            InitializeComponent();
        }

        private void RideDataGridRowClicked(object sender, MouseEventArgs e)
        {
            RideViewModel ride = (RideViewModel)rideDataGrid.SelectedItem;
            ShowRideLineOnMap(ride);
        }

        private void ShowRideLineOnMap(RideViewModel ride)
        {
            RideMap.Children.Clear();
            List<BingMapsRESTToolkit.SimpleWaypoint> waypoints = new List<BingMapsRESTToolkit.SimpleWaypoint>();
            waypoints.Add(ride.FromWaypoint);
            waypoints.AddRange(ride.StationWaypoints);
            waypoints.Add(ride.ToWaypoint);
            BingMapsRESTService.SendRequest(RideMap, waypoints);
        }
    }
}
