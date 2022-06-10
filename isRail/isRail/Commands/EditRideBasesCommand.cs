using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class EditRideBasesCommand : CommandBase
    {
        private ManagerMainViewModel _managerMainViewModel;
        private ManagerEditRideBasesViewModel _managerEditRidesViewModel;

        public EditRideBasesCommand(ManagerMainViewModel managerMainViewModel, ManagerEditRideBasesViewModel managerEditRidesViewModel)
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
