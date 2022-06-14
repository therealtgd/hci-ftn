using isRail.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace isRail.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));

            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));

            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(Models.App app)
        {
            App = app;
            LoginCommand = new LoginCommand(this);
        }
    }
}
