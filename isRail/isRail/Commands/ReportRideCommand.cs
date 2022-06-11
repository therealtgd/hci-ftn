using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class ReportRideCommand : CommandBase
    {
        private ManagerMainViewModel _managerMainViewModel;
        private ManagerReportRideViewModel _managerReportRideViewModel;

        public ReportRideCommand(ManagerMainViewModel managerMainViewModel, ManagerReportRideViewModel managerReportRideViewModel)
        {
            _managerMainViewModel = managerMainViewModel;
            _managerReportRideViewModel = managerReportRideViewModel;
        }
        public override void Execute(object parameter)
        {
            _managerMainViewModel.CurrentManagerViewModel = _managerReportRideViewModel;
        }
    }
}
