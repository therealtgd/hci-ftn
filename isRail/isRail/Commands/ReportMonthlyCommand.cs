using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class ReportMonthlyCommand : CommandBase
    {
        private ManagerMainViewModel _managerMainViewModel;
        private ManagerReportMonthlyViewModel _managerReportMonthlyViewModel;

        public ReportMonthlyCommand(ManagerMainViewModel managerMainViewModel, ManagerReportMonthlyViewModel managerReportMonthlyViewModel)
        {
            _managerMainViewModel = managerMainViewModel;
            _managerReportMonthlyViewModel = managerReportMonthlyViewModel;
        }
        public override void Execute(object parameter)
        {
            _managerMainViewModel.CurrentManagerViewModel = _managerReportMonthlyViewModel;
        }
    }
}
