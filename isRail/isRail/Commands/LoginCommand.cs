using isRail.Models;
using isRail.Services;
using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class LoginCommand : CommandBase
    {
        private LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.Username) && !string.IsNullOrEmpty(_loginViewModel.Password) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            User? user = _loginViewModel.App.Users.Find(u =>
            u.Username.Equals(_loginViewModel.Username) &&
            u.Password.Equals(_loginViewModel.Password));
            if (user != null)
            {
                if (user is Client)
                {
                    _loginViewModel.App.Client = (Client) user;
                    new NavigationService<ClientMainViewModel>(_loginViewModel.App.NavigationStore, _loginViewModel.App.CreateTicketPurchasingViewModel).Navigate();
                }
                else if (user is Manager)
                {
                    _loginViewModel.App.Manager = (Manager) user;
                    new NavigationService<ManagerMainViewModel>(_loginViewModel.App.NavigationStore, _loginViewModel.App.CreateManagerMainViewModel).Navigate();
                }

                else
                    _loginViewModel.App.Manager = (Manager) user;
            }
            else
                new MessageBoxCustom("Prijava neuspešna.", MessageType.Info, MessageButtons.Ok).ShowDialog();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Username) || e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
