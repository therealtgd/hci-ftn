using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Models.App app { get; set; }

        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(Models.App app)
        {
            this.app = app;
            CurrentViewModel = new ClientTicketPurchasingViewModel(app);
        }
    }
}
