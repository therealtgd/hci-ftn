using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class ManagerNavigateCommand : CommandBase
    {
        private ManagerMainViewModel _managerMainViewModel;
        private ManagerEditRidesViewModel _managerEditRidesViewModel;
        private ManagerEditRideBasesViewModel _managerEditRideBasesViewModel;
        private ManagerEditTrainsViewModel _managerEditTrainsViewModel;
        private ManagerReportMonthlyViewModel _managerReportMonthlyViewModel;
        private ManagerReportRideViewModel _managerReportRideViewModel;

        public ManagerNavigateCommand(
            ManagerMainViewModel managerMainViewModel,
            ManagerEditRidesViewModel managerEditRidesViewModel,
            ManagerEditRideBasesViewModel managerEditRideBasesViewModel,
            ManagerEditTrainsViewModel managerEditTrainsViewModel,
            ManagerReportMonthlyViewModel managerReportMonthlyViewModel,
            ManagerReportRideViewModel managerReportRideViewModel
            )
        {
            _managerMainViewModel = managerMainViewModel;
            _managerEditRidesViewModel = managerEditRidesViewModel;
            _managerEditRideBasesViewModel = managerEditRideBasesViewModel;
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
            _managerReportMonthlyViewModel = managerReportMonthlyViewModel;
            _managerReportRideViewModel = managerReportRideViewModel;
        }

        public override void Execute(object parameter)
        {
            _managerMainViewModel?.Dispose();
            ChangeViewModel(parameter.ToString());
        }

        private void ChangeViewModel(string key)
        {
            switch(key)
            {
                case "editRides":
                    _managerMainViewModel.CurrentManagerViewModel = _managerEditRidesViewModel;
                    break;
                case "editRideBases":
                    _managerMainViewModel.CurrentManagerViewModel = _managerEditRideBasesViewModel;
                    break;
                case "editTrains":
                    _managerMainViewModel.CurrentManagerViewModel = _managerEditTrainsViewModel;
                    break;
                case "reportMonthly":
                    _managerMainViewModel.CurrentManagerViewModel = _managerReportMonthlyViewModel;
                    break;
                case "reportRide":
                    _managerMainViewModel.CurrentManagerViewModel = _managerReportRideViewModel;
                    break;
                default:
                    break;
            }

        }
    }
}
