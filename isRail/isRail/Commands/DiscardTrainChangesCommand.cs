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
        private bool _canExecute { get; set; } = false;
        public static event Action DiscardChangesEvent;

        

        public DiscardTrainChangesCommand(ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
            foreach (var trains in managerEditTrainsViewModel.Trains)
                trains.PropertyChanged += OnPropertyChanged;
            SaveTrainChangesCommand.SaveChangesEvent += OnSaveChanges;
            _managerEditTrainsViewModel.Trains.CollectionChanged += OnCollectionChanged;
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
               
                _managerEditTrainsViewModel.TrainsCollectionView = CollectionViewSource.GetDefaultView(_managerEditTrainsViewModel.Trains);
                new MessageBoxCustom("Promene su uspešno odbačene.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                _canExecute = false;
                OnCanExecutedChanged();
                DiscardChangesEvent?.Invoke();
            }

        }
    }
}
