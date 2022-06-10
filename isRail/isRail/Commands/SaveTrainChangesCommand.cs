using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class SaveTrainChangesCommand : CommandBase
    {
        private ManagerEditTrainsViewModel _managerEditTrainsViewModel;

        public SaveTrainChangesCommand(ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li želite da sačuvate promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            
            if (result.Value)
            {
                _managerEditTrainsViewModel.App.Trains.Clear();
                foreach (TrainViewModel tVM in _managerEditTrainsViewModel.Trains)
                {
                    _managerEditTrainsViewModel.App.Trains.Add(tVM.Train);
                }
                new MessageBoxCustom("Promene su uspešno sačuvane.", MessageType.Success, MessageButtons.Ok).ShowDialog();
            }

        }
    }
}
