using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class DiscardRideBaseChangesCommand : CommandBase
    {
        private ManagerEditRideBasesViewModel _managerEditRideBasesViewModel;
        private bool _canExecute { get; set; }
        public static event Action DiscardChangesEvent;

        public DiscardRideBaseChangesCommand(ManagerEditRideBasesViewModel managerEditRideBasesViewModel)
        {
            _canExecute = false;
            _managerEditRideBasesViewModel = managerEditRideBasesViewModel;
            foreach (RideBaseViewModel rB in _managerEditRideBasesViewModel.RideBases)
                rB.PropertyChanged += OnPropertyChanged;
            SaveRideBaseChangesCommand.SaveRideBaseChangesEvent += OnSaveChanges;
            _managerEditRideBasesViewModel.RideBases.CollectionChanged += OnCollectionChanged;
            ManagerEditRideBasesViewModel.FinishedDiscardingChangesEvent += OnFinishedDiscardingChanges;
        }

        private void OnFinishedDiscardingChanges()
        {
            _canExecute = false;
            foreach (RideBaseViewModel rB in _managerEditRideBasesViewModel.RideBases)
                rB.PropertyChanged += OnPropertyChanged;
            OnCanExecutedChanged();
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (_managerEditRideBasesViewModel.RideBases.Count() < _managerEditRideBasesViewModel.App.RidesMap.Keys.Count())
                _canExecute = true; OnCanExecutedChanged();
        }

        private void OnSaveChanges()
        {
            _canExecute = false;
            OnCanExecutedChanged();
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _canExecute = true;
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
