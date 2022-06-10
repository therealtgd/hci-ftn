using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class ManagerEditTrainsViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        public ManagerEditTrainsViewModel(Models.App app)
        {
            App = app;
        }
    }
}
