using BingMapsRESTToolkit;
using isRail.Models;
using isRail.Utils;
using isRail.ViewModels;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManagerEditRideBasesView.xaml
    /// </summary>
    public partial class ManagerEditRideBasesView : UserControl
    {
        public ManagerEditRideBasesView()
        {
            InitializeComponent();
        }

        private void Map_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Map_Drop(object sender, DragEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(RideBaseMap);
            Microsoft.Maps.MapControl.WPF.Location pinLocation = RideBaseMap.ViewportPointToLocation(mousePosition);

            SimpleWaypoint newStationWaypoint = new SimpleWaypoint(pinLocation.Latitude, pinLocation.Longitude);


        }

        private void OutlinedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RideBase ride = (RideBase)RideBaseComboBox.SelectedItem;
            if (ride != null)
            {
                RideBaseTextBlock.Text = "Linija broj [" + ride.Id.ToString() + "]";
                FromTextBlock.Text = ride.From.ToString();
                ToTextBlock.Text = ride.To.ToString();
                ShowRideLineOnMap(ride);
                AddLineStationsToDataGrid(ride.Stations);
                FromToSelectGrid.Visibility = Visibility.Visible;
                StationDataGrid.Visibility = Visibility.Visible;

            } else
            {
                FromToSelectGrid.Visibility = Visibility.Hidden;
            } 

            
        }

        private void AddLineStationsToDataGrid(List<Station> stations)
        {
            ClearStationsFromDataGrid();
            foreach (Station station in stations) { }
                //Stations.Add(station);
        } 

        private void ClearStationsFromDataGrid()
        {
            //Stations.Clear();
        }

        private void ShowRideLineOnMap(RideBase ride)
        {
            RideBaseMap.Children.Clear();
            List<BingMapsRESTToolkit.SimpleWaypoint> waypoints = new List<BingMapsRESTToolkit.SimpleWaypoint>();
            waypoints.Add(ride.From.Waypoint);
            foreach (Station s in ride.Stations)
            {
                waypoints.Add(s.Waypoint);
            }
            waypoints.Add(ride.To.Waypoint);
            BingMapsRESTService.SendRequest(RideBaseMap, waypoints);
        }

        private void FromLocationSelect_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(FromLocation, FromLocation, DragDropEffects.Move);
            }
        }

        private void UserControl_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;

        }
    }
}
