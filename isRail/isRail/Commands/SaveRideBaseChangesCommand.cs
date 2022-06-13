using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{

    public class SaveRideBaseChangesCommand : CommandBase
    {
        private ManagerEditRideBasesViewModel _managerEditRideBasesViewModel;
        private bool _canExecute { get; set; } = false;

        public static event Action SaveChangesEvent;

        public SaveRideBaseChangesCommand(ManagerEditRideBasesViewModel managerEditRideBasesViewModel)
        {
            _managerEditRideBasesViewModel = managerEditRideBasesViewModel;
            //foreach (var RideBase in _managerEditRideBasesViewModel.RideBases)
            //    RideBase.PropertyChanged += OnPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
