using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using isRail.Commands;

namespace isRail.ViewModels
{
    public class ManagerEditRideBasesViewModel : ViewModelBase
    {
        public string toLocationText;
        public string fromLocationText;
        public string ToLocationText {
            get
            {
                return toLocationText;
            }
            set
            {
                toLocationText = value;
                OnPropertyChanged(nameof(toLocationText));
            }
        }
        public string FromLocationText
        {
            get
            {
                return fromLocationText;
            }
            set
            {
                fromLocationText = value;
                OnPropertyChanged(nameof(fromLocationText));
            }
        }
        public Models.App App { get; set; }

        public ObservableCollection<RideBaseViewModel> RideBases { get; set; }
        public ObservableCollection<StationViewModel> Stations { get; set; }

        public ICollectionView RideBasesCollectionView { get; set; }

        public ICollectionView StationCollectionView { get; set; }

        public SaveRideBaseChangesCommand SaveRideBaseChangesCommand { get; set; }
        public DiscardRideBaseChangesCommand DiscardRideBaseChangesCommand { get; set; }
        public AddTrainCommand AddTrainCommand { get; set; }
        public static event Action FinishedDiscardingChangesEvent;

        private RideBaseViewModel selectedRideBase;
        public VideoCommand VideoCommand { get; set; }

        public RideBaseViewModel SelectedRideBase
        {
            get { return selectedRideBase; }
            set 
            {
                selectedRideBase = value;
                UpdateGrid();
                OnPropertyChanged(nameof(selectedRideBase));
            }
        }


        public SaveRideBaseChangesCommand SaveRideBaseChanges { get; set; }
        public DiscardRideBaseChangesCommand DiscardRideBaseChanges { get; set; }
        public AddRideBaseCommand AddRideBase { get; set; }

        public ManagerEditRideBasesViewModel(Models.App app)
        {
            App = app;
            RideBases = new ObservableCollection<RideBaseViewModel>();
            Stations = new ObservableCollection<StationViewModel>();

            foreach (RideBase rideBase in app.RidesMap.Keys)
                RideBases.Add(new RideBaseViewModel(rideBase, app));

            RideBasesCollectionView = CollectionViewSource.GetDefaultView(RideBases);
            StationCollectionView = CollectionViewSource.GetDefaultView(Stations);

            SaveRideBaseChanges = new SaveRideBaseChangesCommand(this);
            DiscardRideBaseChangesCommand = new DiscardRideBaseChangesCommand(this);
            AddRideBase = new AddRideBaseCommand(this);
            VideoCommand = new VideoCommand();
            DiscardTrainChangesCommand.DiscardChangesEvent += OnDiscardChanges;
            AddTrainCommand.AddedTrainEvent += OnDiscardChanges;
        }

        private void UpdateGrid()
        {
            FromLocationText = selectedRideBase.From.ToString();
            ToLocationText = selectedRideBase.To.ToString();
            Stations.Clear();
            foreach (Station s in selectedRideBase.RideBase.Stations)
                Stations.Add(new StationViewModel(s, App));
            
            StationCollectionView.Refresh();
            OnPropertyChanged(nameof(Stations));
        }

        private void OnDiscardChanges()
        {
            RideBases.Clear();
            foreach (RideBase rB in App.RidesMap.Keys)
                RideBases.Add(new RideBaseViewModel(rB, App));
            FinishedDiscardingChangesEvent?.Invoke();
        }
    }
}
