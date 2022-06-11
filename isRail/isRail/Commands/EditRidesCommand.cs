using isRail.Services;
using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class EditRidesCommand : CommandBase
    {
        private ManagerMainViewModel _managerMainViewModel;
        private ManagerEditRidesViewModel _managerEditRidesViewModel;

        public EditRidesCommand(ManagerMainViewModel managerMainViewModel, ManagerEditRidesViewModel managerEditRidesViewModel)
        {
            _managerMainViewModel = managerMainViewModel;
            _managerEditRidesViewModel = managerEditRidesViewModel;
        }

        public override void Execute(object parameter)
        {
            _managerMainViewModel.CurrentManagerViewModel = _managerEditRidesViewModel;
        }
    }
}
