using isRail.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class RideBaseViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private RideBase _rideBase { get; set; }
        public RideBase RideBase
        {
            get
            {
                return _rideBase;
            }
            set
            {
                _rideBase = value;
                OnPropertyChanged(nameof(RideBase));
            }
        }


        public Models.App App { get; }

        public RideBaseViewModel(RideBase rideBase, Models.App app)
        {
            _rideBase = rideBase;
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
