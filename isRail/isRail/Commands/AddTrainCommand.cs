using isRail.ViewModels;
using isRail.Views;
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
        public static event Action AddedTrainEvent;


        public AddTrainCommand(ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
        }

        public override void Execute(object parameter)
        {
            MessageBoxInputCustom messageBox = new MessageBoxInputCustom("Dodaj voz", _managerEditTrainsViewModel);
            messageBox.ShowDialog();
            bool? result = messageBox.DialogResult;
            if (result.Value)
            {

                string newTrain = messageBox.InputValue;
                if (_managerEditTrainsViewModel.App.Trains.Contains(newTrain))
                {
                    MessageBoxCustom mb = new MessageBoxCustom("Nije moguće dodati voz.\nVoz: " + newTrain + " već postoji.", MessageType.Error, MessageButtons.Ok);
                    mb.Height += 40;
                    mb.ShowDialog();
                }
                else
                {
                    _managerEditTrainsViewModel.App.Trains.Add(newTrain);
                    AddedTrainEvent?.Invoke();
                }
            }
        }
    }
}
