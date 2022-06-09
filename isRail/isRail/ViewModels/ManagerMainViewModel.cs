using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class ManagerMainViewModel : ViewModelBase
    {
        public Models.App App { get; }

        public ManagerMainViewModel(Models.App app)
        {
            App = app;
        }
    }
}
