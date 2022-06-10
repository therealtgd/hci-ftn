using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class ManagerReportMonthlyViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        public ManagerReportMonthlyViewModel(Models.App app)
        {
            App = app;
        }
    }
}
