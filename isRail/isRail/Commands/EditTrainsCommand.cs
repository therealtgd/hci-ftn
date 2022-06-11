using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class EditTrainsCommand : CommandBase
    {
        private ManagerMainViewModel _managerMainViewModel;
        private ManagerEditTrainsViewModel _managerEditTrainsViewModel;

        public EditTrainsCommand(ManagerMainViewModel managerMainViewModel, ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _managerMainViewModel = managerMainViewModel;
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
        }
        public override void Execute(object parameter)
        {
            _managerMainViewModel.CurrentManagerViewModel = _managerEditTrainsViewModel;
        }
    }
}
