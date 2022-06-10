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
            ManagerEditTrainsViewModel.FinishedDiscardingChangesEvent += OnDiscardChanges;
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
            string train = ((TrainViewModel)sender).Train;
            if (string.IsNullOrEmpty(train))
                _canExecute = false;
            else
                _canExecute = true;
            OnCanExecutedChanged();
        }

        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li želite da sačuvate promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            List<string> trainsInUse = GetTrainsInUse();
            HashSet<string> getTakenTrains = GetTakenTrains();

            if (result.Value)
            {
                if (getTakenTrains.Count > 0)
                {
                    string trains = string.Join("\n", getTakenTrains.Select(train => "  - " + train));
                    MessageBoxCustom mb = new MessageBoxCustom("Nije moguće sačuvati promene jer su sledeća imena vozova zauzeta:\n" + trains, MessageType.Error, MessageButtons.Ok);
                    mb.Width = 600;
                    mb.Height += 20 * trainsInUse.Count;
                    mb.ShowDialog();
                }

                else if (trainsInUse.Count > 0)
                {

                    string trains = string.Join("\n", trainsInUse.Select(train => "  - " + train));
                    MessageBoxCustom mb = new MessageBoxCustom("Nije moguće sačuvati promene jer su sledeći vozovi u upotrebi:\n" + trains + "\nIzbacite navedene vozove iz upotrebe ako želite da ih menjate.", MessageType.Error, MessageButtons.Ok);
                    mb.Width = 600;
                    mb.Height += 20 * trainsInUse.Count + 20;
                    mb.ShowDialog();

                }
              
                
                else
                {
                    _managerEditTrainsViewModel.App.Trains.Clear();
                    foreach (TrainViewModel tVM in _managerEditTrainsViewModel.Trains)
                    {
                        _managerEditTrainsViewModel.App.Trains.Add(tVM.Train);
                    }
                    new MessageBoxCustom("Promene su uspešno sačuvane.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    _canExecute = false;
                    OnCanExecutedChanged();
                    SaveChangesEvent?.Invoke();
                }
            }
        }

        private HashSet<string> GetTakenTrains()
        {
            return (from train in _managerEditTrainsViewModel.Trains
                    where _managerEditTrainsViewModel.Trains.Count(t => t.Train == train.Train) > 1
                    select train.Train).ToHashSet();
        }

        private List<string> GetTrainsInUse()
        {
            List<string> viewModelTrains = _managerEditTrainsViewModel.Trains.Select(train => train.Train).ToList();
            List<string> trainsInUse = new List<string>();
            foreach (string train in _managerEditTrainsViewModel.App.Trains)
            {
                if (!viewModelTrains.Contains(train))
                {
                    foreach (var rL in _managerEditTrainsViewModel.App.RidesMap.Values)
                    {
                        foreach (var r in rL)
                        {
                            if (r.Train.Equals(train))
                            {
                                trainsInUse.Add(train);
                                break;
                            }
                        }
                    }
                }
            }
            return trainsInUse;
        }
    }
}
