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
    /// Interaction logic for ClientReservedTicketsView.xaml
    /// </summary>
    public partial class ClientReservedTicketsView : UserControl
    {
        private DepartureDetailsView _departureDetailsView { get; set; }
        public ClientReservedTicketsView()
        {
            InitializeComponent();
        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            RideViewModel ride = (RideViewModel)((Button)e.Source).DataContext;
            if (_departureDetailsView != null)
                _departureDetailsView.Close();
            _departureDetailsView = new DepartureDetailsView(ride, ((RideViewModel)((Button)sender).DataContext).App);
            _departureDetailsView.Show();
        }
    }
}
