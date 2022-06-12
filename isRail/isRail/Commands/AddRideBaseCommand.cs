using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class AddRideBaseCommand : CommandBase
    {
        private ManagerEditRideBasesViewModel _managerEditRideBasesViewModel;
        public static event Action AddedRideBaseEvent;

        public AddRideBaseCommand(ManagerEditRideBasesViewModel managerEditRideBasesViewModel)
        {
            _managerEditRideBasesViewModel = managerEditRideBasesViewModel;
        }

        public override void Execute(object parameter)
        {
            MessageBoxInputCustom messageBox = new MessageBoxInputCustom("Dodaj liniju", _managerEditRideBasesViewModel);
            messageBox.ShowDialog();
            bool? result = messageBox.DialogResult;
            if (result.Value)
            {
                    AddedRideBaseEvent?.Invoke();
            }
        }
    }
}
