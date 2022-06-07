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
    /// Interaction logic for ClientTicketPurchasingView.xaml
    /// </summary>
    public partial class ClientTicketPurchasingView : UserControl
    {
        public ClientTicketPurchasingView()
        {
            InitializeComponent();
        }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Da li ste sigurni da želite kupiti kartu?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
                new MessageBoxCustom("Uspešno ste kupili kartu.", MessageType.Success, MessageButtons.Ok).ShowDialog();
            else
                new MessageBoxCustom("Kupovina otkazana.", MessageType.Info, MessageButtons.Ok).ShowDialog();

        }
        private void ButtonReserve_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Da li ste sigurni da želite rezervisati kartu?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
                new MessageBoxCustom("Uspešno ste rezervisali kartu.", MessageType.Success, MessageButtons.Ok).ShowDialog();
            else
                new MessageBoxCustom("Rezervacija otkazana.", MessageType.Info, MessageButtons.Ok).ShowDialog();

        }
        

    }
}
