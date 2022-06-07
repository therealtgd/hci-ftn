using isRail.Commands;
using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class ClientTicketPurchasingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<RideViewModel> _rides;

        public IEnumerable<RideViewModel> Rides => _rides;
        public ICollectionView RidesCollectionView { get; }
        public ICommand SwapFromToCommand { get; }

        private string _fromFilter = string.Empty;
        public string FromFilter { 
            get 
            { return _fromFilter; } 
            set 
            { 
                _fromFilter = value;
                OnPropertyChanged(nameof(FromFilter));
                RidesCollectionView.Refresh();
            } 
        }

        private string _toFilter = string.Empty;
        public string ToFilter {
            get 
            { return _toFilter; } 
            set
            { 
                _toFilter = value;
                OnPropertyChanged(nameof(ToFilter));
                RidesCollectionView.Refresh();
            } 
        }
       
        public ClientTicketPurchasingViewModel()
        {
            _rides = new ObservableCollection<RideViewModel>();
            {
                _rides.Add(new RideViewModel(new Ride(
                    "Lasta",
                    "Novi Sad",
                    "Beograd",
                    new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
                    DateTime.Now,
                    DateTime.Now.AddHours(0.5),
                    1500)));
                _rides.Add(new RideViewModel(new Ride(
                    "Jastreb",
                    "Subotica",
                    "Beograd",
                    new List<string> { "Zrenjanin" },
                    DateTime.Now,
                    DateTime.Now.AddHours(1),
                    2000)));
                _rides.Add(new RideViewModel(new Ride(
                    "Orao",
                    "Niš",
                    "Sremska Mitrovica",
                    new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
                    DateTime.Now,
                    DateTime.Now.AddHours(3),
                    3000)));
            }
            RidesCollectionView = CollectionViewSource.GetDefaultView(_rides);
            RidesCollectionView.Filter = FilterRides;
            SwapFromToCommand = new SwapFromToCommand(this);
        }

        private bool FilterRides(object o)
        {
            if (o is RideViewModel rideView)
            {
                return rideView.From.Contains(FromFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    rideView.To.Contains(ToFilter, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
    }
}
