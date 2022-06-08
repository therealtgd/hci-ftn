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
        private ClientMapView mapView;
        private ClientTicketPurchasingView ticketPurchasingView;

        public ClientMainWindow()
        {
            InitializeComponent();
            ticketPurchasingView = new ClientTicketPurchasingView();
            mapView = new ClientMapView();

            mainGrid.Children.Add(ticketPurchasingView);
            mainGrid.Children.Add(mapView);
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mapView.Visibility = Visibility.Visible;
            ticketPurchasingView.Visibility = Visibility.Collapsed;
        }


    }
}
