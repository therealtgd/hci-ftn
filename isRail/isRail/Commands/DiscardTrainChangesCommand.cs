using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace isRail.Commands
{
    public class DiscardTrainChangesCommand : CommandBase
    {
        private ManagerEditTrainsViewModel _managerEditTrainsViewModel;
        public static event Action DiscardChangesEvent;

        public DiscardTrainChangesCommand(ManagerEditTrainsViewModel managerEditTrainsViewModel)
        {
            _managerEditTrainsViewModel = managerEditTrainsViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li želite da odbacite promene?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result.Value)
            {
               
                _managerEditTrainsViewModel.TrainsCollectionView = CollectionViewSource.GetDefaultView(_managerEditTrainsViewModel.Trains);
                new MessageBoxCustom("Promene su uspešno odbačene.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                DiscardChangesEvent?.Invoke();
            }

        }
    }
}
