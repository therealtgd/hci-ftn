using isRail.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.ViewModels
{
    public class EditRideViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public Ride _ride { get; set; }

        private string _train;
        public string Train
        {
            get { return _train; }
            set
            {
                _train = value;
                OnPropertyChanged(nameof(Train));

                ClearErrors(nameof(Train));
                if (string.IsNullOrEmpty(value))
                    AddError("Ime voza mora sadržati bar 1 karakter.", nameof(Train));
                else
                {
                    if (!App.Trains.Contains(value))
                        AddError($"No train with name {value} exists!", nameof(Train));
                }

            }
        }

        private const string dateFormat = "dd.MM.yyyy. HH:mm";
        
        public string DateFormat { get { return dateFormat; } }

        private string _startTime;
        public string StartTime 
        { 
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));

                ClearErrors(nameof(StartTime));
                DateTime startTime;
                if (DateTime.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startTime))
                {
                    if (startTime < DateTime.Now)
                        AddError("Datum je prosao!", nameof(StartTime));
                    else if (!_propertyNameToErrorsDictionary.ContainsKey(nameof(EndTime)))
                    {
                        DateTime endTime = DateTime.ParseExact(_endTime, dateFormat, CultureInfo.InvariantCulture);
                        if (endTime < startTime)
                            AddError("Ne moze polazak posle dolaska!", nameof(StartTime));
                    }
                }
                else
                    AddError("Invalidna vrednost za datum.", nameof(StartTime));
            }
        }
        private string _endTime;
        public string EndTime 
        { 
            get { return _endTime; } 
            set 
            { 
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));

                ClearErrors(nameof(EndTime));
                DateTime endTime;
                if (DateTime.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endTime))
                {
                    if (endTime < DateTime.Now)
                        AddError("Datum je prosao!", nameof(EndTime));
                    else if (!_propertyNameToErrorsDictionary.ContainsKey(nameof(StartTime)))
                    {
                        DateTime startTime = DateTime.ParseExact(_startTime, dateFormat, CultureInfo.InvariantCulture);
                        if (endTime < startTime)
                            AddError("Ne moze dolazak pre polaska!", nameof(EndTime));
                    }
                }
                else
                    AddError("Invalidna vrednost za datum.", nameof(EndTime));
            }
        }
        private string _price;
        public string Price 
        { 
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));

                ClearErrors(nameof(Price));
                if (value.Split(" ").Count() != 2)
                {
                    AddError("Invalidna vrednost za polje 'cena'.", nameof(Price));
                }
                else
                {
                    double price;
                    if (!double.TryParse(value.Split(" ")[0], out price))
                        AddError("Invalidna vrednost za polje 'cena'", nameof(Price));
                }
            } 
        }

        public Models.App App { get; }

        public EditRideViewModel(Ride ride, Models.App app)
        {
            App = app;
            _ride = ride;
            _train = ride.Train;
            _price = ride.Price.ToString() + " RSD";
            _startTime = _ride.StartTime.ToString(dateFormat);
            _endTime = _ride.EndTime.ToString(dateFormat);

            _propertyNameToErrorsDictionary = new Dictionary<string, string>();
        }

        private readonly Dictionary<string, string> _propertyNameToErrorsDictionary;

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, string.Empty);
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);

            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, string.Empty);
            }
            _propertyNameToErrorsDictionary[propertyName] = errorMessage;

            OnErrorsChanged(propertyName);
        }
    }
}
