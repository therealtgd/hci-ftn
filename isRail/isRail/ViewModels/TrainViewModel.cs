using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class TrainViewModel : ViewModelBase, INotifyDataErrorInfo
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

                _errorMessage = null;
                if (string.IsNullOrEmpty(_train))
                    _errorMessage = "Ime voza mora sadržati bar 1 karakter.";
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(Train));

            }
        }


        public Models.App App { get; }

        public TrainViewModel(string train, Models.App app)
        {
            _train = train;
            App = app;
        }

        private string _errorMessage;
        public bool HasErrors => !string.IsNullOrEmpty(_errorMessage);
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _errorMessage;
        }
    }
}
