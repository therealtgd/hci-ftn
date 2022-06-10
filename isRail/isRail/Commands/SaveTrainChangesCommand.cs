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
    public class SaveTrainChangesCommand : CommandBase
    {
        private ManagerEditTrainsViewModel _managerEditTrainsViewModel;
        private bool _canExecute { get; set; } = false;

        public static event Action SaveChangesEvent;

        public SaveTrainChangesCommand(ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
            foreach (var trains in managerEditTrainsViewModel.Trains)
                trains.PropertyChanged += OnPropertyChanged;
            _managerEditTrainsViewModel.Trains.CollectionChanged += OnCollectionChanged;
            DiscardTrainChangesCommand.DiscardChangesEvent += OnDiscardChanges;
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (_managerEditTrainsViewModel.Trains.Count() < _managerEditTrainsViewModel.App.Trains.Count())
                _canExecute = true; OnCanExecutedChanged();
        }

        private void OnDiscardChanges()
        {
            _canExecute = false;
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _canExecute = true;
            OnCanExecutedChanged();
        }

        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li želite da sačuvate promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            
            if (result.Value)
            {
                _managerEditTrainsViewModel.App.Trains.Clear();
                foreach (TrainViewModel tVM in _managerEditTrainsViewModel.Trains)
                {
                    _managerEditTrainsViewModel.App.Trains.Add(tVM.Train);
                }
                _canExecute = false;
                OnCanExecutedChanged();
                SaveChangesEvent?.Invoke();
                new MessageBoxCustom("Promene su uspešno sačuvane.", MessageType.Success, MessageButtons.Ok).ShowDialog();
            }

        }
    }
}
