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
        public ICommand EditRidesCommand { get; }
        public ManagerEditRidesViewModel ManagerEditRidesViewModel { get; set; }
        public ICommand EditRideBasesCommand { get; }
        public ManagerEditRideBasesViewModel ManagerEditRideBasesViewModel { get; set; }
        public ICommand EditTrainsCommand { get; }
        public ManagerEditTrainsViewModel ManagerEditTrainsViewModel { get; set; }
        public ICommand ReportMonthlyCommand { get; }
        public ManagerReportMonthlyViewModel ManagerReportMonthlyViewModel { get; set; }
        public ICommand ReportRideCommand { get; }
        public ManagerReportRideViewModel ManagerReportRideViewModel { get;set; }
        public ICommand LogoutCommand { get; }
        public ICommand LogoutAndExitCommand { get; }

        public ManagerMainViewModel(Models.App app)
        {
            App = app;
            ManagerNavigateCommand = new ManagerNavigateCommand(this);

            ManagerEditRidesViewModel = new ManagerEditRidesViewModel(App);
            EditRidesCommand = new EditRidesCommand(this, ManagerEditRidesViewModel);

            ManagerEditRideBasesViewModel = new ManagerEditRideBasesViewModel(App);
            EditRideBasesCommand = new EditRideBasesCommand(this, ManagerEditRideBasesViewModel);

            ManagerEditTrainsViewModel = new ManagerEditTrainsViewModel(App);
            EditTrainsCommand = new EditTrainsCommand(this, ManagerEditTrainsViewModel);

            ManagerReportMonthlyViewModel = new ManagerReportMonthlyViewModel(App);
            ReportMonthlyCommand = new ReportMonthlyCommand(this, ManagerReportMonthlyViewModel);

            ManagerReportRideViewModel = new ManagerReportRideViewModel(App);
            ReportRideCommand = new ReportRideCommand(this, ManagerReportRideViewModel);

            // TODO: Implementirati funkcionalnost ove dve komande!
            LogoutCommand = new LogoutCommand();
            LogoutAndExitCommand = new LogoutAndExitCommand();
        }
    }
}
