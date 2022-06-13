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
    public class DiscardRideChangesCommand : CommandBase
    {
        private ManagerEditRidesViewModel _managerEditRidesViewModel;
        private bool _canExecute { get; set; }
        public static event Action DiscardRidesChangesEvent;

        public DiscardRideChangesCommand(ManagerEditRidesViewModel managerEditRidesViewModel)
        {
            _canExecute = false;
            _managerEditRidesViewModel = managerEditRidesViewModel;

            SaveTrainChangesCommand.SaveChangesEvent += OnSaveChanges;
            _managerEditRidesViewModel._rides.CollectionChanged += OnCollectionChanged;
        }


        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li želite da odbacite promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result.Value)
            {
                new MessageBoxCustom("Promene su uspešno odbačene.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                DiscardRidesChangesEvent?.Invoke();
                _canExecute = false;
                OnCanExecutedChanged();
            }

        }
        private void OnSaveChanges()
        {
            _canExecute = false;
            OnCanExecutedChanged();
        }
        public override bool CanExecute(object parameter)
        {
            return _canExecute;
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
        public void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _canExecute = true;
            OnCanExecutedChanged();
        }
    }
}
