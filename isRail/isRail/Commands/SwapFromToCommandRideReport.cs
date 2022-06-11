using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class SwapFromToCommandRideReport : CommandBase
    {
        private readonly ManagerReportRideViewModel _managerReportRideViewModel;

        public SwapFromToCommandRideReport(ManagerReportRideViewModel managerReportRideViewModel)
        {
            _managerReportRideViewModel = managerReportRideViewModel;
        }
        public override void Execute(object parameter)
        {
            string tmp = _managerReportRideViewModel.ToFilter;
            _managerReportRideViewModel.ToFilter = _managerReportRideViewModel.FromFilter;
            _managerReportRideViewModel.FromFilter = tmp;
        }
    }
}
