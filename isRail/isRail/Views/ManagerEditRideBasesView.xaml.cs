using BingMapsRESTToolkit;
using isRail.Models;
using isRail.Utils;
using isRail.ViewModels;
using MaterialDesignThemes.Wpf;
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

        public Station currentStation;
        public bool from;
        public bool to;
        public bool interStation;
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

            MessageBoxInputCustom messageBox = new MessageBoxInputCustom("Izmena imena stanice", "Potvrdi");
            messageBox.ShowDialog();
            string newStationName = messageBox.InputValue;

            UpdateSelectedStationLocation(sender, newStationWaypoint, newStationName);

        }

        private void OutlinedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RideBase ride = ((RideBaseViewModel)RideBaseComboBox.SelectedItem).RideBase;
            if (ride != null)
            {

                RideBaseTextBlock.Text = "Linija [" + ride.Id.ToString() + "]";
                ShowRideLineOnMap(ride);
                FromToSelectGrid.Visibility = Visibility.Visible;
                StationDataGrid.Visibility = Visibility.Visible;

            } else
            {
                FromToSelectGrid.Visibility = Visibility.Hidden;
            } 

            
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
                currentStation = ((RideBaseViewModel)RideBaseComboBox.SelectedItem).From;
                from = true;
                DragDrop.DoDragDrop(FromLocation, FromLocation, DragDropEffects.Move);
            }
            from = false;
        }

        private void ToLocationSelect_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                currentStation = ((RideBaseViewModel)RideBaseComboBox.SelectedItem).To;
                to = true;
                DragDrop.DoDragDrop(ToLocation, ToLocation, DragDropEffects.Move);
            }
            to = false;
            
        }

        private void StationDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //currentStation = ((RideBaseViewModel)RideBaseComboBox.SelectedItem).Stations[StationDataGrid.SelectedIndex];
                //interStation = true;
                //DragDrop.DoDragDrop((DataGrid)sender, sender, DragDropEffects.Move);
            }
            interStation = false;
        }

        private void UserControl_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;

        }

        private void UpdateSelectedStationLocation(object sender, SimpleWaypoint waypoint, string name)
        {
            Station station = new Station(name, waypoint);

            if(to)
            {
                RideBase old = ((RideBaseViewModel)RideBaseComboBox.SelectedItem).RideBase;
                ((RideBaseViewModel)RideBaseComboBox.SelectedItem).RideBase = new RideBase(
                    old.Id,
                    station,
                    old.From,
                    old.Stations);
            } else if(from)
            {
                RideBase old = ((RideBaseViewModel)RideBaseComboBox.SelectedItem).RideBase;
                ((RideBaseViewModel)RideBaseComboBox.SelectedItem).RideBase = new RideBase(
                    old.Id,
                    old.To,
                    station,
                    old.Stations);

            } else if(interStation)
            {
                RideBase old = ((RideBaseViewModel)RideBaseComboBox.SelectedItem).RideBase;

                int oldIndex = old.Stations.IndexOf(currentStation);
                List<Station> newStations = new List<Station>(old.Stations);
                newStations.RemoveAt(oldIndex);
                newStations.Insert(oldIndex, station);

                ((RideBaseViewModel)RideBaseComboBox.SelectedItem).RideBase = new RideBase(
                    old.Id,
                    old.To,
                    old.From,
                    newStations);
            }
            

        }

        private void StationDataGrid_DragOver(object sender, DragEventArgs e)
        {

        }
    }
}
