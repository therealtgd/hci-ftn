using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class AddTrainCommand : CommandBase
    {
        private ManagerEditTrainsViewModel _managerEditTrainsViewModel;

        public AddTrainCommand(ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
