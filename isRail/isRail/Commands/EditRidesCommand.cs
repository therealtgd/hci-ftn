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
    internal class EditRidesCommand : CommandBase
    {
        private ManagerMainViewModel _managerMainViewModel;

        public EditRidesCommand(ManagerMainViewModel managerMainViewModel)
        {
            _managerMainViewModel = managerMainViewModel;
        }

        public override void Execute(object parameter)
        {
            
            _managerMainViewModel?.Dispose();
            _managerMainViewModel.CurrentManagerViewModel = new ManagerEditRidesViewModel(_managerMainViewModel.App);
        }
    }
}
