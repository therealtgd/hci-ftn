using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace isRail.ViewModels
{
    internal class ManagerEditTrainsViewModel : ViewModelBase
    {
        public Models.App App { get; }
        private readonly ObservableCollection<TrainViewModel> _trains;
        public ICollectionView TrainsCollectionView { get; }

        public ManagerEditTrainsViewModel(Models.App app)
        {
            App = app;
            _trains = new ObservableCollection<TrainViewModel>();
            foreach (string train in app.Trains)
                _trains.Add(new TrainViewModel(train, app));
            TrainsCollectionView = CollectionViewSource.GetDefaultView(_trains);
        }
    }
}
