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

        public ManagerNavigateCommand(ManagerMainViewModel managerMainViewModel)
        {
            _managerMainViewModel = managerMainViewModel;
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
                    _managerMainViewModel.CurrentManagerViewModel = new ManagerEditRidesViewModel(_managerMainViewModel.App);
                    break;
                case "editTrains":
                    _managerMainViewModel.CurrentManagerViewModel = new ManagerEditTrainsViewModel(_managerMainViewModel.App);
                    break;
                default:
                    break;
            }

        }
    }
}
