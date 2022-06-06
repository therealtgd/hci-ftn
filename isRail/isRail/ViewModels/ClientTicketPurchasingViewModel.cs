using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class ClientTicketPurchasingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<RideViewModel> _rides;

        public IEnumerable<RideViewModel> Rides => _rides;

        public ClientTicketPurchasingViewModel()
        {
            _rides = new ObservableCollection<RideViewModel>();

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
    }
}
