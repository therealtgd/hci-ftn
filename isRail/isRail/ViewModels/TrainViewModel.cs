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
        private string _editedTrain { get; set; }
        public string Train
        {
            get 
            { 
                if (_editedTrain != null)
                    return _editedTrain;
                return _train;
            }
            set { _editedTrain = value; }
        }


        public Models.App App { get; }

        public TrainViewModel(string train, Models.App app)
        {
            _train = train;
            App = app;
        }
    }
}
