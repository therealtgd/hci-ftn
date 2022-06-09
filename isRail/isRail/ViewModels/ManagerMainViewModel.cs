using isRail.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class ManagerMainViewModel : ViewModelBase
    {
        public Models.App App { get; }

        private ViewModelBase _currentManagerViewModel;
        public ViewModelBase CurrentManagerViewModel
        {
            get
            { return _currentManagerViewModel; }
            set
            {
                _currentManagerViewModel = value;
                OnPropertyChanged(nameof(CurrentManagerViewModel));
            }
        }

        public ICommand EditRidesCommand { get; }


        public ManagerMainViewModel(Models.App app)
        {
            App = app;
            EditRidesCommand = new EditRidesCommand(this);
        }
    }
}
