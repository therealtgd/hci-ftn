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

        public ICommand SaveTrainChangesCommand { get; }
        public DiscardTrainChangesCommand DiscardTrainChangesCommand { get; }

        public ManagerEditTrainsViewModel(Models.App app)
        {
            App = app;
            Trains = new ObservableCollection<TrainViewModel>();
            foreach (string train in app.Trains)
                Trains.Add(new TrainViewModel(train, app));
            TrainsCollectionView = CollectionViewSource.GetDefaultView(Trains);

            SaveTrainChangesCommand = new SaveTrainChangesCommand(this);
            DiscardTrainChangesCommand = new DiscardTrainChangesCommand(this);

            DiscardTrainChangesCommand.DiscardChangesEvent += OnDiscardChanges;
        }

        private void OnDiscardChanges()
        {
            Trains.Clear();
            foreach (string train in App.Trains)
                Trains.Add(new TrainViewModel(train, App));
        }
    }
}
