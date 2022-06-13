using isRail.Models;
using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class SaveRideChangesCommand : CommandBase
    {
        private ManagerEditRidesViewModel _managerEditRidesViewModel;
        private bool _canExecute { get; set; }

        public static event Action SaveRideChangesEvent;

        public SaveRideChangesCommand(ManagerEditRidesViewModel managerEditRidesViewModel)
        {
            _managerEditRidesViewModel = managerEditRidesViewModel;
            _managerEditRidesViewModel.RidesCollectionView.CollectionChanged += OnCollectionChanged;
            ManagerEditRidesViewModel.FinishedDiscardingRideChangesEvent += OnDiscardChanges;
        }

        private void OnDiscardChanges()
        {
            _canExecute = false;
            OnCanExecutedChanged();
        }

        public void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _canExecute = !((EditRideViewModel)sender).HasErrors;
            OnCanExecutedChanged();
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (
                _managerEditRidesViewModel._rides.Count() != 
                _managerEditRidesViewModel.App.RidesMap[
                    _managerEditRidesViewModel.SelectedRideBase._rideBase
                    ].Where(x => x.StartTime > DateTime.Now).Count()
                )
            {
                _canExecute = true;
            }
            else
            {
                _canExecute = false;
            }
            OnCanExecutedChanged();
        }
        public override void Execute(object parameter)
        {
            List<Ride> deletedRides = _managerEditRidesViewModel.App.RidesMap[
                _managerEditRidesViewModel.SelectedRideBase._rideBase
                ].Where(x => x.StartTime > DateTime.Now)
                .Except(from x in _managerEditRidesViewModel._rides select x._ride)
                .ToList();
            List<Ride> addedRides = new List<Ride>();
            foreach (EditRideViewModel eRide in _managerEditRidesViewModel._rides)
            {
                if (
                    !_managerEditRidesViewModel.App.RidesMap[
                    _managerEditRidesViewModel.SelectedRideBase._rideBase
                    ].Where(x => x.StartTime > DateTime.Now)
                    .Contains(eRide._ride)
                )
                    addedRides.Add(eRide._ride);
            }
                _managerEditRidesViewModel.App.RidesMap[
                _managerEditRidesViewModel.SelectedRideBase._rideBase
                ].Where(x => x.StartTime > DateTime.Now)
                .Except(from x in _managerEditRidesViewModel._rides select x._ride)
                .ToList();
            bool? result = new MessageBoxCustom("Da li želite da sačuvate promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            bool flag = false;
            if (result.HasValue && result.Value)
            {
                foreach(Ride ride in deletedRides)
                {
                    if(ride.numOfSales > 0)
                    {
                        _managerEditRidesViewModel._rides.Add(new EditRideViewModel(ride, _managerEditRidesViewModel.App));
                        MessageBoxCustom mb = new MessageBoxCustom($"Nije moguće obrisati vožnju sa polaskom u:\n{ride.GetStartTime()} jer već ima kupljene karte.", MessageType.Error, MessageButtons.Ok);
                        mb.Height = 230;
                        mb.ShowDialog();
                    }
                    else
                    {
                        flag = true;
                        _managerEditRidesViewModel.App.RidesMap[_managerEditRidesViewModel.SelectedRideBase._rideBase].Remove(ride);
                    }
                }
                foreach(EditRideViewModel eRide in _managerEditRidesViewModel._rides)
                {
                    Ride? ride = _managerEditRidesViewModel.App.RidesMap[_managerEditRidesViewModel.SelectedRideBase._rideBase].Find(x => x == eRide._ride);
                    if (ride != null && !deletedRides.Contains(ride))
                    {
                        flag = true;
                        ride.Train = eRide.Train;
                        ride.Price = double.Parse(eRide.Price.Split(" ")[0]);
                        ride.StartTime = DateTime.ParseExact(eRide.StartTime, eRide.DateFormat, CultureInfo.InvariantCulture);
                        ride.EndTime = DateTime.ParseExact(eRide.EndTime, eRide.DateFormat, CultureInfo.InvariantCulture);
                    }
                }
                foreach(Ride ride in addedRides)
                {
                    flag = true;
                    _managerEditRidesViewModel.App.RidesMap[_managerEditRidesViewModel.SelectedRideBase._rideBase].Add(ride);
                }
                if (flag)
                {
                    MessageBoxCustom mb = new MessageBoxCustom($"Promene su uspešno sačuvane.", MessageType.Confirmation, MessageButtons.Ok);
                    mb.ShowDialog();
                }
                _canExecute = false;
                OnCanExecutedChanged();
                SaveRideChangesEvent?.Invoke();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute;
        }
    }
}
