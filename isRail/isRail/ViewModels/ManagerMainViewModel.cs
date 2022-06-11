using isRail.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class ManagerMainViewModel : ViewModelBase
    {
        public Models.App App { get; }

        private ViewModelBase _currentManagerViewModel;
        public ViewModelBase CurrentManagerViewModel
        {
            get
            { return _currentManagerViewModel; }
            set
            {
                _currentManagerViewModel = value;
                OnPropertyChanged(nameof(CurrentManagerViewModel));
            }
        }

        public ICommand ManagerNavigateCommand { get; }
        public ManagerEditRidesViewModel ManagerEditRidesViewModel { get; set; }
        public ManagerEditRideBasesViewModel ManagerEditRideBasesViewModel { get; set; }
        public ManagerEditTrainsViewModel ManagerEditTrainsViewModel { get; set; }
        public ManagerReportMonthlyViewModel ManagerReportMonthlyViewModel { get; set; }
        public ManagerReportRideViewModel ManagerReportRideViewModel { get;set; }
        public ICommand LogoutCommand { get; }
        public ICommand LogoutAndExitCommand { get; }

        public ManagerMainViewModel(Models.App app)
        {
            App = app;
            // editing views
            ManagerEditRidesViewModel = new ManagerEditRidesViewModel(App);
            ManagerEditRideBasesViewModel = new ManagerEditRideBasesViewModel(App);
            ManagerEditTrainsViewModel = new ManagerEditTrainsViewModel(App);
            // reports views
            ManagerReportMonthlyViewModel = new ManagerReportMonthlyViewModel(App);
            ManagerReportRideViewModel = new ManagerReportRideViewModel(App);

            ManagerNavigateCommand = new ManagerNavigateCommand(
                this,
                ManagerEditRidesViewModel,
                ManagerEditRideBasesViewModel,
                ManagerEditTrainsViewModel,
                ManagerReportMonthlyViewModel,
                ManagerReportRideViewModel
            );

            // TODO: Implementirati funkcionalnost ove dve komande!
            LogoutCommand = new LogoutCommand(App);
            LogoutAndExitCommand = new LogoutAndExitCommand();
        }
    }
}
