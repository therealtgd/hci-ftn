using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class TrainViewModel : ViewModelBase
    {

        private string _train { get; set; }
        public string Train
        {
            get 
            { 
                return _train;
            }
            set {
                _train = value; 
                OnPropertyChanged(nameof(Train));
            }
        }


        public Models.App App { get; }

        public TrainViewModel(string train, Models.App app)
        {
            _train = train;
            App = app;
        }

    }
}
