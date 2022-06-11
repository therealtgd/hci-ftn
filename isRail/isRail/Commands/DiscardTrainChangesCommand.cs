using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace isRail.Commands
{
    public class DiscardTrainChangesCommand : CommandBase
    {
        private ManagerEditTrainsViewModel _managerEditTrainsViewModel;
        private bool _canExecute { get; set; }
        public static event Action DiscardChangesEvent;

        

        public DiscardTrainChangesCommand(ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _canExecute = false;
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
            foreach (var trains in managerEditTrainsViewModel.Trains)
                trains.PropertyChanged += OnPropertyChanged;
            SaveTrainChangesCommand.SaveChangesEvent += OnSaveChanges;
            _managerEditTrainsViewModel.Trains.CollectionChanged += OnCollectionChanged;
            ManagerEditTrainsViewModel.FinishedDiscardingChangesEvent += OnFinishedDiscardingChanges;
        }

        private void OnFinishedDiscardingChanges()
        {
            _canExecute = false;
            foreach (var trains in _managerEditTrainsViewModel.Trains)
                trains.PropertyChanged += OnPropertyChanged;
            OnCanExecutedChanged();
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (_managerEditTrainsViewModel.Trains.Count() < _managerEditTrainsViewModel.App.Trains.Count())
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
            bool? result = new MessageBoxCustom("Da li želite da odbacite promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result.Value)
            {
               
                new MessageBoxCustom("Promene su uspešno odbačene.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                DiscardChangesEvent?.Invoke();
                _canExecute = false;
                OnCanExecutedChanged();
            }

        }
    }
}
