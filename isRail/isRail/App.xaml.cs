using isRail.Models;
using isRail.Stores;
using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace isRail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly Models.App _app;


        public App()
        {
            _app = new();
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("sr-Latn-CS");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            _app.NavigationStore.CurrentViewModel = _app.CreateLoginViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_app.NavigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }


       
    }
}
