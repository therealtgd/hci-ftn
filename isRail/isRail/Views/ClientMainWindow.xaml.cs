using isRail.Commands;
using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace isRail.Views
{
    /// <summary>
    /// Interaction logic for ClientMainWindow.xaml
    /// </summary>
    public partial class ClientMainWindow : UserControl
    {

        public ClientMainWindow()
        {
            InitializeComponent();

        }



        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Logout_Clicked(object sender, MouseButtonEventArgs e)
        {
            new LogoutCommand(((sender as TabItem).DataContext as ClientMainViewModel).App).Execute(true);
        }

        private void LogoutAndExit_Clicked(object sender, MouseButtonEventArgs e)
        {
            new LogoutAndExitCommand().Execute(true);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            switch (tabItem)
            {
                case "Odjava":
                {
                    new LogoutCommand(((sender as TabControl).DataContext as ClientMainViewModel).App).Execute(true);
                    break;
                }

                case "Odjava i Izlaz":
                    {
                        new LogoutAndExitCommand().Execute(true);
                        break;
                    }

                default:
                    return;
            }
        }
    }
}
