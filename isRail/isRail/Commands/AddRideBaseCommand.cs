using isRail.Models;
using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class AddRideBaseCommand : CommandBase
    {
        private ManagerEditRideBasesViewModel _managerEditRideBasesViewModel;
        public static event Action AddedRideBaseEvent;

        public AddRideBaseCommand(ManagerEditRideBasesViewModel managerEditRideBasesViewModel)
        {
            _managerEditRideBasesViewModel = managerEditRideBasesViewModel;
        }

        public override void Execute(object parameter)
        {
            
            MessageBoxCustom messageBox = new MessageBoxCustom("Da li ste sigurni da želite dodati novu liniju?", MessageType.Info, MessageButtons.YesNo);
            messageBox.ShowDialog();
            bool? result = messageBox.DialogResult;
            if (result.Value)
            {
                if (parameter is not null)
                {
                    RideBase newRideBase = (RideBase)parameter;
                    _managerEditRideBasesViewModel.RideBases.Add(new RideBaseViewModel(newRideBase, _managerEditRideBasesViewModel.App));
                    _managerEditRideBasesViewModel.App.RidesMap.Add(newRideBase, new List<Ride>());
                    AddedRideBaseEvent?.Invoke();
                }

            }
        }
    }
}
