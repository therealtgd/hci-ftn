using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class MainViewModel : ViewModelBase
    { 

        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(Models.App app)
        {
            CurrentViewModel = new ClientTicketPurchasingViewModel(app);
        }
    }
}
