using isRail.Models;
using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{

    public class SaveRideBaseChangesCommand : CommandBase
    {
        private ManagerEditRideBasesViewModel _managerEditRideBasesViewModel;
        private bool _canExecute { get; set; }

        public static event Action SaveRideBaseChangesEvent;

        public SaveRideBaseChangesCommand(ManagerEditRideBasesViewModel managerEditRideBasesViewModel)
        {
            _managerEditRideBasesViewModel = managerEditRideBasesViewModel;
            _managerEditRideBasesViewModel.RideBases.CollectionChanged += OnCollectionChanged;
            ManagerEditRideBasesViewModel.FinishedDiscardingChangesEvent += OnDiscardChanges;
        }

        private void OnDiscardChanges()
        {
            _canExecute = false;
            OnCanExecutedChanged();
        }

        public void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _canExecute = true;
            OnCanExecutedChanged();
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (
                _managerEditRideBasesViewModel.RideBases.Count() !=
                _managerEditRideBasesViewModel.App.RidesMap.Keys.Count()
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
            List<RideBaseViewModel> deletedRideBases = new List<RideBaseViewModel>();
            foreach(var rideBaseViewModel in _managerEditRideBasesViewModel.RideBases)
                deletedRideBases.Add(rideBaseViewModel);
            List<RideBaseViewModel> addedRideBases = new List<RideBaseViewModel>();
            foreach (var rideBase in _managerEditRideBasesViewModel.App.RidesMap.Keys)
            {
                RideBaseViewModel rbvm = new RideBaseViewModel(rideBase, _managerEditRideBasesViewModel.App);
                addedRideBases.Add(rbvm);
            }
            bool? result = new MessageBoxCustom("Da li želite da sačuvate promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            bool flag = false;
            if (result.HasValue && result.Value)
            {
                foreach (RideBaseViewModel RideBase in deletedRideBases)
                {
                    if (_managerEditRideBasesViewModel.App.RidesMap[RideBase.RideBase].Count > 0)
                    {
                        _managerEditRideBasesViewModel.RideBases.Add(new RideBaseViewModel(RideBase.RideBase, _managerEditRideBasesViewModel.App));
                        MessageBoxCustom mb = new MessageBoxCustom($"Nije moguće obrisati liniju zbog vožnja koje se tek trebaju održati", MessageType.Error, MessageButtons.Ok);
                        mb.Height = 230;
                        mb.ShowDialog();
                    }
                    else
                    {
                        flag = true;
                        _managerEditRideBasesViewModel.App.RidesMap.Remove(RideBase.RideBase);
                    }
                }
                foreach (RideBaseViewModel RideBaseVM in _managerEditRideBasesViewModel.RideBases)
                {
                    RideBase? RideBase;

                        if (_managerEditRideBasesViewModel.App.RidesMap.ContainsKey(RideBaseVM.RideBase))
                        {
                            RideBase = RideBaseVM.RideBase;
                        } else
                        {
                            RideBase = null;
                        }

                    if (RideBase != null && !deletedRideBases.Contains(RideBaseVM))
                    {
                        flag = true;
                    }
                }
                foreach (RideBaseViewModel RideBase in addedRideBases)
                {
                    flag = true;
                    _managerEditRideBasesViewModel.App.RidesMap[RideBase.RideBase] = new List<Ride>();
                }
                if (flag)
                {
                    MessageBoxCustom mb = new MessageBoxCustom($"Promene su uspešno sačuvane.", MessageType.Confirmation, MessageButtons.Ok);
                    mb.ShowDialog();
                }
                _canExecute = false;
                OnCanExecutedChanged();
                SaveRideBaseChangesEvent?.Invoke();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute;
        }
    }
}
