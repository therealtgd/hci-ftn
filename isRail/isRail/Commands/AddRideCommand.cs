using isRail.Models;
using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class AddRideCommand : CommandBase
    {
        ManagerEditRidesViewModel _managerEditRidesViewModel;
        private bool _canExecute = false;
        public AddRideCommand(ManagerEditRidesViewModel managerEditRidesViewModel)
        {
            _managerEditRidesViewModel = managerEditRidesViewModel;
            _managerEditRidesViewModel.RidesCollectionView.CollectionChanged += OnCollectionChanged;
        }
        public override void Execute(object parameter)
        {
            _managerEditRidesViewModel._rides.Add(
                new EditRideViewModel(
                    new Ride(
                        _managerEditRidesViewModel.SelectedRideBase._rideBase, 
                        _managerEditRidesViewModel.App
                        ),
                    _managerEditRidesViewModel.App
                    )
                );
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (_managerEditRidesViewModel.SelectedRideBase == null)
                _canExecute = false;
            else
                _canExecute = true;
            OnCanExecutedChanged();
        }
        public override bool CanExecute(object parameter)
        {
            return _canExecute;
        }
    }
}
