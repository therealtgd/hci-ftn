using isRail.Models;
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
    public class ManagerEditRideBasesViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        public ObservableCollection<RideBase> RideBases { get; set; }

        public ICollectionView RideBasesCollectionView { get; set; }

        public ManagerEditRideBasesViewModel(Models.App app)
        {
            App = app;

            RideBases = new ObservableCollection<RideBase>();

            foreach (RideBase rideBase in app.RidesMap.Keys)
                RideBases.Add(new RideBase(rideBase.Id, rideBase.To, rideBase.From, rideBase.Stations));

            RideBasesCollectionView = CollectionViewSource.GetDefaultView(RideBases);

            //SaveTrainChangesCommand = new SaveTrainChangesCommand(this);
            //DiscardTrainChangesCommand = new DiscardTrainChangesCommand(this);
            //AddTrainCommand = new AddTrainCommand(this);

            //DiscardTrainChangesCommand.DiscardChangesEvent += OnDiscardChanges;
            //AddTrainCommand.AddedTrainEvent += OnDiscardChanges;

        }
    }
}
