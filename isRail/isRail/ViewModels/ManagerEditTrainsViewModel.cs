using isRail.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class ManagerEditTrainsViewModel : ViewModelBase
    {
        public Models.App App { get; }

        public ObservableCollection<TrainViewModel> Trains { get; set; }
        public ICollectionView TrainsCollectionView { get; set; }

        public ICommand SaveTrainChangesCommand { get; set; }
        public DiscardTrainChangesCommand DiscardTrainChangesCommand { get; set;  }

        public AddTrainCommand AddTrainCommand { get; set; }
        public VideoCommand VideoCommand { get; set; }
        public Action FocusAction { get; set; }

        private string _train = string.Empty;
        public string Train
        {
            get
            { return _train; }
            set
            {
                _train = value;
                OnPropertyChanged(nameof(Train));
                TrainsCollectionView.Refresh();
            }
        }

        public ManagerEditTrainsViewModel(Models.App app)
        {
            App = app;
            Trains = new ObservableCollection<TrainViewModel>();
            foreach (string train in app.Trains)
                Trains.Add(new TrainViewModel(train, app));
            TrainsCollectionView = CollectionViewSource.GetDefaultView(Trains);
            TrainsCollectionView.Filter = FilterTrains;

            SaveTrainChangesCommand = new SaveTrainChangesCommand(this);
            DiscardTrainChangesCommand = new DiscardTrainChangesCommand(this);
            AddTrainCommand = new AddTrainCommand(this);
            VideoCommand = new VideoCommand();

            DiscardTrainChangesCommand.DiscardChangesEvent += OnDiscardChanges;
            AddTrainCommand.AddedTrainEvent += OnDiscardChanges;

        }

        private bool FilterTrains(object obj)
        {
            if (obj is TrainViewModel trainView)
            {
                return trainView.Train.ToString().Contains(Train, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public static event Action FinishedDiscardingChangesEvent;
        private void OnDiscardChanges()
        {
            Trains.Clear();
            foreach (string train in App.Trains)
                Trains.Add(new TrainViewModel(train, App));
            FinishedDiscardingChangesEvent?.Invoke();
        }
    }
}
