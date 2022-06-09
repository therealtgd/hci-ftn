using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class TrainViewModel : ViewModelBase
    {

        private readonly string _train;
        public string Train => _train;
        public Models.App App { get; }

        public TrainViewModel(string train, Models.App app)
        {
            _train = train;
            App = app;
        }
    }
}
